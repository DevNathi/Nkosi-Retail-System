using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DesktopUI_Library.Models
{
    public class ProductsModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal RetailPrice { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
    }
}
