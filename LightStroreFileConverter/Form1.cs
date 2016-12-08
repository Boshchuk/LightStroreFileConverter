using System;
using System.IO;
using System.Windows.Forms;
using Ncc.Helper;
using Excel = Microsoft.Office.Interop.Excel;

namespace LightStroreFileConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

            NamingHelper helper = new NamingHelper();
            helper.ReadDictionary();
            return helper.GetNameFromDictionary(f.Name);
        }

        public string Outputpath()
        {
            return @"C:\Output\";
        }

        
    }
}
