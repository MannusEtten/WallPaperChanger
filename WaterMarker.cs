using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MannusWallPaper
{
    internal class WaterMarker
    {
        private const int WATERMARKHEIGHT = 30;

        public void AddWaterMark(string filename, string watermark)
        {
            if (IsWatermarkAllowed(watermark))
            {
                ChangeImage(filename, watermark);
            }
        }

        private bool IsWatermarkAllowed(string watermark)
        {
            var filenameInLowerCase = watermark.ToLowerInvariant().Trim();
            var filters = MannusWallPaperConfiguration.GetConfig().WaterMarkFilters;
            foreach(var filter in filters.Items)
            {
                var filterPrefix = filter.Prefix.ToLowerInvariant().Trim();
                if(watermark.StartsWith(filterPrefix))
                {
                    return false;
                }
            }
            return true;
        }

        private void ChangeImage(string filePath, string text)
        {
            int width = 0;
            int height = 0;
            using(Image originalImage = Image.FromFile(filePath))
            {
                width = originalImage.Width;
                height = originalImage.Height;
            }
            using (Bitmap bitmapWithWaterMark = new Bitmap(width, height + WATERMARKHEIGHT))
            {
                using (var graphics = Graphics.FromImage(bitmapWithWaterMark))
                {
                    using (Image originalImage = Image.FromFile(filePath))
                    {
                        graphics.DrawImage(originalImage, 0F, 0F,  (float)width, (float)height);
                    }
                    graphics.DrawRectangle(new Pen(Color.Black, 1), 0, height - 1, width - 1, WATERMARKHEIGHT - 1);
                    graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, width - 1, height- 1);
                    graphics.FillRectangle(Brushes.White, 1, height, width - 2, WATERMARKHEIGHT - 1);
                    graphics.DrawString(text,SystemFonts.DefaultFont , Brushes.Black,5,height + 5);
                    bitmapWithWaterMark.Save(filePath);
                }
            }
        }
    }
}