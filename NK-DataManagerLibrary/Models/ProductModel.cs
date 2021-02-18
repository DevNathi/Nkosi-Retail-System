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
        //Money is the data type of RetailPrice
        public string RetailPrice { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModified { get; set; }
    }

    public class MiniProductModel
    {
        public string ProductName { get; set; }
        //Money is the data type of RetailPrice
        public string RetailPrice { get; set; }
        public string Description { get; set; }
    }
}
