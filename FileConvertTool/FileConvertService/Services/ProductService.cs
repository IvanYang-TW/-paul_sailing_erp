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
    public class ProductService : IDataConvertService<DosProduct, Product>
    {
        /// <summary>
        /// 取得Dos產品資料
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IEnumerable<DosProduct> GetDosData(string filePath)
        {
            return FileService<DosProduct>.DbfGetData(filePath);
        }
        /// <summary>
        /// 轉換成新系統Schema資料
        /// </summary>
        /// <param name="dosProduct"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Product> ConvertToNewSchemaData(IEnumerable<DosProduct> dosProduct)
        {
            if (dosProduct == null)
                throw new ArgumentNullException(nameof(dosProduct));

            List<string> sizeScope = new List<string> { "S","M","L","XL","XXL","3L","4L","5L" };

            // 執行轉換邏輯
            var dosProducts = dosProduct
                .Where(x => Regex.IsMatch(x.INO, @"^\d{4}-\d+\s*[A-Z]*"))
                .GroupBy(x => Regex.Match(x.INO, @"^\d{4}-\d+").ToString())
                .Select(dosProductItem => new Product
                {
                    CODE = dosProductItem.Key,
                    CNAME = dosProductItem.First().SPEC,
                    COLOR = dosProductItem.First().COLOR,
                    UNIT = dosProductItem.First().UNIT,
                    PRICE = dosProductItem.First().PRIC,
                    SCOST = dosProductItem.First().COST,
                    GENDER = dosProductItem.First().SEX,
                    ORIGIN = dosProductItem.First().R71,
                    CQTY_01 = (int)dosProductItem.Where(x => x.SIZE == "S").Select(x => x.QTY).FirstOrDefault(),
                    CQTY_02 = (int)dosProductItem.Where(x => x.SIZE == "M").Select(x => x.QTY).FirstOrDefault(),
                    CQTY_03 = (int)dosProductItem.Where(x => x.SIZE == "L").Select(x => x.QTY).FirstOrDefault(),
                    CQTY_04 = (int)dosProductItem.Where(x => x.SIZE == "XL").Select(x => x.QTY).FirstOrDefault(),
                    CQTY_05 = (int)dosProductItem.Where(x => x.SIZE == "XXL").Select(x => x.QTY).FirstOrDefault(),
                    CQTY_06 = (int)dosProductItem.Where(x => x.SIZE == "3L").Select(x => x.QTY).FirstOrDefault(),
                    CQTY_07 = (int)dosProductItem.Where(x => x.SIZE == "4L").Select(x => x.QTY).FirstOrDefault(),
                    CQTY_08 = (int)dosProductItem.Where(x => x.SIZE == "5L").Select(x => x.QTY).FirstOrDefault(),
                    CQTY_09 = (int)dosProductItem.Where(x => !sizeScope.Contains(x.SIZE)).Sum(x => x.QTY),
                    CQTY = (int)dosProductItem.Sum(x => x.QTY),
                    TDATE = DateTime.Now.ToString("s")
                }).OrderBy(x=>x.CODE);

            return dosProducts;
        }
        /// <summary>
        /// 轉換成新系統Schema並匯出成Excel
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="exportDirPath"></param>
        public void ConvertToNewSchemaAndExportExcel(string filePath, string exportDirPath)
        {
            var inputData = GetDosData(filePath);
            var resultData = ConvertToNewSchemaData(inputData);
            FileService<Product>.ExportDataToExcel(resultData, "Product", exportDirPath);
        }
    }
}
