using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvertService.Models.Ingredient
{
    /// <summary>
    /// 成分關聯表
    /// </summary>
    public class ProductIngredient
    {
        /// <summary>
        /// 產品編號
        /// </summary>
        public string product_id { get; set; }
        /// <summary>
        /// 成分編號
        /// </summary>
        public string ingredient_id { get; set;}
        /// <summary>
        /// 產品中成分的百分比
        /// </summary>
        public decimal percentage { get; set; }
        /// <summary>
        /// 成分的數量
        /// </summary>
        public decimal quantity { get; set; }

    }
}
