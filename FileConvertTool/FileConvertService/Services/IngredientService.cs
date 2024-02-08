using FileConvertService.Models.Ingredient;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvertService.Services
{
    public class IngredientService
    {
        /// <summary>
        /// 從Csv檔案取得成分資料
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IEnumerable<Ingredient> GetDataFromCsvFile(string filePath)
        {
            var ingredients = new List<Ingredient>();

            using (var parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(","); // CSV文件使用逗號作為分隔符，你可以根據實際情況調整

                // 跳過表頭
                if (!parser.EndOfData)
                {
                    parser.ReadFields();
                }

                while (!parser.EndOfData)
                {
                    // 讀取CSV文件中的每一行
                    string[] fields = parser.ReadFields();

                    // 解析每一行的數據並建立 Ingredient 對象
                    if (fields.Length >= 4)
                    {
                        var ingredient = new Ingredient
                        {
                            ingredient_id = fields[0],
                            name_zh = fields[1],  
                            name_en = fields[2],  
                            description = fields[3]
                        };

                        ingredients.Add(ingredient);
                    }
                    // 如果 CSV 文件欄位數目不符合預期，可以考慮記錄錯誤或採取其他處理方式
                }
            }

             return ingredients;
        }
    }
}
