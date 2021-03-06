﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mannus.Library.Extensions;
namespace MannusWallPaper
{
    public class LibraryManager : PictureManager
    {
        protected override void SetRandomWallPaper()
        {
            var imageLibraries = MannusWallPaperConfiguration.GetConfig().ImageLibraries; 
            if (imageLibraries.Count > 0)
            {
                Random random = new Random();
                var randomIndex = random.Next(0, imageLibraries.Count -1);
                var imageDirectory = imageLibraries[randomIndex];
                DirectoryInfo directory = new DirectoryInfo(imageDirectory.Path);
                if (!directory.Exists)
                {
                    _logger.LogError("Directory {0} doesn't exist", directory.FullName);
                    return;
                }
                var images = directory.GetImages();
                randomIndex = random.Next(0, images.Count - 1);
                var randomImage = images[randomIndex];
                SetWallPaper(randomImage.FullName);
            }
        }
    }
}