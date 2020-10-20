using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTestsMSTest
{
    [TestClass()]
    [TestCategory("MSTest")]
    public class PayRateCalculatorTests
    {
        [TestInitialize]// runs before all tests
        public static void Initialize()
        {

        }

        [TestMethod]
        [TestCategory("Salaried Employees")]
        public void CalculateGrossPay_ForSalariedEmployee_IsSameForAnyHours()
        {
            // Arrange
            var calculator = new PayRateCalculator();
            double expected = 40.0 * 15.0;

            // Act
            double grossPay = calculator.CalculateGrossPay(30.0, 15.0, true);

            // Assert
            Assert.AreEqual(expected, grossPay, .001);

        }
    }
}