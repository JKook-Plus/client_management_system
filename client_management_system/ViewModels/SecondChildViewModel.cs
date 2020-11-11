using Caliburn.Micro;
using System;
using System.Collections.Generic;
using client_management_system.Models;
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
    public class SecondChildViewModel : Screen
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _address;
        private string _phone;
        private DateTime _dob;


        private BindableCollection<CustomerModel> _customers = new BindableCollection<CustomerModel>();
        private CustomerModel _selectedCustomer;



        public SecondChildViewModel()
        {

            Customers.Add(new CustomerModel { FirstName = "Jeff", LastName = "Smith" });
            Customers.Add(new CustomerModel { FirstName = "John", LastName = "Smith" });
            Customers.Add(new CustomerModel { FirstName = "Mark", LastName = "Doe" });
            Customers.Add(new CustomerModel { FirstName = "Jenifer", LastName = "Bloe" });
            _customers.Add(new CustomerModel { FirstName = "aaaaaaaaaa", LastName = "Bloe" });

            //Trace.WriteLine(_customers.GetType());

            /*            Type abc = CustomerModel;
            */

            /*            BinarySerialize(_customers, @"C:\Temp\test.bin");

                        _customers = BinaryDeserialize(@"C:\Temp\test.bin") as BindableCollection<CustomerModel>;*/
            /*            JsonSerialize(_customers, @"C:\Temp\test.json");
            */

            /*            _customers = JsonDeserialize(typeof(BindableCollection<CustomerModel>), @"C:\Temp\test.json") as BindableCollection<CustomerModel>;
            */
/*            string tmp = JsonDeserialize(typeof(BindableCollection<CustomerModel>), @"C:\Temp\test.json");
*/
            JsonSerialize(_customers, @"C:\Temp\test.json");

            string aaa = System.IO.File.ReadAllText(@"C:\Temp\test.json");

            object temp_object = JsonConvert.DeserializeObject(aaa);
/*            object te = JsonConvert.DeserializeObject<CustomerModel>(tmp);
*/
/*            Trace.WriteLine(te);
            Trace.WriteLine(te.GetType());*/

            /*            _customers = new BindableCollection<CustomerModel>((IEnumerable<CustomerModel>)te);
            */
/*            _customers = (BindableCollection<CustomerModel>)te;
*/

            /*            Trace.WriteLine(_customers);
            */








            /*            foreach (CustomerModel a in _customers)
                        {
                            Trace.WriteLine(a);
                        }*/


        }

        public void BinarySerialize(object data, string filePath)
        {
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath)) File.Delete(filePath);
            fileStream = File.Create(filePath);
            bf.Serialize(fileStream, data);
            fileStream.Close();

        }

        public object BinaryDeserialize(string filePath)
        {
            object obj = null;
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                fileStream = File.OpenRead(filePath);
                obj = bf.Deserialize(fileStream);
                fileStream.Close();
            }
            return obj;

        }

        public void JsonSerialize(object data, string filePath)
        {


            string json = JsonConvert.SerializeObject(data, Formatting.Indented);

            //write string to file
            System.IO.File.WriteAllText(filePath, json);
            

            /*            JsonSerializer jsonSerializer = new JsonSerializer();
                        if (File.Exists(filePath)) File.Delete(filePath);
                        StreamWriter sw = new StreamWriter(filePath);
            *//*
                        JsonWriter jsonWriter = new JsonTextWriter(sw);
            *//*

                        JsonConvert.SerializeObject(data, Formatting.Indented);
            *//*            jsonSerializer.Serialize(jsonWriter, data);*//*

                        jsonWriter.Close();
                        sw.Close();*/
        }

        public string JsonDeserialize(Type dataType, string filePath)
        {
            if(File.Exists(filePath))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                StreamReader sr = new StreamReader(filePath);
/*                Trace.WriteLine("sr: " + sr.ReadToEnd());
*/

/*                JsonReader jsonReader = new JsonTextReader(sr);
                object ab = JsonConvert.DeserializeObject(sr.ReadToEnd());

*//*                object ab = jsonSerializer.Deserialize(jsonReader);
*//*
                Trace.WriteLine("ab: "+ab);
                Trace.WriteLine("datatype: "+dataType);

                JObject obj = ab as JObject;

                *//*                Convert.ChangeType(obj, dataType);
                *//*
                sr.Close();
                jsonReader.Close();

                Trace.WriteLine(Convert.ChangeType(obj, dataType));

                object output = Convert.ChangeType(obj, dataType);*/

                return sr.ReadToEnd();


            }
            else 
            { 
                Trace.WriteLine("Something went wrong");
                return "";
            }

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
            DOB = default(DateTime);
        }

        public void AddUser(string firstName, string lastName, string email, string address, string phone, DateTime dob)
        {
            Customers.Add(new CustomerModel { FirstName = firstName, LastName = lastName, Email = email, Address = address, Phone = phone, DOB = dob});
        }

        public bool CanAddUser(string firstName, string lastName)
        {
            return !String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName);
        }
    }
}
