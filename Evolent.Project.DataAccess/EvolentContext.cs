using Evolent.Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Evolent.Project.DataAccess
{
    public class EvolentContext : DbContext
    {
        public EvolentContext()
        {
               
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set the unique constraint
            modelBuilder.Entity<Employee>()
                .HasIndex(t => new { t.FirstName, t.LastName, t.EmailAddress })
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasOne(t=>t.Address)
                .WithOne(s=>s.Employee)
                .OnDelete(DeleteBehavior.Cascade);

            // Set ref for Address on the composite key of Employee
            //modelBuilder.Entity<Address>()
            //    .HasOne(t => t.Employee)
            //    .WithOne(t => t.Address)
            //    .HasForeignKey<Employee>(t => new { t.FirstName, t.LastName, t.EmailAddress });
        }

        #region DbSets
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        #endregion
    }
}
