using PaymentAPI.DTOs;
using PaymentAPI.Interfaces;
using PaymentAPI.Models;

namespace PaymentAPI.Services
{
    public class PaymentChargeHandler : IPaymentChargeHandler
    {
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IPremiumPaymentService _premiumPaymentService;
        public PaymentChargeHandler(ICheapPaymentGateway cheapPaymentGateway, IExpensivePaymentGateway expensivePaymentGateway,IPremiumPaymentService premiumPaymentService)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
            _premiumPaymentService = premiumPaymentService;
        }
        public string ChargePayment(PaymentDto paymentDto)
        {
            PaymentResponse paymentResponse = null;
            var paymentRq = new PaymentRequest
            {
                CardNumber = paymentDto.CreditCardNumber,
                CvvNumber = paymentDto.SecurityCode,
                ExpiryDate = paymentDto.ExpirationDate,
                Name = paymentDto.CardHolder,
                Amount = paymentDto.Amount
            };

            if (paymentDto.Amount <= 20)
                paymentResponse = _cheapPaymentGateway.ProcessPayment(paymentRq);
            else if (paymentDto.Amount >= 21 && paymentDto.Amount <= 500)
            {
                if (!_expensivePaymentGateway.IsGatewayBusy())
                    paymentResponse =_expensivePaymentGateway.ProcessPayment(paymentRq);
                else
                    paymentResponse =  _cheapPaymentGateway.ProcessPayment(paymentRq);

            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    paymentResponse = _premiumPaymentService.ProcessPayment(paymentRq);

                    if (paymentResponse.IsSuccessfullyCharged)
                        break;
                }
            }
            return paymentResponse.PaymentStatus.ToString();
        }
    }
}
