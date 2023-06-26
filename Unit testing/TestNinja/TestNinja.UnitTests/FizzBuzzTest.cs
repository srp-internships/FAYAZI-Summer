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
    class FizzBuzzTest
    {
        [Test]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnsFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_InputIsDivisibleBy3Only_ReturnsFizz()
        {
            var result = FizzBuzz.GetOutput(9);
            Assert.That(result, Is.EqualTo("Fizz"));
        }
        [Test]
        public void GetOutput_InputIsDivisibleBy5Only_ReturnsBuzz()
        {
            var result = FizzBuzz.GetOutput(25);
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_InputIsNotDivisibleBy3And5_ReturnsTheSameNumber()
        {
            var result = FizzBuzz.GetOutput(17);
            Assert.That(result, Is.EqualTo("17"));
        }
    }
}
