using Caliburn.Micro;
using NK_DesktopUI_Library.Api;
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

        public SalesViewModel(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;
           
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

        private BindingList<ProductsModel> _cart;

        public BindingList<ProductsModel> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }
        private int _itemQuality;

        public int ItemQuality
        {
            get { return _itemQuality; }
            set
            {
                _itemQuality = value;
                NotifyOfPropertyChange(() => ItemQuality);
            }
        }

        public string Tax
        {
            get
            {
                //TODO - Replace with calculation for subtotal
                return "15%";
            }

        }

        public string SubTotal
        {
            get
            {
                //TODO - Replace with calculation for subtotal
                return "R0.00";
            }

        }

        public string Total
        {
            get
            {
                //TODO - Replace with calculation for subtotal
                return "R0.00";
            }

        }


        public bool CanAddToCart
        {
            get
            {
                bool output = false;

                //Make sure something is selected
                //Makre sure there is an item quality
                return output;
            }
        }
        public void AddToCart()
        {

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
