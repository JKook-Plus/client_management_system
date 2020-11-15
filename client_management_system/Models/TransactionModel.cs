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
        public string Customer { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string Variation { get; set; }
        [DataMember]
        public float Discount { get; set; }
        [DataMember]
        public float Amount { get; set; }
        [DataMember]
        public float Quantity { get; set; }
        [DataMember]
        public float Cost {
            get
            {
                return ((Amount-((Discount/100)* Amount))*Quantity);
            }

            set { }
        }


    }
}
