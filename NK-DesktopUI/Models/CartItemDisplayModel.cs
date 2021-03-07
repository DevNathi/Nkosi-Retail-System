using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DesktopUI.Models
{
    public class CartItemDisplayModel : INotifyPropertyChanged
    {
        public ProductDisplayModel Product { get; set; }
        private int _qauntityInCart;

        public int QauntityInCart
        {
            get { return _qauntityInCart; }
            set
            {
                _qauntityInCart = value;
                CallPropertyChanged(nameof(QauntityInCart));
                CallPropertyChanged(nameof(DisplayText));

            }
        }


        public string DisplayText
        {
            get
            {
                return $"{Product.ProductName} ({QauntityInCart})";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
