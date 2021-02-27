using PaymentAPI.Interfaces;
using PaymentAPI.Models;

namespace PaymentAPI.Services
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        public PaymentResponse ProcessPayment(PaymentRequest paymentRequest)
        {
            return new PaymentResponse { IsSuccessfullyCharged = true, PaymentStatus=PaymentStaus.Processed};
        }
    }
}
