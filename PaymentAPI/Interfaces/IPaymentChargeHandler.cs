using PaymentAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Interfaces
{
    public interface IPaymentChargeHandler
    {
        string ChargePayment(PaymentDto paymentDto);
    }
}
