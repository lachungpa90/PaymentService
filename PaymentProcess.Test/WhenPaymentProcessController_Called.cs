using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PaymentAPI.Controllers;
using PaymentAPI.DTOs;
using PaymentAPI.Entity;
using PaymentAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentProcess.Test
{
    [TestClass]
    public class WhenPaymentProcessController_Called : Specification
    {
        private Mock<IEntityHelper> _entityHelper;
        private Mock<IPaymentChargeHandler> _paymentCharge;
       
        private PaymentProcessController _paymentProcessController;
        protected override void Given()
        {
            var paymetnDetail = new List<PaymentDetail> { new PaymentDetail { CardHolder = "JIMM", CreditCardNumber="4222222222222222" } };

            _entityHelper = new Mock<IEntityHelper>();
            _paymentCharge = new Mock<IPaymentChargeHandler>();
            _paymentCharge.Setup(x => x.ChargePayment(It.IsAny<PaymentDto>())).Returns("Porcessed");
            _entityHelper.Setup(x => x.GetAll()).Returns(Task.FromResult(paymetnDetail));
            _paymentProcessController = new PaymentProcessController(_paymentCharge.Object, _entityHelper.Object);
        }
        protected override void When()
        {
        }
        [TestMethod]
        public async Task When_GetAllPaymentsCalled()
        {
            await _paymentProcessController.GetAllPayment();
            _entityHelper.Verify(x => x.GetAll(), Times.Once);        
        } 
        
        [TestMethod]
        public async Task When_ProcessPaymentCalled()
        {
            var dto = new PaymentDto
            {
                Amount = 530,
                CardHolder = "Jimm",
                CreditCardNumber = "5500 0000 0000 0004",
                SecurityCode = "123",
                ExpirationDate = DateTime.Now.AddDays(1).Date
            };            
            await _paymentProcessController.ProcessPayment(dto);
            _entityHelper.Verify(x => x.Insert(It.IsAny<PaymentDetail>()), Times.Once);
        }
    }
}
