using Evolent.Project.Managers.Interfaces;
using Evolent.Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Evolent.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await this.employeeManager.GetAllEmployees();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await this.employeeManager.GetEmployeeById(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<Employee> Post([FromBody] Employee employee)
        {
            return await this.employeeManager.CreateEmployee(employee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Employee employee)
        {
            employee.Id = id;
            await this.employeeManager.UpdateEmployee(employee);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.employeeManager.DeleteEmployee(id);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IEnumerable<Employee>> Search(string? firstName, string? lastName)
        {
            return await this.employeeManager.SearchEmployee(firstName, lastName);
        }
    }
}
