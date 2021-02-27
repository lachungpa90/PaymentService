using PaymentAPI.Interfaces;
using PaymentAPI.Models;

namespace PaymentAPI.Services
{
    public class PremimumPaymentService : IPremiumPaymentService
    {
        public PaymentResponse ProcessPayment(PaymentRequest paymentRequest)
        {
            return new PaymentResponse { IsSuccessfullyCharged = true, PaymentStatus = PaymentStaus.Processed };
        }
    }
}
