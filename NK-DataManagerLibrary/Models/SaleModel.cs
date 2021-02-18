using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DataManagerLibrary.Models
{
    public class SaleModel
    {
        public int Id { get; set; }
        public string CashierId { get; set; }
        public DateTime SaleDate { get; set; }
        //Subtotal,Total and Tax have datatype Money
        public string SubTotal { get; set; }
        public string Tax { get; set; }
        public string Total { get; set; }
    }

    public class MiniSaleModel
    {
        public string CashierId { get; set; }
        public DateTime SaleDate { get; set; }
        //Subtotal,Total and Tax have datatype Money
        public string SubTotal { get; set; }
        public string Tax { get; set; }
        public string Total { get; set; }
    }
}
