using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelAddIn1;
using Microsoft.Office.Interop.Excel;

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
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            folderBrowserDialog1 = new FolderBrowserDialog();

            //folderBrowserDialog1.RootFolder =  @"C:\";



            //   openFileDialog1.InitialDirectory = @"C:\";

            //   openFileDialog1.Title = "Browse Text Files";



            //   openFileDialog1.CheckFileExists = true;

            //   openFileDialog1.CheckPathExists = true;



            ////   openFileDialog1.DefaultExt = "txt";

            ////   openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            ////   openFileDialog1.FilterIndex = 2;

            //   openFileDialog1.RestoreDirectory = true;



            //   openFileDialog1.ReadOnlyChecked = true;

            //   openFileDialog1.ShowReadOnly = true;



            //if (openFileDialog1.ShowDialog() == DialogResult.OK)

            //{

            //    textBox1.Text = openFileDialog1.FileName;

            //}


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
          //  Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
                richTextBox1.Text = richTextBox1.Text + dir + "/n/r";
                //MessageBox.Show(dir)
                // ThisAddIn addin = new ThisAddIn();
                // this.Application.Workbooks.Open(dir);
               // Workbooks ob = new Workbooks();
                //  Microsoft.Office.Interop.Excel.Workbooks.Open(dir, null, false, null, string.Empty, string.Empty, null, null, null, false, true, true, false, true, null);
            }
        }

        private static void openFile(string dir)
        {
            //Microsoft.Office.Interop.Excel.Workbooks wk = new 
           // Microsoft.Office.Interop.Excel.Workbook.Open (dir, null, false, null, string.Empty, string.Empty, null, null, null, false, true, true, false, true, null);
        }
    }
}
