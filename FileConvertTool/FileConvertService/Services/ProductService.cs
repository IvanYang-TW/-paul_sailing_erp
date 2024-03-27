using FileConvertSerivce.Models.Product;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileConvertSerivce.Services
{
    public class ProductService : IDataConvertService<DosProduct, Product>
    {
        public void ConvertOtherDataToNewSchemaAndExportExcel(string filePath, string exportDirPath)
        {
            var inputData = GetDosData(filePath);
            var DosOthersProduct = inputData
                .Where(x => !Regex.IsMatch(x.INO, @"^\d{4}-\d+\s*[A-Z]*"))
                .Select(x => x);
            FileService<DosProduct>.ExportDataToExcel(DosOthersProduct, "DosOthersProduct", exportDirPath);
        }
        public void ConvertToNewSchemaAndExportExcel(string filePath, string exportDirPath)
        {
            var inputData = GetDosData(filePath);
            var resultData = ConvertToNewSchemaData(inputData);
            FileService<Product>.ExportDataToExcel(resultData, "Product", exportDirPath);
        }
        public IEnumerable<Product> ConvertToNewSchemaData(IEnumerable<DosProduct> dosData)
        {
            if (dosData == null)
                throw new ArgumentNullException(nameof(dosData));

            List<string> sizeScope = new List<string> { "S", "M", "L", "XL", "XXL", "3L", "4L", "5L" };

            CultureInfo culture = new CultureInfo("zh-TW");
            culture.DateTimeFormat.Calendar = new TaiwanCalendar();

            // 執行轉換邏輯
            var resultProducts = dosData
                .Where(x => Regex.IsMatch(x.INO, @"^\d{4}-\d+\s*[A-Z]*"))
                .GroupBy(x => Regex.Match(x.INO, @"^\d{4}-\d+").ToString())
                .Select(dosProductItem => new Product
                {
                    CODE = dosProductItem.Key,
                    CNAME = dosProductItem.First().SPEC,
                    CTYPE = ProductTypeClassifier(dosProductItem.Key),
                    COLOR = dosProductItem.First().COLOR,
                    UNIT = dosProductItem.First().UNIT,
                    PRICE = dosProductItem.First().SAFE,
                    SCOST = dosProductItem.First().COST,
                    SCOPE = dosProductItem.First().REMK,
                    INGRED = string.Join(",", GetIngredientList(dosProductItem.First())),
                    GENDER = dosProductItem.First().SEX,
                    ORIGIN = dosProductItem.First().R71,
                    CQTY_01 = dosProductItem.Where(x => x.SIZE == "S").Select(x => x.QTY).FirstOrDefault() ?? 0.00M,
                    CQTY_02 = dosProductItem.Where(x => x.SIZE == "M").Select(x => x.QTY).FirstOrDefault() ?? 0.00M,
                    CQTY_03 = dosProductItem.Where(x => x.SIZE == "L").Select(x => x.QTY).FirstOrDefault() ?? 0.00M,
                    CQTY_04 = dosProductItem.Where(x => x.SIZE == "XL").Select(x => x.QTY).FirstOrDefault() ?? 0.00M,
                    CQTY_05 = dosProductItem.Where(x => x.SIZE == "XXL").Select(x => x.QTY).FirstOrDefault() ?? 0.00M,
                    CQTY_06 = dosProductItem.Where(x => x.SIZE == "3L").Select(x => x.QTY).FirstOrDefault() ?? 0.00M,
                    CQTY_07 = dosProductItem.Where(x => x.SIZE == "4L").Select(x => x.QTY).FirstOrDefault() ?? 0.00M,
                    CQTY_08 = dosProductItem.Where(x => x.SIZE == "5L").Select(x => x.QTY).FirstOrDefault() ?? 0.00M,
                    CQTY_09 = dosProductItem.Where(x => !sizeScope.Contains(x.SIZE)).Sum(x => x.QTY ?? 0.00M),
                    CQTY = dosProductItem.Sum(x => x.QTY ?? 0.00M),
                    TDATE = !string.IsNullOrEmpty(dosProductItem.First().DATE) ? DateTime.Parse(dosProductItem.First().DATE, culture).ToString("yyyy-MM-dd") : null,
                    REMARK = string.Join(",", GetCommentsList(dosProductItem.First()))
                }).OrderBy(x => x.CODE);

            return resultProducts;
        }
        public IEnumerable<DosProduct> GetDosData(string filePath)
        {
            return FileService<DosProduct>.DbfGetData(filePath);
        }

        /// <summary>
        /// 取得備註相關資料並匯出成 csv 檔案
        /// </summary>
        /// <param name="dosProducts"></param>
        /// <param name="exportDirPath"></param>
        public void GetCommentsDataAndExportToCsv(IEnumerable<DosProduct> dosProducts, string exportDirPath)
        {
            List<string> results = new List<string>();
            var dosRemDisResult_01 = dosProducts.Select(x => x.REM1).Distinct().Order();
            var dosRemDisResult_02 = dosProducts.Select(x => x.REM2).Distinct().Order();
            var dosRemDisResult_03 = dosProducts.Select(x => x.REM3).Distinct().Order();
            var dosRemDisResult_04 = dosProducts.Select(x => x.REM4).Distinct().Order();
            var dosRemDisResult_05 = dosProducts.Select(x => x.REM5).Distinct().Order();
            var dosRemDisResult_06 = dosProducts.Select(x => x.REM6).Distinct().Order();
            var dosRemDisResult_07 = dosProducts.Select(x => x.REM7).Distinct().Order();
            results.AddRange(dosRemDisResult_01);
            results.AddRange(dosRemDisResult_02);
            results.AddRange(dosRemDisResult_03);
            results.AddRange(dosRemDisResult_04);
            results.AddRange(dosRemDisResult_05);
            results.AddRange(dosRemDisResult_06);
            results.AddRange(dosRemDisResult_07);
            results = results.Distinct().Order().ToList();
            File.WriteAllText(Path.Combine(exportDirPath, "oldRemDisResult.csv"), string.Join(",\n", results), Encoding.UTF8);

        }

        /// <summary>
        /// 取得成分內容清單
        /// </summary>
        /// <param name="dosProduct"></param>
        /// <returns></returns>
        private List<string> GetIngredientList(DosProduct dosProduct)
        {
            List<string> filterConten = new List<string> { "" };
            List<string> result = new List<string>();
            if (!string.IsNullOrEmpty(dosProduct.REM1) && !string.IsNullOrWhiteSpace(dosProduct.REM1))
                result.Add(dosProduct.REM1);
            if (!string.IsNullOrEmpty(dosProduct.REM2) && !string.IsNullOrWhiteSpace(dosProduct.REM2))
                result.Add(dosProduct.REM2);
            if (!string.IsNullOrEmpty(dosProduct.REM3) && !string.IsNullOrWhiteSpace(dosProduct.REM3))
                result.Add(dosProduct.REM3);
            return result;
        }
        /// <summary>
        /// 取得備註內容清單
        /// </summary>
        /// <param name="dosProduct"></param>
        /// <returns></returns>
        private List<string> GetCommentsList(DosProduct dosProduct)
        {
            List<string> result = new List<string>();
            if (!string.IsNullOrEmpty(dosProduct.REM3) && !string.IsNullOrWhiteSpace(dosProduct.REM3))
                result.Add(dosProduct.REM3);
            if (!string.IsNullOrEmpty(dosProduct.REM4) && !string.IsNullOrWhiteSpace(dosProduct.REM4))
                result.Add(dosProduct.REM4);
            if (!string.IsNullOrEmpty(dosProduct.REM5) && !string.IsNullOrWhiteSpace(dosProduct.REM5))
                result.Add(dosProduct.REM5);
            if (!string.IsNullOrEmpty(dosProduct.REM6) && !string.IsNullOrWhiteSpace(dosProduct.REM6))
                result.Add(dosProduct.REM6);
            if (!string.IsNullOrEmpty(dosProduct.REM7) && !string.IsNullOrWhiteSpace(dosProduct.REM7))
                result.Add(dosProduct.REM7);
            return result;
        }

        private string ProductTypeClassifier(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                throw new ArgumentNullException(nameof(productId));
            }
            bool IsMaterials = Regex.IsMatch(productId, @"^0{3}\d{1}-\d+");
            bool IsFinalProduct = Regex.IsMatch(productId, @"^[1-9]{1}\d{3}-\d+");
            if (IsMaterials)
            {
                return ((int)ProductType.Materials).ToString();
            }
            else if (IsFinalProduct)
            {
                return ((int)ProductType.FinalProduct).ToString();
            }
            else
            {
                return ((int)ProductType.Others).ToString();
            }
        }

        enum ProductType
        {
            FinalProduct = 0,
            Materials = 1,
            Others = 9
        }
    }
}
