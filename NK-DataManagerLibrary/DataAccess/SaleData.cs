using NK_DataManagerLibrary.Internal.DataAccess;
using NK_DataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DataManagerLibrary.DataAccess
{
    public class SaleData
    {
        public List<SaleModel> GetSaleById(int Id)
        {
            var p = new { Id = Id };

            SqlDataAccess sql = new SqlDataAccess();
            var output = sql.LoadData<SaleModel, dynamic>("dbo.spSaleLookUp", p, "NK-DbConnection");
            return output;
        }

        public List<SaleModel> GetAllSales()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<SaleModel, dynamic>("dbo.spSalesLookUp", new { }, "NK-DbConnection");
            return output;
        }

        public void PostSale(MiniSaleModel product)
        {

            SqlDataAccess sql = new SqlDataAccess();
            sql.Save<MiniSaleModel>("dbo.spSaleInsert", product, "NK-DbConnection");

        }

        public void DeleteSale(int id)
        {
            var p = new { Id = id };
            SqlDataAccess sql = new SqlDataAccess();
            sql.Save("dbo.spSaleRemove", p, "NK-DbConnection");
        }
    }
}
