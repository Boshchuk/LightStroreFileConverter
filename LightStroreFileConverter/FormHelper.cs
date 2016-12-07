using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightStroreFileConverter
{
    public static class FormHelper
    {
        public static void WritToRichBox(RichTextBox rbx, string str)
        {
            rbx.AppendText(str);
        }
    }
}
