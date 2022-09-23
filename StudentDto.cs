using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReceiptPrinter
{
    public class StudentDto
    {
        /// <summary>
        ///     班级
        /// </summary>
        public string Cls { get; set; }

        /// <summary>
        ///     姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///     年
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        ///     月
        /// </summary>
        public string Month { get; set; }
        /// <summary>
        ///     日
        /// </summary>
        public string Day { get; set; }
        /// <summary>
        ///     保教费
        /// </summary>
        public string Fee1 { get; set; }
        /// <summary>
        ///     住宿费
        /// </summary>
        public string Fee2 { get; set; }
        /// <summary>
        ///     伙食费
        /// </summary>
        public string Fee3 { get; set; }
        /// <summary>
        ///     金额
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        ///     开票人
        /// </summary>
        public decimal User { get; set; }
    }
}
