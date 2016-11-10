using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
namespace com.allinpay.ecommerce.ImageHelper.ImageOperator
{
    public class ImageWaterMark
    {
        public void addWaterMark(string oldpath, string newpath, WaterMarkType wmtType, string sWaterMarkContent, WaterMarkPosition position)
        {
            try
            {
                Image image = Image.FromFile(oldpath);
                Bitmap bitmap = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.Clear(Color.White);
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.DrawImage(image, 0, 0, image.Width, image.Height);
                switch (wmtType)
                {
                    case WaterMarkType.TextMark:
                        this.addWatermarkText(graphics, sWaterMarkContent, position, image.Width, image.Height);
                        break;
                    case WaterMarkType.ImageMark:
                        this.addWatermarkImage(graphics, HttpContext.Current.Server.MapPath(sWaterMarkContent), position, image.Width, image.Height);
                        break;
                }
                image.Dispose();
                if (newpath != "")
                {
                    bitmap.Save(newpath);
                }
                else
                {
                    bitmap.Save(oldpath);
                }
                bitmap.Dispose();
            }
            catch
            {
                if (newpath != "" && File.Exists(oldpath))
                {
                    File.Delete(oldpath);
                }
            }
            finally
            {
                if (newpath != "" && File.Exists(oldpath))
                {
                    File.Delete(oldpath);
                }
            }
        }
        private void addWatermarkText(Graphics picture, string _watermarkText, WaterMarkPosition _watermarkPosition, int _width, int _height)
        {
            int[] array = new int[]
			{
				32,
				30,
				28,
				26,
				24,
				22,
				20,
				18,
				16,
				14,
				12,
				10,
				8,
				6,
				4
			};
            Font font = null;
            SizeF sizeF = default(SizeF);
            for (int i = 0; i < array.Length; i++)
            {
                font = new Font("Arial Black", (float)array[i], FontStyle.Bold);
                sizeF = picture.MeasureString(_watermarkText, font);
                if ((ushort)sizeF.Width < (ushort)_width)
                {
                    break;
                }
            }
            Bitmap bitmap = new Bitmap((int)sizeF.Width + 3, (int)sizeF.Height + 3, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            PointF pointF = new PointF(0f, 0f);
            Brush brush = new SolidBrush(Color.FromArgb(255, Color.Black));
            Brush brush2 = new SolidBrush(Color.FromArgb(255, Color.Black));
            graphics.DrawString(_watermarkText, font, brush, pointF.X, pointF.Y + 1f);
            graphics.DrawString(_watermarkText, font, brush, pointF.X + 1f, pointF.Y);
            graphics.DrawString(_watermarkText, font, brush2, pointF.X + 1f, pointF.Y + 1f);
            graphics.DrawString(_watermarkText, font, brush2, pointF.X, pointF.Y + 2f);
            graphics.DrawString(_watermarkText, font, brush2, pointF.X + 2f, pointF.Y);
            brush.Dispose();
            brush2.Dispose();
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.DrawString(_watermarkText, font, new SolidBrush(Color.White), pointF.X, pointF.Y, StringFormat.GenericDefault);
            graphics.Save();
            graphics.Dispose();
            this.addWatermarkImage(picture, new Bitmap(bitmap), WaterMarkPosition.WMP_Right_Bottom, _width, _height);
        }
        private void addWatermarkImage(Graphics picture, Image iTheImage, WaterMarkPosition _watermarkPosition, int _width, int _height)
        {
            Image image = new Bitmap(iTheImage);
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
            float[][] arg_6F_0 = array;
            int arg_6F_1 = 0;
            float[] array2 = new float[5];
            array2[0] = 1f;
            arg_6F_0[arg_6F_1] = array2;
            float[][] arg_86_0 = array;
            int arg_86_1 = 1;
            float[] array3 = new float[5];
            array3[1] = 1f;
            arg_86_0[arg_86_1] = array3;
            float[][] arg_9D_0 = array;
            int arg_9D_1 = 2;
            float[] array4 = new float[5];
            array4[2] = 1f;
            arg_9D_0[arg_9D_1] = array4;
            float[][] arg_B4_0 = array;
            int arg_B4_1 = 3;
            float[] array5 = new float[5];
            array5[3] = 0.3f;
            arg_B4_0[arg_B4_1] = array5;
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
            int x = 0;
            int y = 0;
            double num;
            if (_width > image.Width * 2 && _height > image.Height * 2)
            {
                num = 1.0;
            }
            else
            {
                if (_width > image.Width * 2 && _height < image.Height * 2)
                {
                    num = Convert.ToDouble(_height / 2) / Convert.ToDouble(image.Height);
                }
                else
                {
                    if (_width < image.Width * 2 && _height > image.Height * 2)
                    {
                        num = Convert.ToDouble(_width / 2) / Convert.ToDouble(image.Width);
                    }
                    else
                    {
                        if (_width * image.Height > _height * image.Width)
                        {
                            num = Convert.ToDouble(_height / 2) / Convert.ToDouble(image.Height);
                        }
                        else
                        {
                            num = Convert.ToDouble(_width / 2) / Convert.ToDouble(image.Width);
                        }
                    }
                }
            }
            int num2 = Convert.ToInt32((double)image.Width * num);
            int num3 = Convert.ToInt32((double)image.Height * num);
            switch (_watermarkPosition)
            {
                case WaterMarkPosition.WMP_Left_Top:
                    x = 10;
                    y = 10;
                    break;
                case WaterMarkPosition.WMP_Left_Bottom:
                    x = 10;
                    y = _height - num3 - 10;
                    break;
                case WaterMarkPosition.WMP_Right_Top:
                    x = _width - num2 - 10;
                    y = 10;
                    break;
                case WaterMarkPosition.WMP_Right_Bottom:
                    x = _width - num2 - 10;
                    y = _height - num3 - 10;
                    break;
            }
            picture.DrawImage(image, new Rectangle(x, y, num2, num3), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
            image.Dispose();
            imageAttributes.Dispose();
        }
        private void addWatermarkImage(Graphics picture, string WaterMarkPicPath, WaterMarkPosition _watermarkPosition, int _width, int _height)
        {
            Image iTheImage = new Bitmap(WaterMarkPicPath);
            this.addWatermarkImage(picture, iTheImage, _watermarkPosition, _width, _height);
        }
    }
}
