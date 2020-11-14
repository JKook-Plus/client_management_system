using Caliburn.Micro;
using System;
using System.Collections.Generic;
using client_management_system.Models;
using client_management_system.ViewModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace client_management_system.ViewModels
{
    public class SecondChildViewModel : ShellViewModel
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _address;
        private string _phone;
        private DateTime _dob = DateTime.Now;

        public void whatacc()
        {
            if (_selectedCustomer == null)
            {
                Trace.WriteLine("_selectedCustomer is empty");
            }
            else
            {
                Customers.Remove(_selectedCustomer);
                updateCustomers();
            }
            
        }
        
        public SecondChildViewModel()
        {
            
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


        public string Phone
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
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }

        public bool CanClearText(string firstName, string lastName, string email, string address, string phone, DateTime dob)
        {
            return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName) || !String.IsNullOrWhiteSpace(email) || !String.IsNullOrWhiteSpace(address);
        }

        public void ClearText(string firstName, string lastName, string email, string address, string phone, DateTime dob)
        {
            FirstName = "";
            LastName = "";
            Email = "";
            Address = "";
            Phone = default(string);
            DOB = DateTime.Now;
        }

        public bool CanAddUser(string firstName, string lastName, string email, string address, string phone, DateTime dob)
        {
            return !String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName);
        }

    }
}
