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
            if (rbx.InvokeRequired)
            {
                Action action = () => rbx.AppendText(string.Format("{0}{1}", str, Environment.NewLine));
                rbx.Invoke(action, null);
            }
            else
            {
                rbx.AppendText(string.Format("{0}{1}", str, Environment.NewLine));
            }

        
           // rbx.AppendText(string.Format("{0}{1}", str,Environment.NewLine));
        }
    }


    /* https://msdn.microsoft.com/en-us/library/ms171728.aspx
     * // This method demonstrates a pattern for making thread-safe
// calls on a Windows Forms control. 
//
// If the calling thread is different from the thread that
// created the TextBox control, this method creates a
// SetTextCallback and calls itself asynchronously using the
// Invoke method.
//
// If the calling thread is the same as the thread that created
// the TextBox control, the Text property is set directly. 

private void SetText(string text)
{
	// InvokeRequired required compares the thread ID of the
	// calling thread to the thread ID of the creating thread.
	// If these threads are different, it returns true.
	if (this.textBox1.InvokeRequired)
	{	
		SetTextCallback d = new SetTextCallback(SetText);
		this.Invoke(d, new object[] { text });
	}
	else
	{
		this.textBox1.Text = text;
	}
}
     */
}
