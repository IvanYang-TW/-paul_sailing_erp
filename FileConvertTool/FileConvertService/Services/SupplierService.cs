using FileConvertSerivce.Services;
using FileConvertService.Models.Customer;
using FileConvertService.Models.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileConvertService.Services
{
    public class SupplierService : IDataConvertService<DosSupplier, Supplier>
    {
        public void ConvertToNewSchemaAndExportExcel(string filePath, string exportDirPath)
        {
            var inputData = GetDosData(filePath);
            var resultData = ConvertToNewSchemaData(inputData);
            FileService<Supplier>.ExportDataToExcel(resultData, "Supplier", exportDirPath);
        }

        public IEnumerable<Supplier> ConvertToNewSchemaData(IEnumerable<DosSupplier> dosData)
        {
            if (dosData == null)
                throw new ArgumentNullException(nameof(dosData));

            var result = dosData
                .Select(x => new Supplier
                {
                    CODE = x.SNO,
                    ABBR = x.NAME,
                    CNAME = $"{x.NAME}{x.NAME1}",
                    ADDR = x.ADD,
                    ZIP = x.VOAL,
                    CMPID = x.IDNO,
                    BOSS = x.BOSS,
                    TEL1 = !Regex.IsMatch(x.TEL, @"^09") ? x.TEL : null,
                    TEL2 = !Regex.IsMatch(x.BTEL, @"^09") ? x.BTEL : null,
                    FAX1 = x.FAX,
                    CONTACT1 = x.ATTN,
                    MOBILE1 = Regex.IsMatch(x.TEL, @"^09") ? x.TEL : null,
                    MOBILE2 = Regex.IsMatch(x.BTEL, @"^09") ? x.BTEL : null
                }).OrderBy(x=>x.CODE);
            return result;
        }

        public IEnumerable<DosSupplier> GetDosData(string filePath)
        {
            return FileService<DosSupplier>.DbfGetData(filePath);
        }
    }
}
