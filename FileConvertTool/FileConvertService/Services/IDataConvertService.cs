namespace FileConvertSerivce.Services
{
    public interface IDataConvertService<DosDataType, NewDataType>
    {
        public IEnumerable<DosDataType> GetDosData(string filePath);
        public IEnumerable<NewDataType> ConvertToNewSchemaData(IEnumerable<DosDataType> dosProduct);
        public void ConvertToNewSchemaAndExportExcel(string filePath, string exportDirPath);
    }
}