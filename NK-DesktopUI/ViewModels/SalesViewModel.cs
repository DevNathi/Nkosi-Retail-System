using AutoMapper;
using Caliburn.Micro;
using NK_DesktopUI.Models;
using NK_DesktopUI_Library.Api;
using NK_DesktopUI_Library.Helpers;
using NK_DesktopUI_Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NK_DesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        IProductEndpoint _productEndpoint;
        ISaleEndpoint _saleEndpoint;
        IConfigHelper _configHelper;
        IMapper _mapper;
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;

        public SalesViewModel(IProductEndpoint productEndpoint, IConfigHelper configHelper, 
            ISaleEndpoint saleEndpoint, IMapper mapper,StatusInfoViewModel status,IWindowManager window)
        {
            _productEndpoint = productEndpoint;
            _saleEndpoint = saleEndpoint;
            _configHelper = configHelper;
            _mapper = mapper;
            _status = status;
            _window = window;
        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            try
            {
                await LoadProducts();
            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";

                if (ex.Message == "Unauthorized")
                {
                    _status.UpdateMessage("Unauthorized Access", "You do not have permission to access this process");
                    _window.ShowDialog(_status, null, settings);
                }
                else
                {
                    _status.UpdateMessage("Fatal Exception", ex.Message);
                    _window.ShowDialog(_status, null, settings);
                }
                TryClose();
                //handle the exception for the View Load not to break or stop application
            }
        }
        private async Task LoadProducts()
        {
            var productList = await _productEndpoint.GetAllProducts();
            var products = _mapper.Map<List<ProductDisplayModel>>(productList);
            Products = new BindingList<ProductDisplayModel>(products);
        }

        private BindingList<ProductDisplayModel> _products;
        public BindingList<ProductDisplayModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private ProductDisplayModel _selectedProduct;
        public ProductDisplayModel SelectedProduct
        {
            get { return _selectedProduct; }
            set 
            {
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        private async Task ResetSalesViewModel()
        {
            Cart = new BindingList<CartItemDisplayModel>();
            await LoadProducts();


            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
            NotifyOfPropertyChange(() => CanCheckOut);
        }
        private CartItemDisplayModel _selectedCartItem;
        public CartItemDisplayModel SelectedCartItem
        {
            get { return _selectedCartItem; }
            set
            {
                _selectedCartItem = value;
                NotifyOfPropertyChange(() => SelectedCartItem);
                NotifyOfPropertyChange(() => CanRemoveFromCart);
            }
        }

        private BindingList<CartItemDisplayModel> _cart = new BindingList<CartItemDisplayModel>();
        public BindingList<CartItemDisplayModel> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        private int _itemQuantity = 1;
        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);

            }
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

            //TODO - come back to sinplify this
            //Cart.Where(x => x.Product.isTaxable)
            //    .Sum(x => x.Product.RetailPrice * x.QauntityInCart * taxRate);
            foreach (var item in Cart)
            {
                if (item.Product.isTaxable)
                {
                    taxAmount += (item.Product.RetailPrice * item.QauntityInCart * taxRate);
                }
            }
            return taxAmount;
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
                if(SelectedProduct?.QuantityInStock >= ItemQuantity)
                {
                    if(ItemQuantity > 0)
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
            CartItemDisplayModel existingaItem = Cart.FirstOrDefault(x => x.Product == SelectedProduct);

            if(existingaItem != null)
            {
                existingaItem.QauntityInCart += ItemQuantity; 
            }
            else
            {
                CartItemDisplayModel Item = new CartItemDisplayModel
                {
                    Product = SelectedProduct,
                    QauntityInCart = ItemQuantity
                };
                Cart.Add(Item);
               
            }
            
            SelectedProduct.QuantityInStock -= ItemQuantity;
            ItemQuantity = 1;

            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
            NotifyOfPropertyChange(() => CanCheckOut);



        }
        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                //Make sure something is selected
                if(SelectedCartItem !=null && SelectedCartItem?.QauntityInCart > 0)
                {
                    output = true;
                }
                return output;
            }
        }
        public void RemoveFromCart()
        {
            SelectedCartItem.Product.QuantityInStock += 1;
            if(SelectedCartItem.QauntityInCart > 1)
            {
                SelectedCartItem.QauntityInCart -= 1;
            }
            else
            {
                Cart.Remove(SelectedCartItem);
            }
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
            NotifyOfPropertyChange(() => CanCheckOut);
            NotifyOfPropertyChange(() => CanAddToCart);
        }
        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                //Make sure there something in the shopping cart
                if(Cart.Count > 0 )
                {
                    output = true;
                }

                return output;
            }
        }
        public async Task CheckOut()
        {
            //TODO - Create sale and post it to API
            SaleModel sale = new SaleModel();
            foreach (var item in Cart)
            {
                sale.SaleDetails.AddLast(new SaleDetailModel
                {
                    ProductId =  item.Product.Id,
                    Quantity = item.QauntityInCart
                
                });
                await _saleEndpoint.PostSale(sale);
                await ResetSalesViewModel();
            }
        }

    }
}
