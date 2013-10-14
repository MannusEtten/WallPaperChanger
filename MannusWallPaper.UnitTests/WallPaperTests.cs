using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MannusWallPaper.UnitTests
{
    [TestClass]
    public class WallPaperTests
    {
        [TestMethod]
        public void WallPaperElement_To_String_Is_Correct()
        {
            var wallpaper = MannusWallPaper.MannusWallPaperConfiguration.GetConfig().WallPapers[0];
            var result = wallpaper.ToString();
            var expected = "company";
            Assert.AreEqual(expected,result);
        }
    }
}