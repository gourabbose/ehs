using Evolent.Project.DataAccess.Interfaces;
using Evolent.Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Evolent.Project.DataAccess
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : ModelBase, new()
    {
        private readonly EvolentContext context;
        private readonly DbSet<T> dbSet;

        public RepositoryBase(EvolentContext context)
        {
            this.context = context;
            var properties = context.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(DbSet<T>))
                {
                    this.dbSet = (DbSet<T>)property.GetValue(context, null);
                    break;
                }
            }

        }

        public async virtual Task<T> CreateAsync(T obj)
        {
            obj.CreatedOn = DateTime.Now;
            await this.context.AddAsync<T>(obj);
            await this.context.SaveChangesAsync();
            return obj;
        }

        public async virtual Task UpdateAsync(T obj)
        {
            obj.UpdatedOn = DateTime.Now;
            this.context.Update(obj);
            await this.context.SaveChangesAsync();
        }

        public async virtual Task DeleteAsync(T obj)
        {
            this.context.Remove(obj);
            await this.context.SaveChangesAsync();
        }

        public virtual IQueryable<T> Get()
        {
            return this.dbSet.AsQueryable();
        }
    }
}
