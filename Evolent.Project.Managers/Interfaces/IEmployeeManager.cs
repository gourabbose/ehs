using Evolent.Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evolent.Project.Managers.Interfaces
{
    public interface IEmployeeManager
    {
        Task<Employee> GetEmployeeById(int id);
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
        Task<IEnumerable<Employee>> SearchEmployee(string firstname, string lastname);
    }
}
