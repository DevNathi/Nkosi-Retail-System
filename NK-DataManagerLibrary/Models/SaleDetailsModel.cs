using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DataManagerLibrary.Models
{
    public class SaleDetailsModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Quantity { get; set; }
        //PurchasePrice and Tax have datatype Money
        public string PurchasePrice { get; set; }
        public string Tax { get; set; }
    }

    public class MiniSaleDetailsModel
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Quantity { get; set; }
        //PurchasePrice and Tax have datatype Money
        public string PurchasePrice { get; set; }
        public string Tax { get; set; }
    }
}
