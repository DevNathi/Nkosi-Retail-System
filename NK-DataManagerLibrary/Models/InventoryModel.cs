using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DataManagerLibrary.Models
{
    public class InventoryModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        //Money is the datatype for PurchasePrice
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
    }


    public class MiniInventoryModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        //Money is the datatype for PurchasePrice
        public decimal PurchasePrice { get; set; }
    }
}
