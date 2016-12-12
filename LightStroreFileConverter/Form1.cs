using System;
using System.IO;
using System.Windows.Forms;
using Ncc.Helper;
using Excel = Microsoft.Office.Interop.Excel;

namespace LightStroreFileConverter //Имя метода - что за бред
{
    public partial class Form1 : Form // создание под ка-ласса Form???
    {
        public Form1()
        {
            InitializeComponent();// инициализация компонента - какого компонента?  
        }

        private void button1_Click(object sender, EventArgs e)
        {

            folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        public void WriteToRichBox(string str)
        {
            FormHelper.WritToRichBox(richTextBox1, str);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                return;
            }

            string[] dirs = Directory.GetFiles(textBox1.Text);
            foreach (string dir in dirs)
            {
                WriteToRichBox(dir);

                
                var saveName = NewNameFromPath(dir);

                var savePath = String.Format("{0}{1}", Outputpath(), saveName);

                var excelApp = new Excel.Application();
                excelApp.Workbooks.Open(dir);
                excelApp.ActiveWorkbook.SaveAs(savePath, Excel.XlFileFormat.xlOpenXMLWorkbook);

                excelApp.Workbooks.Close();
                excelApp.Quit();
            }
        }
        /// <summary>
        /// Я три раза нажал на /// и такое случилось
        /// а Витюша дибиленоек не смог прочитать задание так как онон написано
        /// Используя коментария вида ///  - разобраться что это за коментарии такие - подписать все методы (кроме сгенерированных)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string NewNameFromPath(string path)// Я не знаю что он делает  - а почитать что внутри? в поезде зарядки небыло? или этого небыло в поставах?
        {
            var f = new FileInfo(path);

            NamingHelper helper = new NamingHelper();
            helper.ReadDictionary();
            return helper.GetNameFromDictionary(f.Name);
        }

        /// <summary>
        /// Выходная директория  
        /// Output
        /// path
        /// </summary>
        /// <returns>Возвращает путь выходной директории</returns>
        public string Outputpath()
        {
            return @"C:\Output\";
        }

        
    }
}
