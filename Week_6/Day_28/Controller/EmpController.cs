using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmpController : Controller
    {
        public IActionResult Display()
        {
            /* Employee empobj = new Employee()
                 {
                      Empno = 1, Ename = "John", Job = "Manager", Salary = 50000, Deptno = 10 

                 };
             return View(empobj);*/
            List<Employee> values = new List<Employee>()
            {
                new Employee { Empno = 1, Ename = "Lal", Job = "SDE", Salary = 60000, Deptno = 101 },
                new Employee { Empno = 2, Ename = "Ravi", Job = "Tester", Salary = 40000, Deptno = 102 },
                new Employee { Empno = 3, Ename = "Anu", Job = "Manager", Salary = 80000, Deptno = 103 }
            };
            return View(values);
        }
    }
}
