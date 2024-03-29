﻿using System;
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
        public string? CLAS { get; set; }
        /// <summary>
        /// 色系編號
        /// </summary>
        public string? CSYS { get; set; }
        /// <summary>
        /// 品牌編號
        /// </summary>
        public string? BRAD { get; set; }
        /// <summary>
        /// 客戶編號
        /// </summary>
        public string? CUST { get; set; }
        /// <summary>
        /// 顏色
        /// </summary>
        public string? COLOR { get; set; }
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
        public string? PICTURE { get; set; }
        /// <summary>
        /// 尺寸範圍
        /// </summary>
        public string? SCOPE { get; set; }
        /// <summary>
        /// 材質成分
        /// </summary>
        public string? INGRED { get; set; }
        /// <summary>
        /// 洗滌警語
        /// </summary>
        public string? WASH { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public string? GENDER { get; set; }
        /// <summary>
        /// 產地
        /// </summary>
        public string? ORIGIN { get; set; }
        /// <summary>
        /// 季別
        /// </summary>
        public string? SEASON { get; set; }
        /// <summary>
        /// 存放位置
        /// </summary>
        public string? POSITION { get; set; }
        /// <summary>
        /// 產地批號
        /// </summary>
        public string? MBATCODE { get; set; }
        /// <summary>
        /// 庫存量(S)
        /// </summary>
        public decimal CQTY_01 { get; set; }
        /// <summary>
        /// 庫存量(M)
        /// </summary>
        public decimal CQTY_02 { get; set; }
        /// <summary>
        /// 庫存量(L)
        /// </summary>
        public decimal CQTY_03 { get; set; }
        /// <summary>
        /// 庫存量(XL)
        /// </summary>
        public decimal CQTY_04 { get; set; }
        /// <summary>
        /// 庫存量(XXL)
        /// </summary>
        public decimal CQTY_05 { get; set; }
        /// <summary>
        /// 庫存量(3L)
        /// </summary>
        public decimal CQTY_06 { get; set; }
        /// <summary>
        /// 庫存量(4L)
        /// </summary>
        public decimal CQTY_07 { get; set; }
        /// <summary>
        /// 庫存量(5L)
        /// </summary>
        public decimal CQTY_08 { get; set; }
        /// <summary>
        /// 庫存量(EXT)
        /// </summary>
        public decimal CQTY_09 { get; set; }
        /// <summary>
        /// 庫存總量
        /// </summary>
        public decimal CQTY { get; set; }
        /// <summary>
        /// EXT尺碼
        /// </summary>
        public string? EXTSIZE { get; set; }
        /// <summary>
        /// 異動日期
        /// </summary>
        public string? TDATE { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? REMARK { get; set; }
        /// <summary>
        /// 首次建檔
        /// </summary>
        public string? RECFST { get; set; }
        /// <summary>
        /// 最後編修
        /// </summary>
        public string? RECLST { get; set; }

    }
}
