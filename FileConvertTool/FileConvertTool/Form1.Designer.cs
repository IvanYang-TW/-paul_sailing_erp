
namespace FileConvertTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_dbfFileConvert = new System.Windows.Forms.Button();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            btn_directoryDbfConvertToExcel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btn_dbfFileConvert
            // 
            btn_dbfFileConvert.Location = new System.Drawing.Point(30, 12);
            btn_dbfFileConvert.Name = "btn_dbfFileConvert";
            btn_dbfFileConvert.Size = new System.Drawing.Size(195, 23);
            btn_dbfFileConvert.TabIndex = 0;
            btn_dbfFileConvert.Text = "單檔案_執行dbf轉檔Excel";
            btn_dbfFileConvert.UseVisualStyleBackColor = true;
            btn_dbfFileConvert.Click += btn_dbfFileConvert_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new System.Drawing.Point(21, 93);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(410, 267);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // btn_directoryDbfConvertToExcel
            // 
            btn_directoryDbfConvertToExcel.Location = new System.Drawing.Point(30, 54);
            btn_directoryDbfConvertToExcel.Name = "btn_directoryDbfConvertToExcel";
            btn_directoryDbfConvertToExcel.Size = new System.Drawing.Size(195, 23);
            btn_directoryDbfConvertToExcel.TabIndex = 2;
            btn_directoryDbfConvertToExcel.Text = "整批轉換_執行dbf轉檔Excel";
            btn_directoryDbfConvertToExcel.UseVisualStyleBackColor = true;
            btn_directoryDbfConvertToExcel.Click += btn_directoryDbfConvertToExcel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(451, 375);
            Controls.Add(btn_directoryDbfConvertToExcel);
            Controls.Add(richTextBox1);
            Controls.Add(btn_dbfFileConvert);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_dbfFileConvert;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_directoryDbfConvertToExcel;
    }
}

