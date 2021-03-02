using Caliburn.Micro;
using NK_DesktopUI_Library.Api;
using NK_DesktopUI_Library.Helpers;
using NK_DesktopUI_Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        IProductEndpoint _productEndpoint;
        IConfigHelper _configHelper;

        public SalesViewModel(IProductEndpoint productEndpoint, IConfigHelper configHelper)
        {
            _productEndpoint = productEndpoint;
            _configHelper = configHelper;
           
        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }
        private async Task LoadProducts()
        {
            var productList = await _productEndpoint.GetAllProducts();
            Products = new BindingList<ProductsModel>(productList);
        }

        private BindingList<ProductsModel> _products;
        public BindingList<ProductsModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private ProductsModel _selectedProduct;
        public ProductsModel SelectedProduct
        {
            get { return _selectedProduct; }
            set 
            {
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();
        public BindingList<CartItemModel> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        private int _itemQuality = 1;
        public int ItemQuality
        {
            get { return _itemQuality; }
            set
            {
                _itemQuality = value;
                NotifyOfPropertyChange(() => ItemQuality);
                NotifyOfPropertyChange(() => CanAddToCart);

            }
        }


        public string Tax
        {
            get
            {
                //TODO - Replace with calculation for subtotal
              //TODO - fix notify of prop change in TAX
                return CalculateTax().ToString("C");
            }

        }
        private decimal CalculateTax()
        {
            decimal taxAmount = 0;
            decimal taxRate = _configHelper.GetTaxRate();
            foreach (var item in Cart)
            {
                if (item.Product.IsTaxable)
                {
                    taxAmount += (item.Product.RetailPrice * item.QauntityInCart * taxRate);
                }
            }
            return taxAmount;
        }
        public string SubTotal
        {
            get
            {
                //TODO - Replace with calculation for subtotal
                return CalculateSubTotal().ToString("C");
            }

        }
        private decimal CalculateSubTotal()
        {
            decimal subTotal = 0;
            foreach (var item in Cart)
            {
                subTotal += (item.Product.RetailPrice * item.QauntityInCart);
            }
            return subTotal;
        }
        public string Total
        {
            get
            {
                //TODO - Replace with calculation for subtotal
                decimal total = CalculateSubTotal() + CalculateTax();
                return total.ToString("C");
            }

        }


        public bool CanAddToCart
        {
            get
            {
                bool output = false;

                //Make sure something is selected
                //Makre sure there is an item quality
                if(SelectedProduct?.QuantityInStock >= ItemQuality)
                {
                    if(ItemQuality > 0)
                    {
                        output = true;
                    }
                    
                }
                else
                {
                     output = false;
                }
                return output;
            }
        }
        public void AddToCart()
        {
            CartItemModel existingaItem = Cart.FirstOrDefault(x => x.Product == SelectedProduct);

            if(existingaItem != null)
            {
                existingaItem.QauntityInCart += ItemQuality;
                
                //Hack - Should add a better way to refresh the cart display
                Cart.Remove(existingaItem);
                Cart.Add(existingaItem); 
            }
            else
            {
                CartItemModel Item = new CartItemModel
                {
                    Product = SelectedProduct,
                    QauntityInCart = ItemQuality
                };
                Cart.Add(Item);
               
            }
            
            SelectedProduct.QuantityInStock -= ItemQuality;
            ItemQuality = 1;

            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);



        }
        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                //Make sure something is selected
                return output;
            }
        }
        public void RemoveFromCart()
        {

            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
        }
        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                //Make sure there something in the shopping cart
                return output;
            }
        }
        public void CheckOut()
        {

        }

    }
}
