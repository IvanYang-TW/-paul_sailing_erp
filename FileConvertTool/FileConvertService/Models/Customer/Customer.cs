using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvertService.Models.Customer
{
    /// <summary>
    /// 客戶主檔
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// 客戶編號
        /// </summary>
        public string CODE { get; set; }
        /// <summary>
        /// 公司簡稱
        /// </summary>
        public string ABBR { get; set; }
        /// <summary>
        /// 公司名稱
        /// </summary>
        public string CNAME { get; set; }
        /// <summary>
        /// 類別編號【CUSTCLAS:CODE】
        /// </summary>
        public string CLAS { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string ADDR { get; set; }
        /// <summary>
        /// 郵遞區號
        /// </summary>
        public string ZIP { get; set; }
        /// <summary>
        /// 統一編號
        /// </summary>
        public string CMPID { get; set; }
        /// <summary>
        /// 等級
        /// </summary>
        public string LEVEL { get; set; }
        /// <summary>
        /// 折數(%)
        /// </summary>
        public decimal DISCOUNT { get; set; }
        /// <summary>
        /// 扣率(%)
        /// </summary>
        public decimal OFFCOUNT { get; set; }
        /// <summary>
        /// 代收[0:否, 1:是]
        /// </summary>
        public string INSTEAD { get; set; }
        /// <summary>
        /// 負責人
        /// </summary>
        public string BOSS { get; set; }
        /// <summary>
        /// 聯絡電話(1)
        /// </summary>
        public string TEL1 { get; set; }
        /// <summary>
        /// 聯絡電話(2)
        /// </summary>
        public string TEL2 { get; set; }
        /// <summary>
        /// 傳真號碼(1)
        /// </summary>
        public string FAX1 { get; set; }
        /// <summary>
        /// 傳真號碼(2)
        /// </summary>
        public string FAX2 { get; set; }
        /// <summary>
        /// 聯絡人(1)
        /// </summary>
        public string CONTACT1 { get; set; }
        /// <summary>
        /// 聯絡人(2)
        /// </summary>
        public string CONTACT2 { get; set; }
        /// <summary>
        /// 行動電話(1)
        /// </summary>
        public string MOBILE1 { get; set; }
        /// <summary>
        /// 行動電話(2)
        /// </summary>
        public string MOBILE2 { get; set; }
        /// <summary>
        /// 月結帳日[空白, 01 - 31]
        /// </summary>
        public string BILDAY { get; set; }
        /// <summary>
        /// 月請款日[空白, 01 - 31]
        /// </summary>
        public string SNDDAY { get; set; }
        /// <summary>
        /// 額度提醒[0:否, 1:是]
        /// </summary>
        public string CRTLCDS { get; set; }
        /// <summary>
        /// 信用額度
        /// </summary>
        public decimal CREDITS { get; set; }
        /// <summary>
        /// 開帳應收
        /// </summary>
        public decimal FRCVBIL { get; set; }
        /// <summary>
        /// 未收帳款
        /// </summary>
        public decimal CRCVBIL { get; set; }
        /// <summary>
        /// 型錄份數
        /// </summary>
        public string CATALOG { get; set; }
        /// <summary>
        /// 異動日期
        /// </summary>
        public string TDATE { get; set; }
        /// <summary>
        /// 備註(1)
        /// </summary>
        public string REMARK1 { get; set; }
        /// <summary>
        /// 備註(2)
        /// </summary>
        public string REMARK2 { get; set; }
        /// <summary>
        /// 首次建檔
        /// </summary>
        public string RECFST { get; set; }
        /// <summary>
        /// 最後編修
        /// </summary>
        public string RECLST { get; set; }
    }
}
