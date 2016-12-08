using System;
using System.Windows.Forms;

namespace LightStroreFileConverter
{
    public static class FormHelper
    {
        public static void WritToRichBox(RichTextBox rbx, string str)
        {
            rbx.AppendText(str);
        }

        //TODO Витька разберись , что такое метод расширение
        public static void WriteLine(this RichTextBox rbx , string str )
        {
            rbx.AppendText(string.Format("{0}{1}", str,Environment.NewLine));
        }
    }
}
