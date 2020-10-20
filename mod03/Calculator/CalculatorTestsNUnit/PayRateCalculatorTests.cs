using NUnit.Framework;
using Calculator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Constraints;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.CollectionAssert;

namespace CalculatorTestsNUnit
{
    [TestFixture(Category = "PayRate")]
    public class PayRateCalculatorTests
    {
        private PayRateCalculator calculator;
        private static double PayRate;

        [OneTimeSetUp]
        public static void Initiailze()
        {
            PayRate = 15.0;
        }

        [SetUp]// before each test
        public void Setup()
        {
            calculator = new PayRateCalculator();

            // begin db transaction
        }

        [TearDown] // after each test
        public void Teardown()
        {
            // rollback transaction
        }



        [Test]
        public void Test()
        {
            Assert.That(PayRate, Is.EqualTo(15.0));
        }

        [Test()]
        [NUnit.Framework.Category("MSTest")]
        [NUnit.Framework.Category("PayRate")]
        public void CalculateGrossPay_Under40_StillPaysFor40()
        {
            //Arrange
            var hours = 30.0;
            var rate = 15.0;
            var expected = 40 * rate;
            var isSalaried = true;

            //Act
            var actual = calculator.CalculateGrossPay(hours, rate, isSalaried);

            //Assert
            //Assert.Ignore("Need to research more");
            //Assert.Inconclusive("not sure yet");
            //Assume.That(isSalaried, Is.EqualTo(false));

            Assert.AreEqual(expected, actual);

            Constraint isEqual = Is.EqualTo(expected)
                                   .And
                                   .GreaterThan(15);

            Assert.That(actual, isEqual);


            Assert.That("Johnny".EndsWith("y"));

            //actual.Should().Be(expected, "salaried employees get paid for 40");
        }

        [Test()]
        public void CalculateGrossPay_Over40_StillPaysFor40()
        {
            //Arrange
            var hours = 60.0;
            var rate = 15.0;
            var expected = 40 * rate;
            var isSalaried = true;

            //Act
            var actual = calculator.CalculateGrossPay(hours, rate, isSalaried);

            //Assert
            //Assert.Ignore("Need to research more");
            //Assert.Inconclusive("not sure yet");
            //Assume.That(isSalaried, Is.EqualTo(false));

            Assert.AreEqual(expected, actual);

            Assert.That(actual, Is.EqualTo(expected));

            //actual.Should().Be(expected, "salaried employees get paid for 40");
        }

        [Test]
        public void DemoTest()
        {
            //Arrange
            var names = new List<string> { "Zoe", "Joe", "Gary" };
            var names2 = new List<string> {"Joe", "Zoe", "Gary"};
            var names3 = new List<string> { "Joe", "Zoe" };

            //Act
            var calculator = GetCalculator(false);

            //Assert
            CollectionAssert.AreEquivalent(names, names2);
            CollectionAssert.IsSubsetOf(names3, names2);

            Assert.IsInstanceOf<PayRateCalculator>(calculator);
            Assert.IsInstanceOf(typeof(PayRateCalculator),calculator);
        }

        private ICalculator GetCalculator(bool isPayroll)
        {
            if(isPayroll) return new PayRateCalculator();

            return new StandardCalculator();
        }

        [Test]
        [NUnit.Framework.ExpectedException]
        public void DivisionDemo()
        {
            // arrange
            int numerator = 5;
            int denominator = 0;

            //act
            int answer = numerator/denominator;
        }
    }
}