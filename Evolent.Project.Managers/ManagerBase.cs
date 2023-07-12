
using Evolent.Project.DataAccess;

namespace Evolent.Project.Managers
{
    public abstract class ManagerBase<T> where T:class, new()
    {
        private EvolentContext context;
        public ManagerBase(EvolentContext context)
        {
            this.context = context;
        }
    }
}
