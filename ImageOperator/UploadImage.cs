using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
namespace com.allinpay.ecommerce.ImageHelper.ImageOperator
{
    public class UploadImage
    {
        private string _MSG;
        private string[] _subpath = new string[5];
        private string[] _fullpath = new string[5];
        private int _limitwidth = 2048;
        private int _limitheight = 1536;
        private int[] _twidth = new int[5];
        private int[] _theight = new int[5];
        private int _size = 10000000;
        private bool _israte = true;
        private string _mainpath = ConfigurationManager.AppSettings["UploadFilePath"];
        public string MSG
        {
            get
            {
                return this._MSG;
            }
            set
            {
                this._MSG = value;
            }
        }
        public string[] SubPath
        {
            get
            {
                return this._subpath;
            }
            set
            {
                this._subpath = value;
            }
        }
        public int LimitWidth
        {
            get
            {
                return this._limitwidth;
            }
            set
            {
                this._limitwidth = value;
            }
        }
        public int LimitHeight
        {
            get
            {
                return this._limitheight;
            }
            set
            {
                this._limitheight = value;
            }
        }
        public int[] TWidth
        {
            get
            {
                return this._twidth;
            }
            set
            {
                this._twidth = value;
            }
        }
        public int[] THeight
        {
            get
            {
                return this._theight;
            }
            set
            {
                this._theight = value;
            }
        }
        public int Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }
        public bool IsRate
        {
            get
            {
                return this._israte;
            }
            set
            {
                this._israte = value;
            }
        }
        public string MainPath
        {
            get
            {
                return this._mainpath;
            }
            set
            {
                this._mainpath = value;
            }
        }
        public UploadImage()
        {
            for (int i = 0; i < 5; i++)
            {
                this._subpath[i] = "";
                this._fullpath[i] = "";
                this._twidth[i] = 0;
                this._theight[i] = 0;
            }
        }
        public bool UpLoadIMG(FileUpload UploadFile, string filename)
        {
            if (UploadFile.HasFile)
            {
                int num = filename.LastIndexOf(".");
                string text = filename.Substring(num, filename.Length - num);
                if (!(text == ".jpg") && !(text == ".jpeg") && !(text == ".bmp") && !(text == ".gif") && !(text == ".png"))
                {
                    this.MSG = "不受支持的类型,请重新选择！";
                    return false;
                }
                if (UploadFile.PostedFile.ContentLength == 0 || UploadFile.PostedFile.ContentLength >= this.Size)
                {
                    this.MSG = "指定的文件大小不符合要求，应在" + this.Size.ToString() + "字节以内！";
                    return false;
                }
                Stream inputStream = UploadFile.PostedFile.InputStream;
                System.Drawing.Image image = System.Drawing.Image.FromStream(inputStream);
                int width = image.Width;
                int height = image.Height;
                if (width < this.TWidth[0] && height < this.THeight[0])
                {
                    this.MSG = string.Concat(new object[]
					{
						"图片尺寸应大于",
						this.TWidth[0],
						"×",
						this.THeight[0],
						"！"
					});
                    return false;
                }
                string str = HttpContext.Current.Server.MapPath("~") + "\\" + this.MainPath + "\\";
                if (!Directory.Exists(str + this.SubPath[0]))
                {
                    Directory.CreateDirectory(str + this.SubPath[0]);
                }
                this._fullpath[0] = str + this.SubPath[0] + filename;
                try
                {
                    string a;
                    if ((a = text) != null)
                    {
                        if (!(a == ".jpeg") && !(a == ".jpg"))
                        {
                            if (!(a == ".gif"))
                            {
                                if (!(a == ".png"))
                                {
                                    if (a == ".bmp")
                                    {
                                        image.Save(this._fullpath[0], ImageFormat.Bmp);
                                    }
                                }
                                else
                                {
                                    image.Save(this._fullpath[0], ImageFormat.Png);
                                }
                            }
                            else
                            {
                                image.Save(this._fullpath[0], ImageFormat.Gif);
                            }
                        }
                        else
                        {
                            image.Save(this._fullpath[0], ImageFormat.Jpeg);
                        }
                    }
                    image.Dispose();
                    ImageCutter imageCutter = new ImageCutter();
                    new ImageWaterMark();
                    int num2 = 0;
                    while (num2 < 5 && this.TWidth[num2] != 0 && this.THeight[num2] != 0)
                    {
                        if (!Directory.Exists(str + this.SubPath[num2]))
                        {
                            Directory.CreateDirectory(str + this.SubPath[num2]);
                        }
                        this._fullpath[num2] = str + this.SubPath[num2] + filename;
                        imageCutter.ToThumbnailImages(this._fullpath[0], this._fullpath[num2], this.TWidth[num2], this.THeight[num2]);
                        num2++;
                    }
                    this.MSG = "图片上传成功！";
                    bool result = true;
                    return result;
                }
                catch (Exception ex)
                {
                    this.MSG = ex.Message;
                    bool result = false;
                    return result;
                }
                finally
                {
                    image.Dispose();
                }
            }
            this.MSG = "请先选择需要上传的图片！";
            return false;
        }
        public int UpLoadIMGByByte(System.Drawing.Image img, string filename)
        {
            int num = filename.LastIndexOf(".");
            string text = filename.Substring(num, filename.Length - num);
            if (!(text == ".jpg") && !(text == ".jpeg") && !(text == ".bmp") && !(text == ".gif") && !(text == ".png"))
            {
                this.MSG = "不受支持的类型,请重新选择！";
                return 21;
            }
            int width = img.Width;
            int height = img.Height;
            if (width < this.TWidth[0] && height < this.THeight[0])
            {
                this.MSG = string.Concat(new object[]
				{
					"图片尺寸应大于",
					this.TWidth[0],
					"×",
					this.THeight[0],
					"！"
				});
                return 20;
            }
            string str = this.MainPath + "\\";
            if (!Directory.Exists(str + this.SubPath[0]))
            {
                Directory.CreateDirectory(str + this.SubPath[0]);
            }
            this._fullpath[0] = str + this.SubPath[0] + filename;
            int result;
            try
            {
                string a;
                if ((a = text) != null)
                {
                    if (!(a == ".jpeg") && !(a == ".jpg"))
                    {
                        if (!(a == ".gif"))
                        {
                            if (!(a == ".png"))
                            {
                                if (a == ".bmp")
                                {
                                    img.Save(this._fullpath[0], ImageFormat.Bmp);
                                }
                            }
                            else
                            {
                                img.Save(this._fullpath[0], ImageFormat.Png);
                            }
                        }
                        else
                        {
                            img.Save(this._fullpath[0], ImageFormat.Gif);
                        }
                    }
                    else
                    {
                        img.Save(this._fullpath[0], ImageFormat.Jpeg);
                    }
                }
                img.Dispose();
                ImageCutter imageCutter = new ImageCutter();
                new ImageWaterMark();
                int num2 = 0;
                while (num2 < 5 && this.TWidth[num2] != 0 && this.THeight[num2] != 0)
                {
                    if (!Directory.Exists(str + this.SubPath[num2]))
                    {
                        Directory.CreateDirectory(str + this.SubPath[num2]);
                    }
                    this._fullpath[num2] = str + this.SubPath[num2] + filename;
                    imageCutter.ToThumbnailImages(this._fullpath[0], this._fullpath[num2], this.TWidth[num2], this.THeight[num2]);
                    num2++;
                }
                this.MSG = "图片上传成功！";
                result = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                img.Dispose();
            }
            return result;
        }
    }
}
