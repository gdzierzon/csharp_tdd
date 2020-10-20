using NUnit.Framework;
using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTestsNUnit
{
    [TestFixture()]
    public class StandardCalculatorTests
    {
        [Test()]
        [Combinatorial]
        public void AddTest([Values(3,4,5)] int one,
                            [Values(1,2,3)] int two)
        {
            //Arrange
            var calculator = new StandardCalculator();
            var expected = one + two;

            //Act
            var answer = calculator.Add(one, two);

            //Assert
            Assert.AreEqual(expected, answer);
        }


        [TestCase(1,3,4)]
        [TestCase(11, -3, 8)]
        [TestCase(12, 3, 15)]
        [Repeat(2)]
        public void Add_WithTestCases(int one, int two, int expected)
        {
            //Arrange
            var calculator = new StandardCalculator();

            //Act
            var answer = calculator.Add(one, two);

            //Assert
            Assert.AreEqual(expected, answer, $"{one} + {two} should = {expected}");
        }


    }
}