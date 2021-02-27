using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.DTOs
{
    public class PaymentDto
    { 
        [Required]
        public string CreditCardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [StringLength(3)]
        public string SecurityCode { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
