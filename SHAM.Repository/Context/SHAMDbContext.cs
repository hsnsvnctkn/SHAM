﻿using Microsoft.EntityFrameworkCore;
using SHAM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public DbSet<ActivityEmployee> ActivityEmployees { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SHAM");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity
                .HasOne(employee => employee.TITLE)
                .WithMany(title => title.EMPLOYEES)
                .HasForeignKey(employee => employee.EMPLOYEE_TITLE)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                 .HasOne(employee => employee.CREATED_EMPLOYEE)
                 .WithMany(employee => employee.CREATED_EMPLOYEES)
                 .HasForeignKey(employee => employee.EMPLOYEE_CREATOR)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity
                .HasOne(activity => activity.PROJECT)
                .WithMany(project => project.ACTIVITIES)
                .HasForeignKey(activity => activity.PROJECT_NUMBER)
                .OnDelete(DeleteBehavior.Cascade);

                entity
                .HasOne(activity => activity.CREATED_EMPLOYEE)
                .WithMany(employee => employee.CREATED_ACTIVITY)
                .HasForeignKey(activity => activity.EMPLOYEE_NUMBER)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(activity => activity.PRIORITY)
                .WithMany(priority => priority.ACTIVITIES)
                .HasForeignKey(activity => activity.ACTIVITY_PRIORITY)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ActivityEmployee>(entity =>
            {
                entity.HasKey(ae => new { ae.ActivityID, ae.EmployeeID });

                entity
                .HasOne(ae => ae.ACTIVITY)
                .WithMany(e => e.EMPLOYEES)
                .HasForeignKey(ae => ae.ActivityID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(ae => ae.EMPLOYEE)
                .WithMany(a => a.ACTIVITIES)
                .HasForeignKey(ae => ae.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Customer>()
                .HasOne(customer => customer.CREATED_CUSTOMER)
                .WithMany(employee => employee.CUSTOMERS)
                .HasForeignKey(customer => customer.CUSTOMER_CREATOR)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>(entity =>
            {
                entity
                .HasOne(project => project.PROJECT_TYPE_)
                .WithMany(project_type => project_type.PROJECTS)
                .HasForeignKey(project => project.PROJECT_TYPE)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(project => project.CUSTOMER)
                .WithMany(customer => customer.PROJECTS)
                .HasForeignKey(project => project.CUSTOMER_NUMBER)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(project => project.LEVEL)
                .WithMany(level => level.PROJECTS)
                .HasForeignKey(project => project.PROJECT_LEVEL)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(project => project.CREATED_EMPLOYEE)
                .WithMany(employee => employee.CREATED_PROJECTS)
                .HasForeignKey(project => project.PROJECT_CREATOR)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProjectEmployee>(entity =>
            {
                entity.HasKey(pe => new { pe.ProjectID, pe.EmployeeID });

                entity
                .HasOne(pe => pe.PROJECT)
                .WithMany(e => e.EMPLOYEES)
                .HasForeignKey(pe => pe.ProjectID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(pe => pe.EMPLOYEE)
                .WithMany(p => p.PROJECTS)
                .HasForeignKey(pe => pe.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            seedData(modelBuilder);
        }

        void seedData(ModelBuilder modelBuilder)
        {
            var titles = new List<Title>
            {
                new Title { ID = 1, TITLE_NAME = "Junior" },
                new Title { ID = 2, TITLE_NAME = "Senior" }
            };
            modelBuilder.Entity<Title>().HasData(titles);

            var levels = new List<Level>
            {
                new Level { ID = 1, LEVEL_NAME = "Accept" },
                new Level { ID = 2, LEVEL_NAME = "Planning" },
                new Level { ID = 3, LEVEL_NAME = "Design" },
                new Level { ID = 4, LEVEL_NAME = "Coding" },
                new Level { ID = 5, LEVEL_NAME = "Test" },
                new Level { ID = 6, LEVEL_NAME = "Completed" }
            };
            modelBuilder.Entity<Level>().HasData(levels);

            var priority = new List<Priority>
            {
                new Priority { ID = 1, PRIORITY_NAME = "SO IMMEDIATE" },
                new Priority { ID = 2, PRIORITY_NAME = "IMMEDIATE" },
                new Priority { ID = 3, PRIORITY_NAME = "NORMAL" },
                new Priority { ID = 4, PRIORITY_NAME = "NOT IMMEDIATE" },
                new Priority { ID = 5, PRIORITY_NAME = "NOT IMPORTANT" }
            };
            modelBuilder.Entity<Priority>().HasData(priority);

            var project_type = new List<Project_Type>
            {
                new Project_Type { ID = 1, TYPE_NAME = "Visual"},
                new Project_Type { ID = 2, TYPE_NAME = "Object - Oriented"}
            };
            modelBuilder.Entity<Project_Type>().HasData(project_type);

            var employee = new List<Employee>
            {
                new Employee{ ID = 1, EMPLOYEE_NAME = "Hasan", EMPLOYEE_SURNAME = "Sevinçtekin", EMPLOYEE_PHONE_NO = "05363403660", EMPLOYEE_ADRESS = "Sancaktepe/İstanbul", EMPLOYEE_MAIL = "sevinctekin.hasan@gmail.com", EMPLOYEE_STATUS = true, EMPLOYEE_TITLE = 1, EMPLOYEE_CREATOR = 1 },
                new Employee{ ID = 2, EMPLOYEE_NAME = "Ömer Faruk", EMPLOYEE_SURNAME = "Kaya", EMPLOYEE_PHONE_NO = "05322545362", EMPLOYEE_ADRESS = "Kartal/İstanbul", EMPLOYEE_MAIL = "aaaaasssddn@gmail.com", EMPLOYEE_STATUS = true, EMPLOYEE_TITLE = 1, EMPLOYEE_CREATOR = 1 },
                new Employee{ ID = 3, EMPLOYEE_NAME = "Fatih", EMPLOYEE_SURNAME = "Balcıoğlu", EMPLOYEE_PHONE_NO = "05348796582", EMPLOYEE_ADRESS = "Üsküdar/İstanbul", EMPLOYEE_MAIL = "qwwwweeeqq@gmail.com", EMPLOYEE_STATUS = true, EMPLOYEE_TITLE = 1, EMPLOYEE_CREATOR = 2 }
            };
            modelBuilder.Entity<Employee>().HasData(employee);

            var customer = new List<Customer>
            {
                new Customer{ ID = 1, CUSTOMER_TYPE = "Indirect", CUSTOMER_NAME = "Shell", CUSTOMER_PHONE_NO = "021632145215", CUSTOMER_ADRESS = "Maltepe/Istanbul", CUSTOMER_MAIL = "shell123@shell.com.tr", CUSTOMER_STATUS = true, CUSTOMER_CREATOR = 2 },
                new Customer{ ID = 2, CUSTOMER_TYPE = "Direct", CUSTOMER_NAME = "Şölen", CUSTOMER_PHONE_NO = "02125422311", CUSTOMER_ADRESS = "Fatih/Istanbul", CUSTOMER_MAIL = "hhhsssqqq@solen.com.tr", CUSTOMER_STATUS = true, CUSTOMER_CREATOR = 3 },
                new Customer{ ID = 3, CUSTOMER_TYPE = "Direct", CUSTOMER_NAME = "Foriba", CUSTOMER_PHONE_NO = "02163112400", CUSTOMER_ADRESS = "Kadıköy/Istanbul", CUSTOMER_MAIL = "supppp@foriba.com.tr", CUSTOMER_STATUS = true, CUSTOMER_CREATOR = 1 }
            };
            modelBuilder.Entity<Customer>().HasData(customer);

            var project = new List<Project>
            {
                new Project{ ID = 1, PROJECT_TYPE = 2, PROJECT_NAME = "Project Management", CUSTOMER_NUMBER = 3, EMPLOYEE_NUMBER = 2, ESTIMATE_START_DATE = new DateTime(2019,05,05), ESTIMATE_END_DATE = new DateTime(2019,08,06), START_DATE = new DateTime(2019,05,05), END_DATE = new DateTime(2019,08,10), PROJECT_STATUS = true, PROJECT_LEVEL = 1, PROJECT_CREATOR = 2 },
                new Project{ ID = 2, PROJECT_TYPE = 1, PROJECT_NAME = "Game Simulator", CUSTOMER_NUMBER = 1, EMPLOYEE_NUMBER = 3, ESTIMATE_START_DATE = new DateTime(2019,10,01), ESTIMATE_END_DATE = new DateTime(2019,12,20), START_DATE = new DateTime(2019,10,05), END_DATE = new DateTime(2019,12,17), PROJECT_STATUS = true, PROJECT_LEVEL = 3, PROJECT_CREATOR = 3 }
            };
            modelBuilder.Entity<Project>().HasData(project);

            var activity = new List<Activity>
            {
                new Activity{ ID = 1, PROJECT_NUMBER = 1, ACTIVITY_DETAIL = "Send to Shell when finished", EMPLOYEE_NUMBER = 1, ESTIMATE_START_DATE = new DateTime(2019,05,09), ESTIMATE_END_DATE = new DateTime(2019,06,20), START_DATE = new DateTime(2019,05,09), END_DATE = new DateTime(2019,06,21), ACTIVITY_STATUS = false, ACTIVITY_PRIORITY = 3, ACTIVITY_CREATOR = 2 },
                new Activity{ ID = 2, PROJECT_NUMBER = 1, ACTIVITY_DETAIL = "Notify Mr. Kaya when finished", EMPLOYEE_NUMBER = 3, ESTIMATE_START_DATE = new DateTime(2019,06,09), ESTIMATE_END_DATE = new DateTime(2019,08,10), START_DATE = new DateTime(2019,06,09), ACTIVITY_STATUS = true, ACTIVITY_PRIORITY = 3, ACTIVITY_CREATOR = 2 }
            };
            modelBuilder.Entity<Activity>().HasData(activity);
        }
    }
}
