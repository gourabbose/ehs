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
        private readonly IAddressRepository addressRepository;
        public EmployeeManager(IEmployeeRepository repository,IAddressRepository addressRepository)
        {
            this.employeeRepository = repository;
            this.addressRepository = addressRepository;
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
                                .Include(t => t.Address)
                                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            return await this.employeeRepository.CreateAsync(employee);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var existing = await this.GetEmployeeById(employee.Id);
            if (existing == null)
            {
                throw new System.Exception("Employee not found");
            }

            employee.Address.Id = existing.Address.Id;
            await this.addressRepository.UpdateAsync(employee.Address);
            await this.employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await this.employeeRepository.DeleteAsync(new Employee { Id = id });
        }

        public async Task<IEnumerable<Employee>> SearchEmployee(string firstname, string lastname)
        {
            var queryable = this.employeeRepository
                    .Get()
                    .Include(t => t.Address);

            if(!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lastname))
            {
                return await queryable.Where(t => t.FirstName.Contains(firstname) && t.LastName.Contains(lastname)).ToListAsync();
            }
            else if(!string.IsNullOrEmpty(firstname))
            {
                return await queryable.Where(t => t.FirstName.Contains(firstname)).ToListAsync();
            }
            else
            {
                return await queryable.Where(t => t.LastName.Contains(lastname)).ToListAsync();
            }
                    
        }
    }
}
