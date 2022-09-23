using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReceiptPrinter
{
    public class PrintInfo
    {
        public string Name { get; set; }
        public string Cls { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Fee1 { get; set; }
        public string Fee2 { get; set; }
        public string Fee3 { get; set; }
        public decimal Price { get; set; }
        public string User { get; set; }
        public int PriceFen
        {
            get
            {
                return Convert.ToInt32(Price * 100);
            }
        }
        public string Wan
        {
            get
            {
                return ConvertToChinese(PriceFen % 10000000 / 1000000);
            }
        }
        public string Qian
        {
            get
            {
                return ConvertToChinese(PriceFen % 1000000/100000);
            }
        }
        public string Bai
        {
            get
            {
                return ConvertToChinese(PriceFen % 100000/10000);
            }
        }
        public string Shi
        {
            get
            {
                return ConvertToChinese(PriceFen % 10000/1000);
            }
        }
        public string Yuan
        {
            get
            {
                return ConvertToChinese(PriceFen % 1000/100);
            }
        }
        public string Jiao
        {
            get
            {
                return ConvertToChinese(PriceFen % 100/10);
            }
        }
        public string Fen
        {
            get
            {
                return ConvertToChinese(PriceFen % 10);
            }
        }
        string ConvertToChinese(int id)
        {
            string[] DX_SZ = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖", "拾" };
            return DX_SZ[id];
        }
    }
}
