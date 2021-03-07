
using Microsoft.AspNet.Identity;
using NK_DataManager.Models;
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
            public void Post(SaleModel sale)
            {

            SaleData data = new SaleData();
            string userId = RequestContext.Principal.Identity.GetUserId();

            data.SaveSale(sale, userId);
            

            }

     }
}