using FileConvertSerivce.Models.Product;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileConvertSerivce.Services
{
    public class ProductService
    {
        /// <summary>
        /// 取得Dos產品資料
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static IEnumerable<DosProduct> GetDosData(string filePath)
        {
            return FileService<DosProduct>.DbfGetData(filePath);
        }
        /// <summary>
        /// 轉換成新系統Schema資料
        /// </summary>
        /// <param name="dosProduct"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<Product> ConvertToNewSchemaData(IEnumerable<DosProduct> dosProduct)
        {
            if (dosProduct == null)
                throw new ArgumentNullException(nameof(dosProduct));

            List<Product> result = new List<Product>();

            // 執行轉換邏輯
            var dosProducts = dosProduct.Where(x=>Regex.IsMatch(x.INO,@"\d{4}-\d{1}\s{1}\w*")).GroupBy(x => x.INO.Substring(0, 6)).ToArray();

            foreach (var dosProductItem in dosProducts)
            {
                var firstDosPro = dosProductItem.FirstOrDefault();
                var product = new Product
                {
                    CODE = dosProductItem.Key,
                    CNAME = firstDosPro.SPEC,
                    COLOR = firstDosPro.COLOR,
                    UNIT = firstDosPro.UNIT,
                    PRICE = firstDosPro.PRIC,
                    SCOST = firstDosPro.COST,
                    GENDER = firstDosPro.SEX,
                    ORIGIN = firstDosPro.R71,
                    CQTY_01 = (int)dosProductItem.Where(x=>x.SIZE=="S").Select(x=>x.QTY).FirstOrDefault(),
                    CQTY_02 = (int)dosProductItem.Where(x=>x.SIZE=="M").Select(x=>x.QTY).FirstOrDefault(),
                    CQTY_03 = (int)dosProductItem.Where(x=>x.SIZE=="L").Select(x=>x.QTY).FirstOrDefault(),
                    CQTY_04 = (int)dosProductItem.Where(x=>x.SIZE=="XL").Select(x=>x.QTY).FirstOrDefault(),
                    CQTY_05 = (int)dosProductItem.Where(x=>x.SIZE=="XXL").Select(x=>x.QTY).FirstOrDefault(),
                    CQTY_06 = (int)dosProductItem.Where(x=>x.SIZE=="2L").Select(x=>x.QTY).FirstOrDefault(),
                    CQTY_07 = (int)dosProductItem.Where(x=>x.SIZE=="3L").Select(x=>x.QTY).FirstOrDefault(),
                    CQTY_08 = (int)dosProductItem.Where(x=>x.SIZE=="4L").Select(x=>x.QTY).FirstOrDefault(),
                    CQTY_09 = (int)dosProductItem.Where(x=>x.SIZE=="5L").Select(x=>x.QTY).FirstOrDefault(),
                    CQTY = (int)dosProductItem.Sum(x=>x.QTY),
                    TDATE = DateTime.Now.ToString("s")
                };
                result.Add(product);
            }

            return result;
        }
        /// <summary>
        /// 轉換成新系統Schema並匯出成Excel
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="exportDirPath"></param>
        public static void ConvertToNewSchemaAndExportExcel(string filePath,string exportDirPath)
        {
            var inputData = GetDosData(filePath);
            var resultData = ConvertToNewSchemaData(inputData);
            FileService<Product>.ExportDataToExcel(resultData,"Product",exportDirPath);
        }
    }
}
