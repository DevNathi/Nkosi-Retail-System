using NK_DataManagerLibrary.Internal.DataAccess;
using NK_DataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DataManagerLibrary.DataAccess
{
    public class SaleDetailsData
    {

        public List<SaleDetailsModel> GetSaleDetailsById(int Id)
        {
            var p = new { Id = Id };

            SqlDataAccess sql = new SqlDataAccess();
            var output = sql.LoadData<SaleDetailsModel, dynamic>("dbo.spSaleDetailsLookUp", p, "NK-DbConnection");
            return output;
        }

        public List<SaleDetailsModel> GetAllSalesDetails()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<SaleDetailsModel, dynamic>("dbo.spSalesDetailsLookUp", new { }, "NK-DbConnection");
            return output;
        }

        public void PostSaledetails(MiniSaleDetailsModel product)
        {

            SqlDataAccess sql = new SqlDataAccess();
            sql.Save<MiniSaleDetailsModel>("dbo.spSaleDetailsInsert", product, "NK-DbConnection");

        }
    }
}
