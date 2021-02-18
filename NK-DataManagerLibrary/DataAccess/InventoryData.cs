using NK_DataManagerLibrary.Internal.DataAccess;
using NK_DataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DataManagerLibrary.DataAccess
{
    public class InventoryData
    {
        public List<InventoryModel> GetInventorytById(int Id)
        {
            var p = new { Id = Id };

            SqlDataAccess sql = new SqlDataAccess();
            var output = sql.LoadData<InventoryModel, dynamic>("dbo.spInventoryLookUp", p, "NK-DbConnection");
            return output;
        }

        public List<InventoryModel> GetAllInventories()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<InventoryModel, dynamic>("dbo.spInventoriesLookUp", new { }, "NK-DbConnection");
            return output;
        }

        public void PostInventory(MiniInventoryModel inventory)
        {

            SqlDataAccess sql = new SqlDataAccess();
            sql.Save<MiniInventoryModel>("dbo.spInventoryInsert", inventory, "NK-DbConnection");

        }
    }
}
