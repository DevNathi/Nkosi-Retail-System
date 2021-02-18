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
    public class SaleController : ApiController
    {
        // GET: Sale
        
           
            public SaleModel GetById(int id)
            {
                SaleData sale = new SaleData();
                return sale.GetSaleById(id).First();
            }

            public List<SaleModel> GetAll()
            {
                SaleData sale = new SaleData();

                return sale.GetAllSales();
            }

            public void PostProduct(MiniSaleModel model)
            {
                SaleData sale = new SaleData();
                sale.PostSale(model);
            }

            public void DeleteProduct(int id)
            {
                SaleData sale = new SaleData();
                sale.DeleteSale(id);
            }
     }
}