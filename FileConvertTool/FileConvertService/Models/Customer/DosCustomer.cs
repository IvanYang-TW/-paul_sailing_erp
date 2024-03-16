using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvertService.Models.Customer
{
    /// <summary>
    /// Dos客戶主檔
    /// </summary>
    public class DosCustomer
    {
        /// <summary>
        /// 流水號
        /// </summary>
        public string NO { get; set; }
        /// <summary>
        /// 客戶編號
        /// </summary>
        public string BNO { get; set; }
        /// <summary>
        /// 公司簡稱
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 公司後贅名
        /// </summary>
        public string NAME1 { get; set; }
        /// <summary>
        /// 負責人
        /// </summary>
        public string BOSS { get; set; }
        /// <summary>
        /// 聯絡人(1)
        /// </summary>
        public string ATTN { get; set; }
        /// <summary>
        /// 聯絡電話(1)
        /// </summary>
        public string TEL { get; set; }
        /// <summary>
        /// 傳真號碼(1)
        /// </summary>
        public string FAX { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string ADD { get; set; }
        /// <summary>
        /// 聯絡電話(2)
        /// </summary>
        public string BTEL { get; set; }
        /// <summary>
        /// 統一編號
        /// </summary>
        public string IDNO { get; set; }

        public string SALE { get; set; }

        public string SNAME { get; set; }
        /// <summary>
        /// 郵遞區號
        /// </summary>
        public string VOAL { get; set; }

        public string AMT { get; set; }

        public string BMT { get; set; }

        public string DA { get; set; }

        public string CMT { get; set; }

        public string DMT { get; set; }

        public decimal G5 { get; set; }

        public string QA1 { get; set; }

        public decimal QA2 { get; set; }

        public string QA3 { get; set; }
    }
}
