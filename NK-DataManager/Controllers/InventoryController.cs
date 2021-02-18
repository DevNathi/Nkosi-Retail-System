using NK_DataManagerLibrary.DataAccess;
using NK_DataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace NK_DataManager.Controllers
{
    public class InventoryController : ApiController
    {
        // GET: Inventory
        public InventoryModel GetById(int id)
        {
            InventoryData product = new InventoryData();
            return product.GetInventorytById(id).First();
        }

        public List<InventoryModel> GetAll()
        {
            InventoryData product = new InventoryData();

            return product.GetAllInventories();
        }

        public void PostProduct(MiniInventoryModel model)
        {
            InventoryData product = new InventoryData();
            product.PostInventory(model);
        }
    }
}