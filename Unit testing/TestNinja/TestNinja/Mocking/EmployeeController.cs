using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private IControlEmp _employee;

        public EmployeeController(IControlEmp controlEmp)
        {
            _employee = controlEmp;
        }

        public ActionResult DeleteEmployee(int id)
        {
            _employee.RemoveEployee(id);
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }
    
    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}