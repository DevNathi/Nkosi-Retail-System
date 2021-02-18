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
    public class SaleDetailsController : ApiController
    {
        public SaleDetailsModel GetById(int id)
        {
            SaleDetailsData saledetails = new SaleDetailsData();
            return saledetails.GetSaleDetailsById(id).First();
        }

        public List<SaleDetailsModel> GetAll()
        {
            SaleDetailsData saledetails = new SaleDetailsData();

            return saledetails.GetAllSalesDetails();
        }

        public void PostSalesDetails(MiniSaleDetailsModel model)
        {
            SaleDetailsData saledetails = new SaleDetailsData();
            saledetails.PostSaledetails(model);
        }

       
    }
}