using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core
{

    public class ResponseStatus
    {
     
        public TransactionStatus status { get; set; }
        
        public string message { get; set; }
        public ResponseStatus()
        {
            status = TransactionStatus.Success;
            message = "Success";
        }
    }
}
