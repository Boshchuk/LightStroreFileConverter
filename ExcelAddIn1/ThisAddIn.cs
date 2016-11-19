using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace ExcelAddIn1
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            string[] dirs = Directory.GetFiles(@"C:\Input");
            foreach (string dir in dirs)
            {
               this.Application.Workbooks.Open(dir);
               this.Application.ActiveWorkbook.SaveAs(@"C:\Output\Book1.xlsx",
                Excel.XlSaveAsAccessMode.xlNoChange);
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion

        public void OpenBook(string dir)
        {
            this.Application.Workbooks.Open(dir);
        }
    }
}
