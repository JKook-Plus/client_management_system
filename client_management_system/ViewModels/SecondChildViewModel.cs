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
        private string _email;
        private string _address;
        private int _phone;
        private DateTime _dob;


        private BindableCollection<CustomerModel> _customers = new BindableCollection<CustomerModel>();
        private CustomerModel _selectedCustomer;

        public SecondChildViewModel()
        {
            Customers.Add(new CustomerModel { FirstName = "Jeff", LastName = "Smith" });
            Customers.Add(new CustomerModel { FirstName = "John", LastName = "Smith" });
            Customers.Add(new CustomerModel { FirstName = "Mark", LastName = "Doe" });
            Customers.Add(new CustomerModel { FirstName = "Jenifer", LastName = "Bloe" });
        }


        public DateTime DOB
        {
            get { return _dob; }
            set 
            { 
                _dob = value;
                NotifyOfPropertyChange(() => DOB);
            }
        }


        public int Phone
        {
            get { return _phone; }
            set 
            { 
                _phone = value;
                NotifyOfPropertyChange(() => Phone);
            }
        }


        public string Address
        {
            get { return _address; }
            set {
                _address = value;
                NotifyOfPropertyChange(() => Address);
            }
        }
        

        
        public string Email
        {
            get { return _email; }
            set 
            { 
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
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

        public bool CanClearText(string firstName, string lastName, string email, string address, int phone, DateTime dob)
        {
            return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName) || !String.IsNullOrWhiteSpace(email) || !String.IsNullOrWhiteSpace(address);
        }

        public void ClearText(string firstName, string lastName, string email, string address, int phone, DateTime dob)
        {
            FirstName = "";
            LastName = "";
            Email = "";
            Address = "";
            Phone = default(int);
            DOB = default(DateTime);
        }

        public void AddUser(string firstName, string lastName, string email, string address, int phone, DateTime dob)
        {
            Customers.Add(new CustomerModel { FirstName = firstName, LastName = lastName, Email = email, Address = address, Phone = phone, DOB = dob});
        }

        public bool CanAddUser(string firstName, string lastName)
        {
            return !String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName);
        }
    }
}
