using Caliburn.Micro;
using client_management_system.Models;
using client_management_system.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

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
            JsonDeserializeTransactions(@"C:\Temp\transactions.json");
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
            JsonSerialize(_customers, @"C:\Temp\users.json");
            JsonDeserializeUsers(@"C:\Temp\users.json");
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
            SaveCustomers();
        }

        public void SaveCustomers()
        {
            JsonSerialize(Customers, @"C:\Temp\users.json");
        }

        public void DeleteSelectedUser()
        {
            if (_selectedCustomer == null)
            {
                Trace.WriteLine("_selectedCustomer is empty");
            }
            else
            {
                _customers.Remove(_selectedCustomer);
                Trace.WriteLine(Customers);
                JsonSerialize(_customers, @"C:\Temp\users.json");
            }
        }


        public void JsonDeserializeUsers(string filePath)
        {
            if (File.Exists(filePath) && (System.IO.File.ReadAllText(filePath) != ""))
            {
                _customers = new BindableCollection<CustomerModel>();
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
        public TransactionModel _selectedTransaction;

        public TransactionModel SelectedTransaction
        {
            get { return _selectedTransaction; }
            set
            {
                _selectedTransaction = value;
                NotifyOfPropertyChange(() => SelectedTransaction);
            }
        }

        public BindableCollection<TransactionModel> Transactions
        {
            get { return _transactions; }
            set { _transactions = value; }
        }

        public void AddTransactionBtn(string customer, string productName, string variation, float discount, float amount, float quantity)
        {
            Transactions.Add(new TransactionModel { Customer = _selectedCustomer.FirstName + " " + _selectedCustomer.LastName, ProductName = productName, Variation = variation, Discount = discount, Amount = amount, Quantity = quantity });
            SaveTransactions();
        }

        public void AddTransaction(string customer, string productName, string variation, float discount, float amount, float quantity)
        {
            Transactions.Add(new TransactionModel { Customer = customer, ProductName = productName, Variation = variation, Discount = discount, Amount = amount, Quantity = quantity });
            SaveTransactions();
        }

        public void DeleteSelectedTransaction()
        {
            if (_selectedTransaction == null)
            {
                Trace.WriteLine("_selectedTransaction is empty");
            }
            else
            {
                _transactions.Remove(_selectedTransaction);
                Trace.WriteLine(Transactions);
                SaveTransactions();
            }
        }
        public void SaveTransactions()
        {
            JsonSerialize(Transactions, @"C:\Temp\transactions.json");
        }

        public void JsonDeserializeTransactions(string filePath)
        {
            if (File.Exists(filePath) && (System.IO.File.ReadAllText(filePath) != ""))
            {
                _transactions = new BindableCollection<TransactionModel>();
                string aaa = System.IO.File.ReadAllText(filePath);

                dynamic temp_object = JsonConvert.DeserializeObject(aaa);
                foreach (var item in temp_object)
                {
                    Trace.WriteLine((item.Customer, item.ProductName, item.Variation, item.Discount, item.Amount, item.Quantity));

                    string c = item.Customer;
                    string pn = item.ProductName;
                    string v = item.Variation;
                    float d = item.Discount;
                    float a = item.Amount;
                    float q = item.Quantity;

                    AddTransaction(c, pn, v, d, a, q);
                }


            }
            else
            {
                Trace.WriteLine("The file \"{0}\" does not exist", filePath);
            }

        }


    }


}
