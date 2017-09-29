using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestSonar
{
    class TempUploadFileService : ITempUploadFileService
    {
        public string FilePath { get; set; }
        public string SaveFile(HttpPostedFileBase file, int? newWidthImg = null)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var path = HttpContext.Current.Server.MapPath(FilePath);
            var filePath = Path.Combine(path, fileName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (file.ContentType.ToLower().StartsWith("image/"))
            {
                Image img = Image.FromStream(file.InputStream, true, true);
                ImageHelper.RotateImageByExifOrientationData(img);
                if (newWidthImg != null && newWidthImg > 0)
                {
                    img = ResizeImage(img);
                }
                img.Save(filePath, ImageFormat.Jpeg);
            }
            else
            {
                file.SaveAs(filePath);
            }
            return fileName;
        }

        public void RemoveFile(string file)
        {
            if (!String.IsNullOrEmpty(file))
            {
                var path = HttpContext.Current.Server.MapPath(FilePath);
                var fileName = Path.GetFileName(file);
                var filePath = Path.Combine(path, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        private static Image ResizeImage(Image originalImage)
        {
            float width = 1024;// kich thuoc co dinh cho signature
            float height = 768;
            var brush = new SolidBrush(Color.White);
            //var a = new Bitmap(destWidth, destHeight);
            float scale = Math.Min(width / originalImage.Width, height / originalImage.Height);
            var bmp = new Bitmap((int)width, (int)height);
            var graph = Graphics.FromImage(bmp);

            // uncomment for higher quality output
            graph.InterpolationMode = InterpolationMode.High;
            graph.CompositingQuality = CompositingQuality.HighQuality;
            graph.SmoothingMode = SmoothingMode.AntiAlias;

            var scaleWidth = (int)(originalImage.Width * scale);
            var scaleHeight = (int)(originalImage.Height * scale);

            graph.FillRectangle(brush, new RectangleF(0, 0, width, height));
            graph.DrawImage(originalImage, new Rectangle(((int)width - scaleWidth) / 2, ((int)height - scaleHeight) / 2, scaleWidth, scaleHeight));
            return (Image)bmp;
        }

        public static Image ResizeImageFixedWidth(int width, Image imgToResize)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = ((float)width / (float)sourceWidth);

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Image b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return b;
        }
    }
}
