using FileConvertSerivce.Services;
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
        /// <summary>
        /// dbf檔案轉換匯入資料夾路徑
        /// </summary>
        string DbfFileConvertInputDirPath = Path.Combine(Application.StartupPath, "dbfFiles\\input");

        /// <summary>
        /// dbf檔案轉換匯出資料夾路徑
        /// </summary>
        private string DbfFileConvertExportDirPath = Path.Combine(Application.StartupPath, "dbfFiles\\output");

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 按鈕_個別dbf檔案轉換Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        FileService.DbfConvertToExcel(fileName, selectFile, DbfFileConvertExportDirPath);
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
        /// <summary>
        /// 按鈕_資料夾內dbf檔案整批轉換
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_directoryDbfConvertToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBoxMsgLine($"{DateTime.Now.ToString("F")} | 開始執行 整批轉換_執行dbf轉檔Excel ");

                if (!Directory.Exists(DbfFileConvertInputDirPath))
                {
                    Directory.CreateDirectory(DbfFileConvertInputDirPath);
                    RichTextBoxMsgLine($"{DateTime.Now.ToString("F")} | 完成建立資料夾 {DbfFileConvertInputDirPath}");
                }
                var files = Directory.GetFiles(DbfFileConvertInputDirPath, "*.dbf");
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    try
                    {
                        FileService.DbfConvertToExcel(Path.GetFileNameWithoutExtension(file), file, DbfFileConvertExportDirPath);
                        RichTextBoxMsgLine($"{DateTime.Now.ToString("F")} | 完成轉換 {fileName}");
                    }
                    catch (Exception ex)
                    {
                        RichTextBoxMsgLine($"{DateTime.Now.ToString("F")} | 轉換失敗 {fileName} {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                RichTextBoxMsgLine($"{DateTime.Now.ToString("F")} | 執行失敗 {ex.Message}");
            }
        }

        /// <summary>
        /// RichTextBox訊息顯示
        /// </summary>
        /// <param name="msg"></param>
        private void RichTextBoxMsgLine(string msg)
        {
            richTextBox1.AppendText(msg + "\n");
            richTextBox1.Refresh();
        }
        /// <summary>
        /// 按鈕_整批轉換_轉為新Schema並匯出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConvertNewSchemaAndExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBoxMsgLine($"{DateTime.Now.ToString("F")} | 開始執行 整批轉換_轉為新Schema並匯出Excel ");

                if (!Directory.Exists(DbfFileConvertInputDirPath))
                {
                    Directory.CreateDirectory(DbfFileConvertInputDirPath);
                    RichTextBoxMsgLine($"{DateTime.Now.ToString("F")} | 完成建立資料夾 {DbfFileConvertInputDirPath}");
                }
                var files = Directory.GetFiles(DbfFileConvertInputDirPath, "*.dbf");
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    try
                    {
                        switch (fileName)
                        {
                            // 執行產品主檔轉換
                            case "jjzitm.dbf":
                                ProductService.ConvertToNewSchemaAndExportExcel(file, DbfFileConvertExportDirPath);
                                RichTextBoxMsgLine($"{DateTime.Now.ToString("F")} | 完成轉換 {fileName}");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        RichTextBoxMsgLine($"{DateTime.Now.ToString("F")} | 轉換失敗 {fileName} {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                RichTextBoxMsgLine($"{DateTime.Now.ToString("F")} | 執行失敗 {ex.Message}");
            }

        }
    }
}
