using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvertService.Models.Ingredient
{
    /// <summary>
    /// 成分表
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// 成分編號
        /// </summary>
        public string ingredient_id {  get; set; }
        /// <summary>
        /// 成分類別
        /// </summary>
        public string ingredient_category { get; set; }
        /// <summary>
        /// 成分中文名稱
        /// </summary>
        public string name_zh { get; set; }
        /// <summary>
        /// 成分英文名稱
        /// </summary>
        public string name_en { get; set; }
        /// <summary>
        /// 成分描述
        /// </summary>
        public string description { get; set; }
    }
}
