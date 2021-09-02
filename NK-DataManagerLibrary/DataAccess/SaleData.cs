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
        public void SaveSale(SaleModel  saleInfor, string cashierId)
        {
            //TODO - Make this better
            //Start filling in the Sale Details model we will save to the database
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            ProductData products = new ProductData();
            var taxRate = ConfigHelper.GetTaxRate();

            foreach (var item in saleInfor.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };

                //Get the information about the product
                var productInfor = products.GetProductById(item.ProductId);

                if(productInfor == null)
                {
                    throw new Exception($"The product Id of {item.ProductId} could not be found in the database");
                }
                detail.PurchasePrice = (productInfor.RetailPrice * detail.Quantity);

                if(productInfor.isTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }
                details.Add(detail);
            }
            //Fill in the available information
            //Create the Sale model

            SaleDBModel sale = new SaleDBModel
            {
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax),
                CashierId = cashierId
            };
            sale.Total = sale.SubTotal + sale.Tax;

            using (SqlDataAccess sql = new SqlDataAccess())
            {
                try
                {
                    //Save the sale model
                    sql.StartTransaction("NK-DbConnection");
                    sql.SaveDataTransaction("dbo.spSale_Insert", sale);

                    //Get Id from the sale model
                    sale.Id = sql.LoadDataTransaction<int, dynamic>("dbo.spSale_LookUp", new { CashierId = sale.CashierId, sale.SaleDate }).FirstOrDefault();
                    //Finish filling in the sales detail model

                    foreach (var item in details)
                    {
                        item.SaleId = sale.Id;
                        //Save the sale details models
                        sql.SaveDataTransaction("dbo.spSaleDetail_Insert", item);
                    }
                    sql.CommitTransation();
                }
                catch
                {
                    sql.RollBackTransaction();
                    throw;
                }
            }

        }
    }
}
