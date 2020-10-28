using Caliburn.Micro;
using System;
using System.Collections.Generic;
using client_management_system.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_management_system.ViewModels
{
    public class SecondChildViewModel : Screen
    {
        private string _firstName;
        private string _lastName;
        private BindableCollection<CustomerModel> _customers = new BindableCollection<CustomerModel>();
        private CustomerModel _selectedCustomer;

        public SecondChildViewModel()
        {
            Customers.Add(new CustomerModel { FirstName = "Jeff", LastName = "Smith" });
            Customers.Add(new CustomerModel { FirstName = "John", LastName = "Smith" });
            Customers.Add(new CustomerModel { FirstName = "Mark", LastName = "Doe" });
            Customers.Add(new CustomerModel { FirstName = "Jenifer", LastName = "Bloe" });
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get { return $"{ FirstName } { LastName }"; }
        }

        public BindableCollection<CustomerModel> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }

        public CustomerModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                NotifyOfPropertyChange(() => SelectedCustomer);
            }
        }

        public bool CanClearText(string firstName, string lastName)
        {
            return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
        }

        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public void AddUser(string firstName, string lastName)
        {
            Customers.Add(new CustomerModel { FirstName = firstName, LastName = lastName });
        }
    }
}
