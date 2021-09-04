using NK_DataManagerLibrary.DataAccess;
using NK_DataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace NK_DataManager.Controllers
{
    [Authorize]
    public class InventoryController : ApiController
    {
        [Authorize(Roles = "Manager,Admin")]
        public List<InventoryModel> Get()
        {
            InventoryData data = new InventoryData();
            return data.GetInventory();
        }
        [Authorize(Roles = "Admin")]
        public void Post(InventoryModel item)
        {
            InventoryData data = new InventoryData();
            data.saveInventoryRecord(item);
        }
    }
}