using NUnit.Framework;
using Mocking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mocking.Common.Models;
using Mocking.Common.Services;
using Mocking.Fakes;
using Rhino.Mocks;

namespace Mocking.Tests
{
    [TestFixture()]
    public class InvoiceTests
    {
        [Test()]
        public void ChargeCard_RealProcessor_5Seconds()
        {
            //Arrange
            Invoice invoice = new Invoice();

            MockRepository mocks = new MockRepository();
            ICreditCard card = mocks.Stub<ICreditCard>();
            card.Number = "377777777777777";

            //Act
            var code = invoice.ChargeCard(150, card);

            //Assert
            Assert.AreEqual("111111111", code);
        }

        [Test()]
        public void ChargeCard_UsingFake()
        {
            //Arrange
            // removed the dependency on the  real processor
            var processor = new CreditCardProcessorFake();
            Invoice invoice = new Invoice(processor);

            MockRepository mocks = new MockRepository();
            ICreditCard card = mocks.Stub<ICreditCard>();
            card.Number = "377777777777777";

            //Act
            var code = invoice.ChargeCard(150, card);

            //Assert
            Assert.AreEqual("**555555**", code);
        }


        [Test()]
        public void ChargeCard_UsingStub()
        {
            //Arrange
            MockRepository mocks = new MockRepository();

            //ICreditCard card = mocks.Stub<ICreditCard>();
            ICreditCard card = MockRepository.GenerateStub<ICreditCard>();
            card.Number = "377777777777777";
            card.Name = "Gary";
            card.ExpirationMonth = "11";
            card.ExpirationYear = "20";
            //A property that only has a getter must be set 
            // through and Expect statement
            card.Expect(c => c.ExpirationDate).Return("11/20");

            ICreditCardProcessor stub = MockRepository.GenerateStub<ICreditCardProcessor>();
            stub.Expect(s => s.ChargePayment(card, 150)).Return("**555555**").Repeat.Any();
            //stub.Expect(s => s.ChargePayment(card, 150)).Return("**555555**").Repeat.Any();
            
            Invoice invoice = new Invoice(stub);

            //Act
            var code = invoice.ChargeCard(150, card);

            //Assert
            Assert.AreEqual("**555555**", code);
            Assert.AreEqual("11/20", card.ExpirationDate);
        }


        [Test()]
        public void ChargeCard_UsingMock()
        {
            //Arrange
            MockRepository mocks = new MockRepository();

            ICreditCard card = mocks.Stub<ICreditCard>();
            card.Number = "377777777777777";

            ICreditCardProcessor mock = MockRepository.GenerateMock<ICreditCardProcessor>();
            mock.Expect(s => s.ChargePayment(card, 150))
                .Return("**555555**")
                .Repeat
                .Times(5);
            
            Invoice invoice = new Invoice(mock);

            //Act
            var code = invoice.ChargeCard(150, card);
            code = invoice.ChargeCard(150, card);

            //Assert
            mock.VerifyAllExpectations();
        }
    }
}