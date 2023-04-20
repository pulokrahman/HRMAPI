using HRMAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //Query string vs dynamic url
        private readonly List<EmployeeModel> employees;
        public EmployeeController()
        {
            employees = new List<EmployeeModel>
            {
                new EmployeeModel {Id =1, Name="David"},
                new EmployeeModel {Id=2, Name="Lisa"},
                new EmployeeModel {Id=3, Name="Mia"}
            };

        }
        [HttpGet("Error")]
        public IActionResult Error()
        {
            throw new NullReferenceException();
        }
       

        [HttpGet]
        public IActionResult GetEmployeees()
        {


            return Ok(employees);
            //BadRequest();
            //404 if not found
            //NotFound();
            //return Ok();
        }
        [HttpGet]
          [Route("GetById/{id:min(1):max(5)}")]
        public IActionResult GetById(int id)
        {
            var result = employees.Find(x => x.Id == id);
            if (result != null)
                return Ok(result);
            return NotFound("Employee not found");
        }
        [HttpGet]
        [Route("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            var result = employees.Find(x => x.Name == name);
         if (result != null)
                return Ok(result);
            return NotFound("Employee not found");
        }
    }
}
