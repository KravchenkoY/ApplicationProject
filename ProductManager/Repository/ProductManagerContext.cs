using Microsoft.EntityFrameworkCore;
using ProductManager.Repository.Models;

namespace ProductManager.Repository
{
    internal class ProductManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User { Id = 1, Name ="Yulia", UserRoleId=1, LastName = "Kravchenko", Email = "osov0001@gmail.com", Password= "1234"},
                new User { Id = 2, Name ="Ken", UserRoleId=2, LastName = "Field", Email = "kenfield@gmail.com", Password= "barbeque"},
                new User { Id = 3, Name ="Brad", UserRoleId=3, LastName = "Pitt", Email = "bradpitt@gmail.com", Password= "ahil"},
            });

            modelBuilder.Entity<UserRole>().HasData(new UserRole[] {
                new UserRole{Id=1,Name="Administrator"},
                new UserRole{Id=2,Name="Warehouse Worker"},
                new UserRole{Id=3,Name="Sales Worker"},
            });

            modelBuilder.Entity<PartnerType>().HasData(new PartnerType[] {
                new PartnerType{Id=1,Name="Supplier"},
                new PartnerType{Id=2,Name="Customer"}
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-H2095O8\SQLEXPRESS; Database = ProductManagerDB; Trusted_Connection = true");
        }
    }
}
