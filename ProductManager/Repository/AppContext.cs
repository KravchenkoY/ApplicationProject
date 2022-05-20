using Microsoft.EntityFrameworkCore;
using ProductManager.Repository.Models;

namespace ProductManager.Repository
{
    internal class AppContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<UserRole> UserRole { get; set; }

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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-H2095O8\SQLEXPRESS; Database = ProductManagerDB; Trusted_Connection = true");
        }
    }
}
