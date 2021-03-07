using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DesktopUI_Library.Models
{
    public class SaleModel
    {
        public LinkedList<SaleDetailModel> SaleDetails { get; set; } = new LinkedList<SaleDetailModel>();
    }
}
