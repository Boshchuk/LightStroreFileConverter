using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LightStroreFileConverter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            this.button1 = new Button();
            this.button2 = new Button();
            this.richTextBox1 = new RichTextBox();
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new Size(144, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выбрать папку";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new Point(12, 91);
            this.button2.Name = "button2";
            this.button2.Size = new Size(141, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Преоброзовать файлы";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new Point(13, 159);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new Size(387, 92);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 131);
            this.label1.Name = "label1";
            this.label1.Size = new Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Results";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Point(12, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(144, 20);
            this.textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(421, 266);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Button button1;
        private Button button2;
        private RichTextBox richTextBox1;
        private Label label1;
        private TextBox textBox1;
    }
}

