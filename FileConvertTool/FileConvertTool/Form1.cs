using NPOI.HPSF;
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

namespace FileConvertTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_dbfFileConvert_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText($"{DateTime.Now.ToString("F")} | 開始執行 單檔案_執行dbf轉檔Excel \n");
            richTextBox1.Refresh();
            string selectFile = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "dbf files (*.dbf)|*.dbf|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(selectFile);
                    try
                    {
                        //Get the path of specified file
                        selectFile = openFileDialog.FileName;
                        FileService.DbfConvertToExcel(fileName, selectFile);
                        richTextBox1.AppendText($"{DateTime.Now.ToString("F")} | 完成轉換 {fileName} \n");
                        richTextBox1.Refresh();
                    }
                    catch (Exception ex)
                    {
                        richTextBox1.AppendText($"{DateTime.Now.ToString("F")} | 轉換失敗 {fileName} {ex.Message} \n");
                        richTextBox1.Refresh();
                    }
                }
            }
        }

        private void btn_directoryDbfConvertToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.AppendText($"{DateTime.Now.ToString("F")} | 開始執行 整批轉換_執行dbf轉檔Excel \n");
                richTextBox1.Refresh();

                string dirPath = Path.Combine(Application.StartupPath, "dbfFiles");
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                    richTextBox1.AppendText($"{DateTime.Now.ToString("F")} | 完成建立資料夾 {dirPath} \n");
                    richTextBox1.Refresh();
                }
                var files = Directory.GetFiles(dirPath,"*.dbf");
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    try
                    {
                        FileService.DbfConvertToExcel(fileName, file);
                        richTextBox1.AppendText($"{DateTime.Now.ToString("F")} | 完成轉換 {fileName} \n");
                        richTextBox1.Refresh();
                    }
                    catch (Exception ex)
                    {
                        richTextBox1.AppendText($"{DateTime.Now.ToString("F")} | 轉換失敗 {fileName} {ex.Message} \n");
                        richTextBox1.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"{DateTime.Now.ToString("F")} | 執行失敗 {ex.Message} \n");
                richTextBox1.Refresh();
            }
        }
    }
}
