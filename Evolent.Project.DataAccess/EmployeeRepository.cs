using Evolent.Project.DataAccess.Interfaces;
using Evolent.Project.Models;

namespace Evolent.Project.DataAccess
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EvolentContext context) : base(context)
        {

        }
    }
}
