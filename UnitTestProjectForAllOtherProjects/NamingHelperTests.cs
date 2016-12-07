using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ncc.Helper;

namespace UnitTestProjectForAllOtherProjects
{
    [TestClass]
    public class NamingHelperTests
    {
        [TestMethod]
        public void DictionaryNotEmpty()
        {
            var helper = new NamingHelper();
            helper.ReadDictionary();

            var length = helper.Dictionary.Count;

            Assert.IsTrue(length > 0);
        }

        private static void ItemsTest(string param, string expected)
        {
            var helper = new NamingHelper();
            helper.ReadDictionary();
            
            var led = helper.GetNameFromDictionary(param);

            Assert.AreEqual(expected, led);
        }

        [TestMethod]
        public void CheckAllDictionary()
        {
            ItemsTest("LED.xls","LED");
            ItemsTest("LOFT.xls", "LOFT");
            ItemsTest("АРТЕ.xls", "АРТЕ");
            ItemsTest("БУШЕ G-4.xls", "БУШЕ G-4");
            ItemsTest("БУШЕ Е-27 И Е-14.xls", "БУШЕ Е-27 И Е-14");
            ItemsTest("БУШЕ МР3.xls", "БУШЕ МР3");

            ItemsTest("ГАЛОГЕН (ВЕТКИ).xls", "Галоген (Ветки)");
            ItemsTest("ГАЛОГЕН.xls", "Галоген");

            /*
             * ,,,,
,,,,
ДЕТСКИЕ.xls,Детские,,,**/
        }
    }
}
