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

        private void WritToRichBox(RichTextBox rbx, string str)
        {
            rbx.AppendText(str);
        }

        public void WriteToRichBox(string str)
        {
            WritToRichBox(richTextBox1, str);
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
                richTextBox1.Text = richTextBox1.Text + dir + "/r/n";

                
                var saveName = NewNameFromPath(dir);

                var savePath = string.Format("{0}{1}", Outputpath(), saveName);



                var excelApp = new Excel.Application();
                excelApp.Workbooks.Open(dir);




                object o = excelApp.ActiveWorkbook.Application.Selection;


                Excel.Worksheet objSheet = (Excel.Worksheet)excelApp.ActiveWorkbook.ActiveSheet;
                int[] test = { 1, 2, 3, 4, 5 };
                var res = objSheet.get_Range(test);


                excelApp.ActiveWorkbook.SaveAs(savePath, Excel.XlFileFormat.xlOpenXMLWorkbook);
             

                excelApp.Workbooks.Close();

                excelApp.Quit();
            }
        }

        public string NewNameFromPath(string path)
        {
            var f = new FileInfo(path);

            NamingHelper helper = new NamingHelper();
            //helper
            

            return string.Format("{0}", f.Name);
        }

        public string Outputpath()
        {
            
            return @"C:\Output\";
        }

        
    }
}
