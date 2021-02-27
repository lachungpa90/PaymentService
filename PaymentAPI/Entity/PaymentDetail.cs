using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
