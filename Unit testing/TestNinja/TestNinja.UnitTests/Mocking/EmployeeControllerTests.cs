using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class EmployeeControllerTests
    {
        [Test]
        public void DeleteEmployee_WhenCalled_RemovesEmployeeFromDb()
        {
            var storage = new Mock<IControlEmp>();
            var employeeController = new EmployeeController(storage.Object);

            employeeController.DeleteEmployee(1);

            storage.Verify(s => s.RemoveEployee(1));
        }
    }
}
