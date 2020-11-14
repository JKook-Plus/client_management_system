using Caliburn.Micro;
using client_management_system.Models;
using client_management_system.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_management_system.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        //General Commands

        public void JsonSerialize(object data, string filePath)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);
        }



        //Shell commands

        public ShellViewModel()
        {
            JsonDeserializeUsers(@"C:\Temp\users.json");
        }

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }



        //Customer commands

        public BindableCollection<CustomerModel> _customers = new BindableCollection<CustomerModel>();
        public CustomerModel _selectedCustomer;



        public CustomerModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                NotifyOfPropertyChange(() => SelectedCustomer);
            }
        }

        public void updateCustomers()
        {
            JsonDeserializeUsers(@"C:\Temp\users.json");
            JsonSerialize(_customers, @"C:\Temp\users.json");
            
        }

        public void AddUser(
                            string firstName = "",
                            string lastName = "",
                            string email = "",
                            string address = "",
                            string phone = "",
                            DateTime dob = default(DateTime))
        {

            Customers.Add(new CustomerModel { FirstName = firstName, LastName = lastName, Email = email, Address = address, Phone = phone, DOB = dob });
            JsonSerialize(_customers, @"C:\Temp\users.json");
        }



        public void JsonDeserializeUsers(string filePath)
        {
            if (File.Exists(filePath) && (System.IO.File.ReadAllText(filePath) != ""))
            {
                string aaa = System.IO.File.ReadAllText(filePath);

                dynamic temp_object = JsonConvert.DeserializeObject(aaa);
                foreach (var item in temp_object)
                {
                    Trace.WriteLine((item.FirstName, item.LastName, item.Email, item.Address, item.Phone, item.DOB));

                    string fn = item.FirstName;
                    string ln = item.LastName;
                    string em = item.Email;
                    string ad = item.Address;
                    string ph = item.Phone;
                    DateTime dob = item.DOB;

                    AddUser(fn, ln, em, ad, ph, dob);
                }


            }
            else
            {
                Trace.WriteLine("The file \"{0}\" does not exist", filePath);
            }

        }



        public BindableCollection<CustomerModel> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }



        //Transaction commands

        public BindableCollection<TransactionModel> _transactions = new BindableCollection<TransactionModel>();
        public CustomerModel _selectedTransaction;



    }
}
