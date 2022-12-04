using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
  
    public class PassengerDetails
    {
      
        public int travelerNo { get; set; }
      
        public PassengerType passengerType { get; set; }
      
        public string title { get; set; }
      
        public string firstName { get; set; }
      
        public string middleName { get; set; }
      
        public string lastName { get; set; }
             
        public string day { get; set; }
      
        public string month { get; set; }
      
        public string year { get; set; }
      
        public DateTime dateOfBirth { get; set; }
      
        public Gender gender { get; set; }
      
        public string passportNumber { get; set; }
      
        public string nationality { get; set; }
      
        public string issueCountry { get; set; }
      
        public DateTime? expiryDate { get; set; }
      
        public string Meal { get; set; }
      
        public string Seat { get; set; }
      
        public string SpecialAssistance { get; set; }
      
        public string FFMiles { get; set; }
      
        public string TSA_Precheck { get; set; }
      
        public string RedressNumber { get; set; }
        public PassengerDetails()
        {
            firstName = "";
            lastName = "";
            nationality = "";
            issueCountry = "";
            expiryDate = DateTime.Now.AddMonths(12);
        }
    }
}
