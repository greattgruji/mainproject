using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
 
    public class PaymentDetails
    {
        public PaymentDetails()
        {
            cardCode = "VI";
            postalCode = "12345";
            state = "WA";
            city = "Seattle";
            country = "US";
            address1 = "one";
            address2 = "two";
            expiryMonth = "10";
            expiryYear = "2020";
            cvvNo = "123";
            cardHolderName = "ajay singh";
            cardNumber = "4111111111111111";
        }
        public PaymentDetails(bool withDummyData)
        {
            if (withDummyData)
            {
                cardCode = "VI";
                postalCode = "12345";
                state = "WA";
                city = "Seattle";
                country = "US";
                address1 = "one";
                address2 = "two";
                expiryMonth = "10";
                expiryYear = "2020";
                cvvNo = "123";
                cardHolderName = "ajay singh";
                cardNumber = "4111111111111111";
            }           
        }
      
        public string cardCode { get; set; }
      
        public string cardNumber { get; set; }
      
        public string cardHolderName { get; set; }
      
        public string expiryMonth { get; set; }
      
        public string expiryYear { get; set; }
      
        public string cvvNo { get; set; }
      
        public string country { get; set; }
      
        public string address1 { get; set; }
      
        public string address2 { get; set; }
      
        public string city { get; set; }
      
        public string state { get; set; }
      
        public string stateOther { get; set; }
      
        public string postalCode { get; set; }
      
        public string billingPhoneNo { get; set; }
    }
}
