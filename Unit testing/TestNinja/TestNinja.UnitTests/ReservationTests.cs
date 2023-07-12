using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Arrange 
            var reservation = new Reservation();
         
            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_UserMadeBy_ReturnsTrue()
        {
            // Arrange 
            var reservation = new Reservation();
            reservation.MadeBy = new User { IsAdmin = false };

            // Act
            var result = reservation.CanBeCancelledBy(reservation.MadeBy) ;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_UserNotAdminAndNotMadeBy_ReturnsFalse()
        {
            // Arrange
            var reservation = new Reservation() { MadeBy = new User()};
            var stranger = new User();

            // Act
            var result = reservation.CanBeCancelledBy(stranger);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
