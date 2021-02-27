using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PaymentAPI.Controllers;
using PaymentAPI.Data;
using PaymentAPI.DTOs;
using PaymentAPI.Entity;
using PaymentAPI.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentAPI.Test
{
    [TestClass]
    public class WhenPaymentProcessController_Called : Specification
    {
        private Mock<DataContext> _dataContext;
        private Mock<IPaymentChargeHandler> _paymentCharge;
        PaymentDetail payment;       
        private PaymentProcessController _paymentProcessController;
        protected override void Given()
        {
            payment = new PaymentDetail
            {
                CardHolder = "Jimmy"
            };
            _dataContext = new Mock<DataContext>();
            _paymentCharge = new Mock<IPaymentChargeHandler>();
            _dataContext.Setup(x => x.PaymentDetails).Equals(payment);
            _paymentCharge.Setup(x => x.ChargePayment(It.IsAny<PaymentDto>())).Returns("Porcessed");
            _paymentProcessController = new PaymentProcessController(_dataContext.Object, _paymentCharge.Object);
        }
        protected override void When()
        {
           

        }
        [TestMethod]
        public async Task When_GetAllPaymentsCalled()
        {
           var result = await _paymentProcessController.GetAllPayment();
            
        }



    }
}
