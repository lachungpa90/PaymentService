using PaymentAPI.DTOs;

namespace PaymentAPI.Interfaces
{
    public interface IPaymentChargeHandler
    {
        string ChargePayment(PaymentDto paymentDto);
    }
}
