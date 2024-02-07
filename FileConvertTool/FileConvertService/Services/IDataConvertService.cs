namespace FileConvertSerivce.Services
{
    public interface IDataConvertService<DosDataType, NewDataType>
    {
        /// <summary>
        /// 取得Dos產品資料
        /// </summary>
        /// <param name="filePath">讀取檔案路徑</param>
        /// <returns></returns>
        public IEnumerable<DosDataType> GetDosData(string filePath);
        /// <summary>
        ///  轉換成新系統Schema資料
        /// </summary>
        /// <param name="dosData">需轉換的資料</param>
        /// <returns></returns>
        public IEnumerable<NewDataType> ConvertToNewSchemaData(IEnumerable<DosDataType> dosData);
        /// <summary>
        /// 轉換成新系統Schema並匯出成Excel
        /// </summary>
        /// <param name="filePath">讀取檔案路徑</param>
        /// <param name="exportDirPath">匯出資料夾</param>
        public void ConvertToNewSchemaAndExportExcel(string filePath, string exportDirPath);
    }
}