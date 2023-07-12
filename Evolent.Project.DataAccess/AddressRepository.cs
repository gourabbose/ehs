using Evolent.Project.DataAccess.Interfaces;
using Evolent.Project.Models;

namespace Evolent.Project.DataAccess
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(EvolentContext context) : base(context)
        {

        }
    }
}
