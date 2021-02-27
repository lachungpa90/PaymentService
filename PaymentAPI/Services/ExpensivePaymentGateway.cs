using PaymentAPI.Interfaces;
using PaymentAPI.Models;

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
