using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ncc.Helper;

namespace UnitTestProjectForAllOtherProjects
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var helper = new NamingHelper();
            helper.ReadDictionary();

            var length = helper.Dictionary.Count;

            Assert.IsTrue(length > 0);
        }

        [TestMethod]
        public void ItemsTest()
        {
            var helper = new NamingHelper();
            helper.ReadDictionary();


            var led = helper.GetNameFromDictionary("LED.xls");

            Assert.AreEqual("LED",led);
        }
    }
}
