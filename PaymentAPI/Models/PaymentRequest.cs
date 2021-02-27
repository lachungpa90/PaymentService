using System;

namespace PaymentAPI.Models
{
    public class PaymentRequest
    {
        public string CardNumber { get; set; }
        public string Name { get; set; }
        public string CvvNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Amount { get; set; }
    }
}
