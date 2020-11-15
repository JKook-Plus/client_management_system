using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_management_system.ViewModels
{
    public class FirstChildViewModel : ShellViewModel
    {
        private string _customer;
        private string _productName;
        private string _variation;
        private float _discount;
        private float _amount;
        private float _quantity;

        public FirstChildViewModel()
        {
            //asd
        }

        public string Customer
        {
            get { 
                
                return _selectedCustomer.FirstName; 
            }
            set
            {
                _customer = value;
                NotifyOfPropertyChange(() => Customer);
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                NotifyOfPropertyChange(() => ProductName);
            }
        }

        public string Variation
        {
            get { return _variation; }
            set
            {
                _variation = value;
                NotifyOfPropertyChange(() => Variation);
            }
        }

        public float Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                NotifyOfPropertyChange(() => Discount);
            }
        }
        public float Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                NotifyOfPropertyChange(() => Amount);
            }
        }

        public float Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                NotifyOfPropertyChange(() => Quantity);
            }
        }

        public bool CanClearText(string customer, string productName, string variation, float discount, float amount, float quantity)
        {
            return !String.IsNullOrWhiteSpace(productName) || !String.IsNullOrWhiteSpace(variation) || !String.IsNullOrWhiteSpace(discount.ToString()) || !String.IsNullOrWhiteSpace(amount.ToString()) || !String.IsNullOrWhiteSpace(quantity.ToString());
        }

        public void DeleteTransactionBtn()
        {
            DeleteSelectedTransaction();
        }

        public void ClearText(string _customer, string productName, string variation, float discount, float amount, float quantity)
        {
            ProductName = "";
            Variation = "";
            Discount = 0;
            Amount = 1;
            Quantity = 1;
        }

    }
}
