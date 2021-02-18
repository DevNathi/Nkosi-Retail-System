using NK_DataManagerLibrary.Internal.DataAccess;
using NK_DataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DataManagerLibrary.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetProductById(int Id)
        {
            var p = new { Id = Id };

            SqlDataAccess sql = new SqlDataAccess();
            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProductLookUp", p, "NK-DbConnection");
            return output;
        }
        
        public List<ProductModel> GetAllProducts()
        {
            SqlDataAccess sql = new SqlDataAccess();
           
            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProductsLookUp", new { }, "NK-DbConnection");
            return output;
        }

        public void PostProduct(MiniProductModel product)
        {

            SqlDataAccess sql = new SqlDataAccess();
            sql.Save<MiniProductModel>("dbo.spProductInsert", product, "NK-DbConnection");

        }

        public void DeleteProduct(int id)
        {
            var p = new { Id = id};
            SqlDataAccess sql = new SqlDataAccess();
            sql.Save("dbo.spProductRemove", p, "NK-DbConnection");
        }
    }
}
