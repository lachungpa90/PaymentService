using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.DTOs;
using PaymentAPI.Entity;
using PaymentAPI.Extensions;
using PaymentAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentAPI.Controllers
{
    public class PaymentProcessController:BaseApiController
    {       
        private readonly IPaymentChargeHandler _paymentHandler;
        private readonly IEntityHelper _efHelper;
        public PaymentProcessController(IPaymentChargeHandler paymentHandler, IEntityHelper efHelper)
        {
         
            _paymentHandler = paymentHandler;
            _efHelper = efHelper;
        }

        [HttpGet]
        public async Task<List<PaymentDetail>> GetAllPayment()
        {
            return await _efHelper.GetAll();   
        }

        [HttpPost]
        public async Task<ActionResult> ProcessPayment(PaymentDto paymentDto)
        {            
            var isvalid = false;
            PaymentDetail result = null;
            try
            {
                if (paymentDto.ExpirationDate < DateTime.Now || paymentDto.Amount < 0)
                    return BadRequest("Invalid Request");
                if (!isvalid.IsCreditCardValid(paymentDto.CreditCardNumber))
                    return BadRequest("Invalid Card Number");

                result = HandlePayment(paymentDto);
                await _efHelper.Insert(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                
            }
            return Ok(result.PaymentStatus.Status);
        }

        private PaymentDetail HandlePayment(PaymentDto paymentDto)
        {
            return new PaymentDetail
            {
                CreditCardNumber = paymentDto.CreditCardNumber,
                CardHolder = paymentDto.CardHolder,
                Amount = paymentDto.Amount,
                ExpirationDate = paymentDto.ExpirationDate,
                SecurityCode = paymentDto.SecurityCode,
                PaymentStatus = new PaymentStatus
                {
                    Status = _paymentHandler.ChargePayment(paymentDto)
                }

            };
        }

    }
}
