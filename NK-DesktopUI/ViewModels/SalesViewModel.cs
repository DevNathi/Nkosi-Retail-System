using Caliburn.Micro;
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
        private BindingList<string> _products;

        public BindingList<string> Products
        {
            get { return Products; }
            set
            { 
                Products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }
        private string _itemQuality;

        public string ItemQuality
        {
            get { return ItemQuality; }
            set 
            { 
                ItemQuality = value;
                NotifyOfPropertyChange(() => ItemQuality);
            }
        }

        public string Tax
        {
            get 
            {
                //TODO - Replace with calculation for subtotal
                return "R0.00";
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
