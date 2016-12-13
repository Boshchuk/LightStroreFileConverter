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
        private System.ComponentModel.IContainer components = null;

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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.bttnSelectFolder = new System.Windows.Forms.Button();
            this.bttnTransform = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFolderPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bttnAnalyzeFolder = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bttnSelectFolder
            // 
            this.bttnSelectFolder.Location = new System.Drawing.Point(21, 15);
            this.bttnSelectFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bttnSelectFolder.Name = "bttnSelectFolder";
            this.bttnSelectFolder.Size = new System.Drawing.Size(511, 28);
            this.bttnSelectFolder.TabIndex = 0;
            this.bttnSelectFolder.Text = "Выбрать папку";
            this.bttnSelectFolder.UseVisualStyleBackColor = true;
            this.bttnSelectFolder.Click += new System.EventHandler(this.button1_Click);
            // 
            // bttnTransform
            // 
            this.bttnTransform.Enabled = false;
            this.bttnTransform.Location = new System.Drawing.Point(272, 324);
            this.bttnTransform.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bttnTransform.Name = "bttnTransform";
            this.bttnTransform.Size = new System.Drawing.Size(260, 28);
            this.bttnTransform.TabIndex = 1;
            this.bttnTransform.Text = "Преобразовать файлы";
            this.bttnTransform.UseVisualStyleBackColor = true;
            this.bttnTransform.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(16, 389);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(515, 112);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 369);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Results";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Location = new System.Drawing.Point(21, 85);
            this.textBoxFolderPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.Size = new System.Drawing.Size(509, 22);
            this.textBoxFolderPath.TabIndex = 4;
            this.textBoxFolderPath.TextChanged += new System.EventHandler(this.textBoxFolderPath_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Полный путь";
            // 
            // bttnAnalyzeFolder
            // 
            this.bttnAnalyzeFolder.Enabled = false;
            this.bttnAnalyzeFolder.Location = new System.Drawing.Point(21, 134);
            this.bttnAnalyzeFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bttnAnalyzeFolder.Name = "bttnAnalyzeFolder";
            this.bttnAnalyzeFolder.Size = new System.Drawing.Size(511, 28);
            this.bttnAnalyzeFolder.TabIndex = 7;
            this.bttnAnalyzeFolder.Text = "Анализ Папки";
            this.bttnAnalyzeFolder.UseVisualStyleBackColor = true;
            this.bttnAnalyzeFolder.Click += new System.EventHandler(this.bttnAnalyzeFolder_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(21, 329);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(239, 21);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Преобразовывать неизвестные";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 517);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.bttnAnalyzeFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFolderPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.bttnTransform);
            this.Controls.Add(this.bttnSelectFolder);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Утилита импорта продуктов в каталог.  v.0.1.";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button bttnSelectFolder;
        private System.Windows.Forms.Button bttnTransform;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFolderPath;
        private Label label2;
        private Button bttnAnalyzeFolder;
        private CheckBox checkBox1;
    }
}

