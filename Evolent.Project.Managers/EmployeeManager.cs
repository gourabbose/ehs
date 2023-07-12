using Evolent.Project.DataAccess.Interfaces;
using Evolent.Project.Managers.Interfaces;
using Evolent.Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evolent.Project.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeManager(IEmployeeRepository repository)
        {
            this.employeeRepository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await this.employeeRepository
                                .Get()
                                .Include(t => t.Address)
                                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await this.employeeRepository
                                .Get()
                                .Include(t=>t.Address)
                                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            return await this.employeeRepository.CreateAsync(employee);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await this.employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await this.employeeRepository.DeleteAsync(new Employee { Id = id });
        }

        public async Task<IEnumerable<Employee>> SearchEmployee(string firstname, string lastname)
        {
            return await this.employeeRepository
                    .Get()
                    .Include(t=>t.Address)
                    .Where(t => t.FirstName.Contains(firstname) || t.LastName.Contains(lastname))
                    .ToListAsync();
        }
    }
}
