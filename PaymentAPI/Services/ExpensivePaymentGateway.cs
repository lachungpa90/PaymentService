using PaymentAPI.Interfaces;
using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Services
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public bool IsGatewayBusy()
        {
            return false;
        }
        public PaymentResponse ProcessPayment(PaymentRequest paymentRequest)
        {
            return new PaymentResponse { IsSuccessfullyCharged = true, PaymentStatus = PaymentStaus.Processed };
        }
    }
}
