using PaymentAPI.Models;

namespace PaymentAPI.Interfaces
{
    public interface ICheapPaymentGateway
    {
        PaymentResponse ProcessPayment(PaymentRequest paymentRequest);
    }
}
