using System;
using System.IO;
using System.Windows.Forms;
using Ncc.Helper;
using Excel = Microsoft.Office.Interop.Excel;

namespace LightStroreFileConverter
{
    public partial class Form1 : Form
    {
        readonly NamingHelper _helper = new NamingHelper();

        private InputFolderInfo _currentFolderInfo = new InputFolderInfo();

        public string OutPutFolderPath { get; set; } = @"C:\Output\";

        public bool OutPutFolderExist { get; set; } = false;

        public Form1()
        {
            InitializeComponent();

            _helper.ReadDictionary();
            _currentFolderInfo.TotalItemsCountChanged += InfoChangedHandler;

            PrepareOutPutFolder();
        }

        private void PrepareOutPutFolder()
        {
            richTextBox1.WriteLine(string.Format("Проверка выходной директории: {0}", OutPutFolderPath));
            var exist = Directory.Exists(OutPutFolderPath);

            if (exist)
            {
                richTextBox1.WriteLine("Выходная директория присутствует...");
                OutPutFolderExist = true;
            }
            else
            {
                richTextBox1.WriteLine("Выходная директория отсутствует... Попытка создания");

                try
                {
                    Directory.CreateDirectory(OutPutFolderPath);
                    OutPutFolderExist = true;
                    richTextBox1.WriteLine("Выходная директория успешно создана");
                }
                catch (Exception)
                {
                    richTextBox1.WriteLine("Ошибка создания выходной директории...");
                    richTextBox1.WriteLine("Основная функциональность недоступна...");
                    OutPutFolderExist = false;
                }
            }
        }

        private void InfoChangedHandler(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            bttnTransform.Enabled = false;
            if (_currentFolderInfo.TotalItemsCount > 0)
            {
           //     checkBox1.Enabled = true;
                bttnTransform.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxFolderPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        public void WriteToRichBox(string str)
        {
            FormHelper.WritToRichBox(richTextBox1, str);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxFolderPath.Text))
            {
                return;
            }

            string[] dirs = Directory.GetFiles(textBoxFolderPath.Text);
            foreach (string dir in dirs)
            {
                richTextBox1.WriteLine(dir);
                
                var saveName = NewNameFromPath(dir);

                var savePath = String.Format("{0}{1}", Outputpath(), saveName);

                var excelApp = new Excel.Application();
                excelApp.Workbooks.Open(dir);
                excelApp.ActiveWorkbook.SaveAs(savePath, Excel.XlFileFormat.xlOpenXMLWorkbook);

                excelApp.Workbooks.Close();
                excelApp.Quit();
            }
        }

        public string NewNameFromPath(string path)
        {
            var f = new FileInfo(path);

          
            return _helper.GetNameFromDictionary(f.Name);
        }

        public string Outputpath()
        {
            return OutPutFolderPath;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bttnAnalyzeFolder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFolderPath.Text))
            {
                MessageBox.Show("Для старта анализа сначала выбирите папку");
                return;
            }

            var exist = Directory.Exists(textBoxFolderPath.Text);

            if (!exist)
            {
                MessageBox.Show("Данная попка не найдена или не существует, проверте путь, или выбирите другую папку");
            }

            AnalyzeFolder(textBoxFolderPath.Text);
        }

        private void AnalyzeFolder(string pathToFolder)
        {
            _currentFolderInfo = _helper.AnalyzeFolder(pathToFolder);

            richTextBox1.WriteLine(string.Format("Результаты анализа папки: {0}", pathToFolder) );
            richTextBox1.WriteLine(_currentFolderInfo.ToString());

            if (_currentFolderInfo.TotalItemsCount > 0)
            {
                InfoChangedHandler(this, EventArgs.Empty);
            }
        }

        private void textBoxFolderPath_TextChanged(object sender, EventArgs e)
        {
            bttnAnalyzeFolder.Enabled = !string.IsNullOrEmpty(textBoxFolderPath.Text);
        }
    }

  
}
