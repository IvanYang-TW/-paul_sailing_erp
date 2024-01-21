using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvertSerivce.Models.Product
{
    /// <summary>
    /// Dos系統_產品主檔
    /// </summary>
    public class DosProduct
    {
        /// <summary>
        /// 產品編號
        /// </summary>
        public string INO { get; set; }
        /// <summary>
        /// 產品名稱
        /// </summary>
        public string SPEC { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        public string UNIT { get; set; }
        /// <summary>
        /// 顏色
        /// </summary>
        public string COLOR { get; set; }
        /// <summary>
        /// 尺寸
        /// </summary>
        public string SIZE { get; set; }
        /// <summary>
        /// 售價
        /// </summary>
        public decimal PRIC { get; set; }
        /// <summary>
        /// 標準成本
        /// </summary>
        public decimal COST { get; set; }
        /// <summary>
        /// 庫存量
        /// </summary>
        public decimal QTY { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        public string DATE { get; set; }
        /// <summary>
        /// 尺寸範圍
        /// </summary>
        public string REMK { get; set; }
        /// <summary>
        /// 定價
        /// </summary>
        public decimal SAFE { get; set; }
        /// <summary>
        /// 材質成分/備註
        /// </summary>
        public string REM1 { get; set; }
        /// <summary>
        /// 材質成分/備註
        /// </summary>
        public string REM2 { get; set; }
        /// <summary>
        /// 材質成分/備註
        /// </summary>
        public string REM3 { get; set; }
        /// <summary>
        /// 材質成分/備註
        /// </summary>
        public string REM4 { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public string SEX { get; set; }
        /// <summary>
        /// 產地
        /// </summary>
        public string R71 { get; set; }
        /// <summary>
        /// 材質成分/備註
        /// </summary>
        public string REM5 { get; set; }
        /// <summary>
        /// 材質成分/備註
        /// </summary>
        public string REM6 { get; set; }
        /// <summary>
        /// 材質成分/備註
        /// </summary>
        public string REM7 { get; set; }
    }
}
