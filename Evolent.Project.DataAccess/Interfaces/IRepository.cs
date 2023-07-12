using Evolent.Project.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Evolent.Project.DataAccess.Interfaces
{
    public interface IRepository<T> where T : ModelBase
    {
        Task<T> CreateAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(T obj);
        IQueryable<T> Get();
    }
}
