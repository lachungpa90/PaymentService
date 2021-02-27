using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models
{
    public enum PaymentStaus
    {
        Pending=1,
        Processed=2,
        Failed=3
    }
    public class PaymentResponse
    {
        public PaymentStaus PaymentStatus { get; set; }
        public bool IsSuccessfullyCharged { get; set; }
    }
}
