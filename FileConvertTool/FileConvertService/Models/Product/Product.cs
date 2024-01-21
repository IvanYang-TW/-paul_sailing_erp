using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvertSerivce.Models.Product
{
    /// <summary>
    /// 產品主檔
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 產品編號
        /// </summary>
        public string CODE { get; set; }
        /// <summary>
        /// 產品名稱
        /// </summary>
        public string CNAME { get; set; }
        /// <summary>
        /// 產品類型
        /// </summary>
        public string CTYPE { get; set; }
        /// <summary>
        /// 類別編號
        /// </summary>
        public string CLAS { get; set; }
        /// <summary>
        /// 色系編號
        /// </summary>
        public string CSYS { get; set; }
        /// <summary>
        /// 品牌編號
        /// </summary>
        public string BRAD { get; set; }
        /// <summary>
        /// 客戶編號
        /// </summary>
        public string CUST { get; set; }
        /// <summary>
        /// 顏色
        /// </summary>
        public string COLOR { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        public string UNIT { get; set; }
        /// <summary>
        /// 定價
        /// </summary>
        public decimal PRICE { get; set; }
        /// <summary>
        /// 標準成本
        /// </summary>
        public decimal SCOST { get; set; }
        /// <summary>
        /// 平均成本
        /// </summary>
        public decimal CCOST { get; set; } 
        /// <summary>
        /// 圖檔位置
        /// </summary>
        public string PICTURE { get; set; }
        /// <summary>
        /// 尺寸範圍
        /// </summary>
        public string SCOPE { get; set; }
        /// <summary>
        /// 材質成分
        /// </summary>
        public string INGRED { get; set; }
        /// <summary>
        /// 洗滌警語
        /// </summary>
        public string WASH { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public string GENDER { get; set; }
        /// <summary>
        /// 產地
        /// </summary>
        public string ORIGIN { get; set; }
        /// <summary>
        /// 季別
        /// </summary>
        public string SEASON { get; set; }
        /// <summary>
        /// 存放位置
        /// </summary>
        public string POSITION { get; set; }
        /// <summary>
        /// 產地批號
        /// </summary>
        public string MBATCODE { get; set; }
        /// <summary>
        /// 庫存量(S)
        /// </summary>
        public int CQTY_01 { get; set; }
        /// <summary>
        /// 庫存量(M)
        /// </summary>
        public int CQTY_02 { get; set; }
        /// <summary>
        /// 庫存量(L)
        /// </summary>
        public int CQTY_03 { get; set; }
        /// <summary>
        /// 庫存量(XL)
        /// </summary>
        public int CQTY_04 { get; set; }
        /// <summary>
        /// 庫存量(XXL)
        /// </summary>
        public int CQTY_05 { get; set; }
        /// <summary>
        /// 庫存量(3L)
        /// </summary>
        public int CQTY_06 { get; set; }
        /// <summary>
        /// 庫存量(4L)
        /// </summary>
        public int CQTY_07 { get; set; }
        /// <summary>
        /// 庫存量(5L)
        /// </summary>
        public int CQTY_08 { get; set; }
        /// <summary>
        /// 庫存量(EXT)
        /// </summary>
        public int CQTY_09 { get; set; }
        /// <summary>
        /// 庫存總量
        /// </summary>
        public int CQTY { get; set; }
        /// <summary>
        /// EXT尺碼
        /// </summary>
        public string EXTSIZE { get; set; }
        /// <summary>
        /// 異動日期
        /// </summary>
        public string TDATE { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string REMARK { get; set; }
        /// <summary>
        /// 首次建檔
        /// </summary>
        public string RECFST { get; set; }
        /// <summary>
        /// 最後編修
        /// </summary>
        public string RECLST { get; set; }

        /// <summary>
        /// 新增庫存量
        /// </summary>
        /// <param name="qty">庫存量數組</param>
        public void AddQty(int[] qty)
        {
            if (qty == null || qty.Length == 9)
            {
                CQTY_01 = qty[0];
                CQTY_02 = qty[1];
                CQTY_03 = qty[2];
                CQTY_04 = qty[3];
                CQTY_05 = qty[4];
                CQTY_06 = qty[5];
                CQTY_07 = qty[6];
                CQTY_08 = qty[7];
                CQTY_09 = qty[8];
                CQTY = qty.Sum();
            }
            else
            {
                throw new Exception("輸入庫存量數組不符合");
            }
        }
    }
}
