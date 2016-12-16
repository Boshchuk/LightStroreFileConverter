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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // bttnSelectFolder
            // 
            this.bttnSelectFolder.Location = new System.Drawing.Point(16, 12);
            this.bttnSelectFolder.Name = "bttnSelectFolder";
            this.bttnSelectFolder.Size = new System.Drawing.Size(383, 23);
            this.bttnSelectFolder.TabIndex = 0;
            this.bttnSelectFolder.Text = "Выбрать папку";
            this.bttnSelectFolder.UseVisualStyleBackColor = true;
            this.bttnSelectFolder.Click += new System.EventHandler(this.button1_Click);
            // 
            // bttnTransform
            // 
            this.bttnTransform.Enabled = false;
            this.bttnTransform.Location = new System.Drawing.Point(204, 263);
            this.bttnTransform.Name = "bttnTransform";
            this.bttnTransform.Size = new System.Drawing.Size(195, 23);
            this.bttnTransform.TabIndex = 1;
            this.bttnTransform.Text = "Преобразовать файлы";
            this.bttnTransform.UseVisualStyleBackColor = true;
            this.bttnTransform.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 316);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(387, 92);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Results";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Location = new System.Drawing.Point(16, 69);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.Size = new System.Drawing.Size(383, 20);
            this.textBoxFolderPath.TabIndex = 4;
            this.textBoxFolderPath.TextChanged += new System.EventHandler(this.textBoxFolderPath_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Полный путь";
            // 
            // bttnAnalyzeFolder
            // 
            this.bttnAnalyzeFolder.Enabled = false;
            this.bttnAnalyzeFolder.Location = new System.Drawing.Point(16, 109);
            this.bttnAnalyzeFolder.Name = "bttnAnalyzeFolder";
            this.bttnAnalyzeFolder.Size = new System.Drawing.Size(383, 23);
            this.bttnAnalyzeFolder.TabIndex = 7;
            this.bttnAnalyzeFolder.Text = "Анализ Папки";
            this.bttnAnalyzeFolder.UseVisualStyleBackColor = true;
            this.bttnAnalyzeFolder.Click += new System.EventHandler(this.bttnAnalyzeFolder_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(16, 267);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(189, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Преобразовывать неизвестные";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 171);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(383, 43);
            this.progressBar1.TabIndex = 9;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 420);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.bttnAnalyzeFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFolderPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.bttnTransform);
            this.Controls.Add(this.bttnSelectFolder);
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
        private ProgressBar progressBar1;
        private BackgroundWorker backgroundWorker1;
    }
}

