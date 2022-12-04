using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PaymentInfoByEmail
    {
         
        public string ReferenceId { get; set; }
         
        public string BookingConfirmation { get; set; }
         
        public string TotalAmount { get; set; }

         
        public string cardCode { get; set; }
         
        public string cardNumber { get; set; }
         
        public string cardHolderName { get; set; }
         
        public string expiryMonth { get; set; }
         
        public string expiryYear { get; set; }
         
        public string cvvNo { get; set; }
         
        public string Paymentcountry { get; set; }
         
        public string address1 { get; set; }
         
        public string address2 { get; set; }
         
        public string city { get; set; }
         
        public string state { get; set; }
         
        public string stateOther { get; set; }
         
        public string postalCode { get; set; }
         
        public string phoneNo { get; set; }
         
        public string mobileNo { get; set; }
         
        public string emailID { get; set; }
         
        public string emailID2 { get; set; }
    }
}
