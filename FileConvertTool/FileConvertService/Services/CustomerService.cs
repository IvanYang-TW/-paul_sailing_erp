using FileConvertSerivce.Models.Product;
using FileConvertSerivce.Services;
using FileConvertService.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileConvertService.Services
{
    public class CustomerService : IDataConvertService<DosCustomer, Customer>
    {
        public void ConvertToNewSchemaAndExportExcel(string filePath, string exportDirPath)
        {
            var inputData = GetDosData(filePath);
            var resultData = ConvertToNewSchemaData(inputData);
            FileService<Customer>.ExportDataToExcel(resultData, "Customer", exportDirPath);
        }

        public IEnumerable<Customer> ConvertToNewSchemaData(IEnumerable<DosCustomer> dosData)
        {
            if (dosData == null)
                throw new ArgumentNullException(nameof(dosData));

            var result = dosData
                .Select(x => new Customer
                {
                    CODE = x.BNO,
                    ABBR = x.NAME,
                    CNAME = $"{x.NAME}{x.NAME1}",
                    ADDR = x.ADD,
                    ZIP = x.VOAL,
                    CMPID = x.IDNO,
                    LEVEL = x.QA1,
                    DISCOUNT = x.QA2 / 100,
                    OFFCOUNT = x.G5 / 100,
                    INSTEAD = x.QA3 == "Y" ? "1" : "0",
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

        public IEnumerable<DosCustomer> GetDosData(string filePath)
        {
            return FileService<DosCustomer>.DbfGetData(filePath);
        }
    }
}
