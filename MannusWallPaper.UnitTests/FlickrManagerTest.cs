using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MannusWallPaper.UnitTests
{
    [TestClass]
    public class FlickrManagerTest
    {
        [TestMethod]
        public void SetRandomWallPaper()
        {
            var flickrManager = new FlickrManager();
            flickrManager.Start();
        }
    }
}
