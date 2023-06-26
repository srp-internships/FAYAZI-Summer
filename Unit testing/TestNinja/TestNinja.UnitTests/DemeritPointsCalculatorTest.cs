using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class DemeritPointsCalculatorTest
    {
        [Test]
        [TestCase(350)]
        [TestCase(-5)]
        public void CalculateDemeritPoints_SpeedOutOfRange_GivesArgumentOutOfRangeException(int speed)
        {
            var calculator = new DemeritPointsCalculator();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                calculator.CalculateDemeritPoints(speed);
            });
        }


        [Test]
        [TestCase(60, 0)]
        [TestCase(0, 0)]
        [TestCase(65, 0)]
        [TestCase(70, 1)]
        [TestCase(66, 0)]
        [TestCase(80, 3)]
        public void CalculateDemeritPoints_WhenCalled_ReturnsDemeritPoints(int speed, int expectedResult)
        {
            var dpCalculator = new DemeritPointsCalculator();

            var result = dpCalculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
