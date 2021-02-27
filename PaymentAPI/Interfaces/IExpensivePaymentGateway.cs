using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Interfaces
{
    public interface IExpensivePaymentGateway
    {
        PaymentResponse ProcessPayment(PaymentRequest paymentRequest);
        bool IsGatewayBusy();
    }
}
