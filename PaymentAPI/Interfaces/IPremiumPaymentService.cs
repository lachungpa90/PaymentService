using PaymentAPI.Models;

namespace PaymentAPI.Interfaces
{
    public interface IPremiumPaymentService
    {
        PaymentResponse ProcessPayment(PaymentRequest paymentRequest);
    }
}
