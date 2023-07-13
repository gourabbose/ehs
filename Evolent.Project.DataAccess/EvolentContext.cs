using Evolent.Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Evolent.Project.DataAccess
{
    public class EvolentContext : DbContext
    {
        public EvolentContext(DbContextOptions<EvolentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set the unique constraint
            modelBuilder.Entity<Employee>()
                .HasIndex(t => new { t.FirstName, t.LastName, t.EmailAddress })
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasOne(t => t.Address)
                .WithOne(s => s.Employee)
                .HasForeignKey<Address>(t => t.Id)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed
            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee { Id = 1, FirstName = "Olivier", LastName = "Guerra", EmailAddress = "oliver@yopmail.com", Age = 50, AddressId = 1 },
                    new Employee { Id = 2, FirstName = "Myah", LastName = "Adkins", EmailAddress = "myah@yopmail.com", Age = 50, AddressId = 2 },
                    new Employee { Id = 3, FirstName = "Ewan", LastName = "Brooks", EmailAddress = "ewan@yopmail.com", Age = 50, AddressId = 3 },
                    new Employee { Id = 4, FirstName = "Belle", LastName = "Robertson", EmailAddress = "belle@yopmail.com", Age = 50, AddressId = 4 },
                    new Employee { Id = 5, FirstName = "Jackson", LastName = "Newton", EmailAddress = "jackson@yopmail.com", Age = 50, AddressId = 5 },
                    new Employee { Id = 6, FirstName = "Kieron", LastName = "Ramos", EmailAddress = "kieron@yopmail.com", Age = 50, AddressId = 6 },
                    new Employee { Id = 7, FirstName = "Bertha", LastName = "Cannon", EmailAddress = "bertha@yopmail.com", Age = 50, AddressId = 7 },
                    new Employee { Id = 8, FirstName = "Will", LastName = "Wright", EmailAddress = "will@yopmail.com", Age = 50, AddressId = 8 },
                    new Employee { Id = 9, FirstName = "Sufyaan", LastName = "Page", EmailAddress = "sufyaan@yopmail.com", Age = 50, AddressId = 9 },
                    new Employee { Id = 10, FirstName = "Selina", LastName = "Burnett", EmailAddress = "selina@yopmail.com", Age = 50, AddressId = 10 }
                );
            modelBuilder.Entity<Address>()
                .HasData(
                new Address { Id = 1, Line1 = "4256", Line2 = "Elk Creek Road", City = "Dunwoody", State = "Georgia", PostalCode = "30338" },
                new Address { Id = 2, Line1 = "89", Line2 = "Woodside Circle", City = "Fort Walton Beach", State = "Florida", PostalCode = "32548" },
                new Address { Id = 3, Line1 = "4475", Line2 = "Granville Lane", City = "Newark", State = "New Jersey", PostalCode = "07102" },
                new Address { Id = 4, Line1 = "3759", Line2 = "Adams Drive", City = "Houston", State = "Texas", PostalCode = "77002" },
                new Address { Id = 5, Line1 = "1787", Line2 = "Hewes Avenue", City = "White Marsh", State = "Maryland", PostalCode = "21162" },
                new Address { Id = 6, Line1 = "123", Line2 = "Traders Alley", City = "Belton", State = "Missouri", PostalCode = "64012" },
                new Address { Id = 7, Line1 = "1153", Line2 = "Brentwood Drive", City = "San Marcos", State = "Texas", PostalCode = "78666" },
                new Address { Id = 8, Line1 = "125", Line2 = "West Virginia Avenue", City = "Albany", State = "New York", PostalCode = "12210" },
                new Address { Id = 9, Line1 = "3033", Line2 = "Hudson Street", City = "Millburn", State = "New Jersey", PostalCode = "07041" },
                new Address { Id = 10, Line1 = "2087", Line2 = "Berkshire Circle", City = "Knoxville", State = "Tennessee", PostalCode = "37917" }
                );
        }

        #region DbSets
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        #endregion
    }
}
