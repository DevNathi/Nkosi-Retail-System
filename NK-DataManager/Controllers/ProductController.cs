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
    //[System.Web.Http.Authorize]
    public class ProductController : ApiController
    {
        
        public ProductModel GetById(int id)
        {
            ProductData product = new ProductData();
            return product.GetProductById(id);
        }

        public List<ProductModel> GetAll()
        {
            ProductData product = new ProductData();

            return product.GetAllProducts();
        }

        public void PostProduct(MiniProductModel model)
        {
            ProductData product = new ProductData();
            product.PostProduct(model);
        }

        public void DeleteProduct(int id)
        {
            ProductData product = new ProductData();
            product.DeleteProduct(id);
        }
    }
}