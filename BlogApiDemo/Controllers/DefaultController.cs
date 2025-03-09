using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeLİst()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }
        [HttpPost]

        /*
        Görseldeki Add metodu, Entity Framework Core'dan (EF Core) gelmektedir. 
             EF Core, veritabanı işlemleri için çeşitli yöntemler sağlar */
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var c = new Context();    
            c.Add(employee);
            c.SaveChanges();


            return Ok();

        }
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            // Veritabanı context'ini oluşturuyoruz
            using var c = new Context();

            // Veritabanında id'ye göre çalışanı buluyoruz
            var employee = c.Employees.Find(id);

            // Eğer çalışan bulunamazsa, NotFound (404) döneriz
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                // Çalışan bulunduğunda, OK (200) ve çalışan verisiyle döneriz
                return Ok(employee);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id) { 
        using var c =new Context();
        var employee=c.Employees.Find(id);
            if (employee == null)
            {

                return NotFound();
            }
            else { 
            c.Remove(employee); ;
            c.SaveChanges();
               return Ok();
            }

        
        
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee employee) {
        using var c =new Context();
            var emp = c.Find<Employee>(employee.ID);
            if (emp == null)
            {
                return NotFound();
            }
            else { 
            emp.Name = employee.Name;   
                c.Update(emp);
                c.SaveChanges();
                return Ok();
            
            }
        
        }
    }
}
