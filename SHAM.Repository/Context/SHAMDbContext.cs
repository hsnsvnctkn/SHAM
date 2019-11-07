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
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Project_Type> Project_Types { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SHAM");

            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.TITLE)
                .WithMany(title => title.EMPLOYEES)
                .HasForeignKey(employee => employee.EMPLOYEE_TITLE);

            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.CREATED_EMPLOYEE)
                .WithMany(employee => employee.CREATED_EMPLOYEES)
                .HasForeignKey(employee => employee.EMPLOYEE_CREATOR);

            modelBuilder.Entity<Activity>()
                .HasOne(activity => activity.PROJECT)
                .WithMany(project => project.ACTIVITIES)
                .HasForeignKey(activity => activity.PROJECT_NUMBER)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Activity>()
                .HasOne(activity => activity.CREATED_EMPLOYEE)
                .WithMany(employee => employee.CREATED_ACTIVITY)
                .HasForeignKey(activity => activity.EMPLOYEE_NUMBER);

            modelBuilder.Entity<Activity>()
                .HasOne(activity => activity.PRIORITY)
                .WithMany(priority => priority.ACTIVITIES)
                .HasForeignKey(activity => activity.ACTIVITY_PRIORITY);

            modelBuilder.Entity<Customer>()
                .HasOne(customer => customer.CREATED_CUSTOMER)
                .WithMany(employee => employee.CUSTOMERS)
                .HasForeignKey(customer => customer.CUSTOMER_CREATOR);

            modelBuilder.Entity<Project>()
                .HasOne(project => project.PROJECT_TYPE_)
                .WithMany(project_type => project_type.PROJECTS)
                .HasForeignKey(project => project.PROJECT_TYPE);

            modelBuilder.Entity<Project>()
                .HasOne(project => project.CUSTOMER)
                .WithMany(customer => customer.PROJECTS)
                .HasForeignKey(project => project.CUSTOMER_NUMBER);

            modelBuilder.Entity<Project>()
                .HasOne(project => project.LEVEL)
                .WithMany(level => level.PROJECTS)
                .HasForeignKey(project => project.PROJECT_LEVEL);

            modelBuilder.Entity<Project>()
                .HasOne(project => project.CREATED_EMPLOYEE)
                .WithMany(employee => employee.CREATED_PROJECTS)
                .HasForeignKey(project => project.PROJECT_CREATOR);

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

            var levels = new List<Level>
            {
                new Level { ID = 1, LEVEL_NAME = "Accept" },
                new Level { ID = 2, LEVEL_NAME = "Planning" },
                new Level { ID = 3, LEVEL_NAME = "Design" },
                new Level { ID = 4, LEVEL_NAME = "Coding" },
                new Level { ID = 5, LEVEL_NAME = "Test" },
                new Level { ID = 6, LEVEL_NAME = "Completed" },
            };

            var priority = new List<Priority>
            {
                new Priority { ID = 1, PRIORITY_NAME = "SO IMMEDIATE" },
                new Priority { ID = 2, PRIORITY_NAME = "IMMEDIATE" },
                new Priority { ID = 3, PRIORITY_NAME = "NORMAL" },
                new Priority { ID = 4, PRIORITY_NAME = "NOT IMMEDIATE" },
                new Priority { ID = 5, PRIORITY_NAME = "NOT IMPORTANT" },
            };

            var project_type = new List<Project_Type>
            { 
                new Project_Type { ID = 1, TYPE_NAME = "Görsel Tabanlı"},
                new Project_Type { ID = 2, TYPE_NAME = "Nesne Tabanlı"},
            };

        }
    }
}
