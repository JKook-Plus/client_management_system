using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace client_management_system.Models
{
    [DataContract]
    public class TransactionModel
    {
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string Variation { get; set; }


        [DataMember]
        public float Cost { get; set; }


    }
}
