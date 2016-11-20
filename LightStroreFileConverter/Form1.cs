using System;
using System.IO;
using System.Windows.Forms;

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                return;
            }

            string[] dirs = Directory.GetFiles(textBox1.Text);
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
                richTextBox1.Text = richTextBox1.Text + dir + "/n/r";

                var excelApp = new Excel.Application();

                excelApp.Workbooks.Open(dir);
                excelApp.ActiveWorkbook.SaveAs(@"C:\Output\Book1.xlsx", Excel.XlSaveAsAccessMode.xlNoChange);
                excelApp.Workbooks.Close();

                excelApp.Quit();
            }
        }

        private static void openFile(string dir)
        {
            //Microsoft.Office.Interop.Excel.Workbooks wk = new 
           // Microsoft.Office.Interop.Excel.Workbook.Open (dir, null, false, null, string.Empty, string.Empty, null, null, null, false, true, true, false, true, null);
        }
    }
}
