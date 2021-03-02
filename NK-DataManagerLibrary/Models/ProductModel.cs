using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DataManagerLibrary.Models
{
    public class ProductModel
    {

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal RetailPrice { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
        public bool IsTaxable { get; set; }

    }

    public class MiniProductModel
    {
        public string ProductName { get; set; }
        //Money is the data type of RetailPrice
        public string RetailPrice { get; set; }
        public string Description { get; set; }
    }
}
