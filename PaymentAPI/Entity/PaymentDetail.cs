using System;

namespace PaymentAPI.Entity
{
    public class PaymentDetail
    {
        public int Id { get; set; }
        public string CreditCardNumber { get; set; }       
        public string CardHolder { get; set; }        
        public DateTime ExpirationDate { get; set; }       
        public string SecurityCode { get; set; }        
        public decimal Amount { get; set; }        
        public PaymentStatus PaymentStatus { get; set; }
    }
    
}
