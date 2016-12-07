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
        /// ItemsTest("summary>
        /// Тестовый метод, который вызывает "ItemsTest"- для проверки
        ///  соотвествия каждого входного параметра - выходному имени каталога
        /// 
        /// ItemsTest("/summary>
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
          
            ItemsTest("ДЕТСКИЕ.xls", "Детские");

            ItemsTest("ЕВРОКАРКАСЫ.xls", "Еврокаркасы");
            ItemsTest("ЕВРОПА МОДЕРН.xls", "Европа Модерн");
            ItemsTest("МАНТРА.xls", "Мантра");

            ItemsTest("МОДЕРН.xls", "Модерн");
            ItemsTest("НАСТЕННО-ПОТОЛОЧНЫЕ СВЕТИЛЬНИКИ.xls", "Настенно-потолочные Светильники");
            ItemsTest("НАСТОЛЬНЫЕ ЛАМПЫ.xls", "Настольные лампы");
            ItemsTest("ПОДВЕСНЫЕ СВЕТИЛЬНИКИ.xls", "Подвесные Светильники");
            ItemsTest("ПРЕСТИЖ.xls", "Престиж");
            ItemsTest("Пульты и комплектующие.xls", "Пульты и комплектующие");
            ItemsTest("РОТАНГ.xls", "Ротанг");
            ItemsTest("САДОВО-ПАРКОВЫЕ СВЕТИЛЬНИКИ.xls", "Садово-парковые Светильники");
            ItemsTest("СПОТЫ.xls", "Споты");
            ItemsTest("ТОРШЕРЫ.xls", "Торшеры");
            ItemsTest("ФЛОРИСТИКА.xls", "Флористика");
            ItemsTest("ХРУСТАЛЬ.xls", "Хрусталь");
            ItemsTest("ЧЕРНЫЕ КРУГИ.xls", "Черные круги и квадраты");
            ItemsTest("ЭКОНОМ.xls", "Эконом");
            ItemsTest("ЭКСКЛЮЗИВ.xls", "Эксклюзив");
            ItemsTest("ЭЛИТ.xls", "Элит");

        }
    }
}
