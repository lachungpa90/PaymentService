using PaymentAPI.Models;

namespace PaymentAPI.Interfaces
{
    public interface IExpensivePaymentGateway
    {
        PaymentResponse ProcessPayment(PaymentRequest paymentRequest);
        bool IsGatewayBusy();
    }
}
