﻿using DbfDataReader;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FileConvertTool
{
    public class FileService
    {
        /// <summary>
        /// dbf檔轉換成csv檔
        /// </summary>
        /// <param name="dbfPath"></param>
        public static void DbfConvertToCsv(string dbfPath)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var dbfTable = new DbfTable(dbfPath, Encoding.GetEncoding("big5")))
                {
                    var header = dbfTable.Header;
                    var versionDescription = header.VersionDescription;
                    var hasMemo = dbfTable.Memo != null;
                    var recordCount = header.RecordCount;

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(string.Join(",", dbfTable.Columns.Select(x => x.ColumnName)));
                    // and to iterate over the rows
                    var skipDeleted = true;
                    var dbfRecord = new DbfRecord(dbfTable);


                    while (dbfTable.Read(dbfRecord))
                    {
                        if (skipDeleted && dbfRecord.IsDeleted)
                        {
                            continue;
                        }

                        sb.AppendLine(string.Join(",", dbfRecord.Values.Select(x => x.ToString())));
                    }
                    File.WriteAllText(Path.ChangeExtension(dbfPath, "csv"), sb.ToString(), Encoding.GetEncoding("big5"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        /// <summary>
        /// dbf檔轉換成DataTable
        /// </summary>
        /// <param name="dbfPath"></param>
        /// <returns></returns>
        public static DataTable DbfConvertToDataTable(string dbfPath)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var dbfTable = new DbfTable(dbfPath, Encoding.GetEncoding("big5")))
                {
                    var header = dbfTable.Header;
                    var versionDescription = header.VersionDescription;
                    var hasMemo = dbfTable.Memo != null;
                    var recordCount = header.RecordCount;

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(string.Join(",", dbfTable.Columns.Select(x => x.ColumnName)));
                    DataTable dt = new DataTable();
                    DataRow row = null;
                    dt.Columns.AddRange(dbfTable.Columns
                        .Select(x => new DataColumn
                        {
                            ColumnName = x.ColumnName,
                            DataType = x.DataType,
                        }).ToArray());
                    // and to iterate over the rows
                    var skipDeleted = true;
                    var dbfRecord = new DbfRecord(dbfTable);

                    while (dbfTable.Read(dbfRecord))
                    {
                        if (skipDeleted && dbfRecord.IsDeleted)
                        {
                            continue;
                        }
                        row = dt.NewRow();
                        for (int i = 0; dbfRecord.Values.Count > 0; i++)
                        {
                            row[i] = dbfRecord.Values[i];
                        }
                        dt.Rows.Add(row);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        /// <summary>
        /// dbf檔篩選
        /// </summary>
        /// <param name="dbfPath"></param>
        /// <returns></returns>
        public static DataTable DbfFilterData(string dbfPath)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var dbfTable = new DbfTable(dbfPath, Encoding.GetEncoding("big5")))
                {
                    var header = dbfTable.Header;
                    var versionDescription = header.VersionDescription;
                    var hasMemo = dbfTable.Memo != null;
                    var recordCount = header.RecordCount;

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(string.Join(",", dbfTable.Columns.Select(x => x.ColumnName)));
                    DataTable dt = new DataTable();
                    DataRow row = null;
                    dt.Columns.AddRange(dbfTable.Columns
                        .Select(x => new DataColumn
                        {
                            ColumnName = x.ColumnName,
                            DataType = x.DataType,
                        }).ToArray());
                    // and to iterate over the rows
                    var skipDeleted = true;
                    var dbfRecord = new DbfRecord(dbfTable);

                    while (dbfTable.Read(dbfRecord))
                    {
                        if (skipDeleted && dbfRecord.IsDeleted)
                        {
                            continue;
                        }
                        row = dt.NewRow();
                        for (int i = 0; dbfRecord.Values.Count > 0; i++)
                        {
                            row[i] = dbfRecord.Values[i];
                        }
                        dt.Rows.Add(row);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        /// <summary>
        /// 儲存DataTable為Excel檔
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="xlsxFilename"></param>
        public static void SaveDataTableAsExcel(DataTable dt, string xlsxFilename)
        {
            ////建立Excel 2007檔案
            IWorkbook wb = new XSSFWorkbook();
            ISheet ws;

            if (dt.TableName != string.Empty)
            {
                ws = wb.CreateSheet(dt.TableName);
            }
            else
            {
                ws = wb.CreateSheet("Sheet1");
            }

            ws.CreateRow(0);//第一行為欄位名稱
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ws.GetRow(0).CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ws.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ws.GetRow(i + 1).CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            FileStream file = new FileStream(xlsxFilename, FileMode.Create);//產生檔案
            wb.Write(file);
            file.Close();
        }
        /// <summary>
        /// dbf檔案轉換成Excel檔
        /// </summary>
        /// <param name="sheetName">試算表名稱</param>
        /// <param name="dbfPath">dbf檔案路徑</param>
        /// <param name="exportDirPath">匯出資料夾路徑</param>
        public static void DbfConvertToExcel(string sheetName, string dbfPath, string exportDirPath)
        {
            try
            {
                ////建立Excel 2007檔案
                IWorkbook wb = new XSSFWorkbook();
                ISheet ws;

                if (sheetName != string.Empty)
                {
                    ws = wb.CreateSheet(sheetName);
                }
                else
                {
                    ws = wb.CreateSheet("Sheet1");
                }

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var dbfTable = new DbfTable(dbfPath, Encoding.GetEncoding("big5")))
                {
                    var header = dbfTable.Header;
                    var versionDescription = header.VersionDescription;
                    var hasMemo = dbfTable.Memo != null;
                    var recordCount = header.RecordCount;

                    ws.CreateRow(0);//第一行為欄位名稱
                    for (int i = 0; i < dbfTable.Columns.Count; i++)
                    {
                        ws.GetRow(0).CreateCell(i).SetCellValue(dbfTable.Columns[i].ColumnName);
                    }

                    // and to iterate over the rows
                    var skipDeleted = true;
                    var dbfRecord = new DbfRecord(dbfTable);

                    int iRow = 0;
                    while (dbfTable.Read(dbfRecord))
                    {
                        if (skipDeleted && dbfRecord.IsDeleted)
                        {
                            continue;
                        }

                        ws.CreateRow(iRow + 1);
                        for (int j = 0; j < dbfTable.Columns.Count; j++)
                        {
                            ws.GetRow(iRow + 1).CreateCell(j).SetCellValue(dbfRecord.Values[j].ToString());
                        }
                        iRow++;
                    }

                    string exportFilePath = Path.ChangeExtension(Path.Combine(exportDirPath, Path.GetFileName(dbfPath)), "xlsx");
                    FileStream file = new FileStream(exportFilePath, FileMode.Create);//產生檔案
                    wb.Write(file);
                    wb.Dispose();
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
