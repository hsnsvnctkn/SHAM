using Microsoft.EntityFrameworkCore;
using SHAM.Domain.Entities;
using System.Collections.Generic;

namespace SHAM.Repository.Context
{
    public class SHAMDbContext : DbContext
    {
        public SHAMDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SHAM");

            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.TITLE)
                .WithMany(title => title.EMPLOYEES)
                .HasForeignKey(employee => employee.EMPLOYEE_TITLE);

            seedData(modelBuilder);
        }

        void seedData(ModelBuilder modelBuilder)
        {
            var titles = new List<Title>
            {
                new Title { ID = 1, TITLE_NAME = "Junior" },
                new Title { ID = 2, TITLE_NAME = "Senior" },
            };
            modelBuilder.Entity<Title>().HasData(titles);
        }
    }
}
