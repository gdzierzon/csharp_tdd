using NUnit.Framework;
using Mocking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mocking.Common.Models;
using Mocking.Common.Services;
using Rhino.Mocks;

namespace Mocking.Tests
{
    [TestFixture()]
    public class InvoiceTests
    {
        [Test()]
        public void ChargeCard_ValidCard()
        {
            //Arrange
            Invoice invoice = new Invoice();

            //Act
            //var code = invoice.ChargeCard(150, card);

            //Assert
            //Assert.AreEqual("111111111", code);
        }
    }
}