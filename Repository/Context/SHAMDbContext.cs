using Microsoft.EntityFrameworkCore;
using SHAM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class SHAMDbContext : DbContext
    {
        public SHAMDbContext(DbContextOptions<SHAMDbContext> options)
            : base(options)
        {

        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Title> Titles { get; set; }
    }
}
