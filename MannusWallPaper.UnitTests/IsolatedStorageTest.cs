using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MannusWallPaper.UnitTests
{
    [TestClass]
    public class IsolatedStorageTest
    {
        private IsolatedStorageManager _isolatedStorage;

        [TestInitialize]
        public void Setup()
        {
            _isolatedStorage = new IsolatedStorageManager();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var isAuthenticated = _isolatedStorage.FlickrIsAuthenticated;
            Assert.IsFalse(isAuthenticated);
        }
    }
}
