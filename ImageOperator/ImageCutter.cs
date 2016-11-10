using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace com.allinpay.ecommerce.ImageHelper.ImageOperator
{
    public class ImageCutter
    {
        private void SaveImage(Image image, string savePath, ImageCodecInfo ici)
        {
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 90L);
            image.Save(savePath, ici, encoderParameters);
            encoderParameters.Dispose();
        }
        private ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo[] array = imageEncoders;
            for (int i = 0; i < array.Length; i++)
            {
                ImageCodecInfo imageCodecInfo = array[i];
                if (imageCodecInfo.MimeType == mimeType)
                {
                    return imageCodecInfo;
                }
            }
            return null;
        }
        public void ToThumbnailImages(string SourceImagePath, string ThumbnailImagePath, int ThumbnailImageWidth, int ThumbnailImageHeight)
        {
            int widths = ThumbnailImageWidth;
            int heights = ThumbnailImageHeight;
            Hashtable hashtable = new Hashtable();
            hashtable[".jpeg"] = "image/jpeg";
            hashtable[".jpg"] = "image/jpeg";
            hashtable[".png"] = "image/png";
            hashtable[".tif"] = "image/tiff";
            hashtable[".tiff"] = "image/tiff";
            hashtable[".bmp"] = "image/bmp";
            hashtable[".gif"] = "image/gif";
            string key = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
            Image image = Image.FromFile(SourceImagePath);
            int width = image.Width;
            int height = image.Height;
            double num = (double)width / (double)height;
            if (num >= (double)ThumbnailImageWidth / (double)ThumbnailImageHeight)
            {
                ThumbnailImageHeight = height * ThumbnailImageWidth / width;
            }
            else
            {
                ThumbnailImageWidth = width * ThumbnailImageHeight / height;
            }
            if (ThumbnailImageWidth < 1 || ThumbnailImageHeight < 1)
            {
                return;
            }

            Bitmap image2 = new Bitmap(widths, heights, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(image2);
            graphics.Clear(Color.Transparent);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.DrawImage(image, new Rectangle(0, 0, widths, heights));
            image.Dispose();
            try
            {
                this.SaveImage(image2, ThumbnailImagePath, this.GetCodecInfo((string)hashtable[key]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ToThumbnailImages(string SourceImagePath, string ThumbnailImagePath, int ThumbnailImageWidth)
        {
            Hashtable hashtable = new Hashtable();
            hashtable[".jpeg"] = "image/jpeg";
            hashtable[".jpg"] = "image/jpeg";
            hashtable[".png"] = "image/png";
            hashtable[".tif"] = "image/tiff";
            hashtable[".tiff"] = "image/tiff";
            hashtable[".bmp"] = "image/bmp";
            hashtable[".gif"] = "image/gif";
            string key = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
            Image image = Image.FromFile(SourceImagePath);
            int num = ThumbnailImageWidth / 4 * 3;
            int width = image.Width;
            int height = image.Height;
            if ((double)width / (double)height >= 1.3333333730697632)
            {
                num = height * ThumbnailImageWidth / width;
            }
            else
            {
                ThumbnailImageWidth = width * num / height;
            }
            if (ThumbnailImageWidth < 1 || num < 1)
            {
                return;
            }
            Bitmap image2 = new Bitmap(ThumbnailImageWidth, num, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(image2);
            graphics.Clear(Color.Transparent);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.DrawImage(image, new Rectangle(0, 0, ThumbnailImageWidth, num));
            image.Dispose();
            try
            {
                this.SaveImage(image2, ThumbnailImagePath, this.GetCodecInfo((string)hashtable[key]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ToThumbnailImages(string SourceImagePath, string WaterImagePath, string ThumbnailImagePath, int ThumbnailImageWidth, int ThumbnailImageHeight, int position, float alpha, int quality, bool IsMulti)
        {
            string a = Path.GetExtension(SourceImagePath).ToLower();
            if (!File.Exists(SourceImagePath) || (a != ".gif" && a != ".jpg" && a != ".png" && a != ".bmp"))
            {
                return string.Format("原图路径:{0}中未找到相关图片.或图片格式不支持!", SourceImagePath);
            }
            Image image = Image.FromFile(SourceImagePath);
            ThumbnailImageWidth = ((ThumbnailImageWidth == 0) ? image.Width : ThumbnailImageWidth);
            ThumbnailImageHeight = ((ThumbnailImageHeight == 0) ? image.Height : ThumbnailImageHeight);
            Bitmap bitmap = new Bitmap(ThumbnailImageWidth, ThumbnailImageHeight, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Transparent);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.DrawImage(image, new Rectangle(0, 0, ThumbnailImageWidth, ThumbnailImageHeight));
            image.Dispose();
            string result;
            try
            {
                result = this.DrawImageAddWater(bitmap, WaterImagePath, ThumbnailImagePath, position, alpha, quality, IsMulti);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        private string DrawImageAddWater(Image imgPhoto, string waterImagePath_Name, string SavePath, int position, float alpha, int quality, bool IsMulti)
        {
            string a = Path.GetExtension(waterImagePath_Name).ToLower();
            if (!File.Exists(waterImagePath_Name) || (a != ".gif" && a != ".jpg" && a != ".png" && a != ".bmp"))
            {
                return string.Format("水印路径:{0}中未找到相关图片.或水印图片格式不支持!", waterImagePath_Name);
            }
            int arg_5A_0 = imgPhoto.Width;
            int arg_61_0 = imgPhoto.Height;
            Image image = new Bitmap(waterImagePath_Name);
            int width = image.Width;
            int height = image.Height;
            Bitmap bitmap = new Bitmap(imgPhoto);
            bitmap.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
            Graphics graphics = Graphics.FromImage(bitmap);
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap[] map = new ColorMap[]
			{
				new ColorMap
				{
					OldColor = Color.FromArgb(255, 0, 255, 0),
					NewColor = Color.FromArgb(0, 0, 0, 0)
				}
			};
            imageAttributes.SetRemapTable(map, ColorAdjustType.Bitmap);
            float[][] array = new float[5][];
            float[][] arg_10B_0 = array;
            int arg_10B_1 = 0;
            float[] array2 = new float[5];
            array2[0] = 1f;
            arg_10B_0[arg_10B_1] = array2;
            float[][] arg_122_0 = array;
            int arg_122_1 = 1;
            float[] array3 = new float[5];
            array3[1] = 1f;
            arg_122_0[arg_122_1] = array3;
            float[][] arg_139_0 = array;
            int arg_139_1 = 2;
            float[] array4 = new float[5];
            array4[2] = 1f;
            arg_139_0[arg_139_1] = array4;
            float[][] arg_14D_0 = array;
            int arg_14D_1 = 3;
            float[] array5 = new float[5];
            array5[3] = alpha;
            arg_14D_0[arg_14D_1] = array5;
            array[4] = new float[]
			{
				0f,
				0f,
				0f,
				0f,
				1f
			};
            float[][] newColorMatrix = array;
            ColorMatrix newColorMatrix2 = new ColorMatrix(newColorMatrix);
            imageAttributes.SetColorMatrix(newColorMatrix2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            int num = 0;
            int y = 0;
            switch (position)
            {
                case 1:
                    num = (int)((float)imgPhoto.Width * 0.01f);
                    y = (int)((float)imgPhoto.Height * 0.01f);
                    break;
                case 2:
                    num = (int)((float)imgPhoto.Width * 0.5f - (float)(image.Width / 2));
                    y = (int)((float)imgPhoto.Height * 0.01f);
                    break;
                case 3:
                    num = (int)((float)imgPhoto.Width * 0.99f - (float)image.Width);
                    y = (int)((float)imgPhoto.Height * 0.01f);
                    break;
                case 4:
                    num = (int)((float)imgPhoto.Width * 0.005f);
                    y = (int)((float)imgPhoto.Height * 0.5f - (float)(image.Height / 2));
                    break;
                case 5:
                    num = (int)((float)imgPhoto.Width * 0.5f - (float)(image.Width / 2));
                    y = (int)((float)imgPhoto.Height * 0.5f - (float)(image.Height / 2));
                    break;
                case 6:
                    num = (int)((float)imgPhoto.Width * 0.99f - (float)image.Width);
                    y = (int)((float)imgPhoto.Height * 0.5f - (float)(image.Height / 2));
                    break;
                case 7:
                    num = (int)((float)imgPhoto.Width * 0.01f);
                    y = (int)((float)imgPhoto.Height * 0.99f - (float)image.Height);
                    break;
                case 8:
                    num = (int)((float)imgPhoto.Width * 0.5f - (float)(image.Width / 2));
                    y = (int)((float)imgPhoto.Height * 0.99f - (float)image.Height);
                    break;
                case 9:
                    num = (int)((float)imgPhoto.Width * 0.99f - (float)image.Width);
                    y = (int)((float)imgPhoto.Height * 0.99f - (float)image.Height);
                    break;
            }
            if (IsMulti)
            {
                for (int i = num; i < imgPhoto.Width + image.Width; i += image.Width + 5)
                {
                    graphics.DrawImage(image, new Rectangle(i, y, width, height), 0, 0, width, height, GraphicsUnit.Pixel, imageAttributes);
                }
            }
            else
            {
                graphics.DrawImage(image, new Rectangle(num, y, width, height), 0, 0, width, height, GraphicsUnit.Pixel, imageAttributes);
            }
            imgPhoto = bitmap;
            graphics.Dispose();
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo encoder = null;
            ImageCodecInfo[] array6 = imageEncoders;
            for (int j = 0; j < array6.Length; j++)
            {
                ImageCodecInfo imageCodecInfo = array6[j];
                if (imageCodecInfo.MimeType.IndexOf("jpeg") > -1)
                {
                    encoder = imageCodecInfo;
                }
            }
            EncoderParameters encoderParameters = new EncoderParameters();
            long[] array7 = new long[1];
            if (quality < 0 || quality > 100)
            {
                quality = 80;
            }
            array7[0] = (long)quality;
            EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, array7);
            encoderParameters.Param[0] = encoderParameter;
            imgPhoto.Save(SavePath, encoder, encoderParameters);
            imgPhoto.Dispose();
            image.Dispose();
            return string.Empty;
        }
    }
}
