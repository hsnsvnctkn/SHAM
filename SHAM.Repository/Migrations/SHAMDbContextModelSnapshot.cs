﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SHAM.Repository.Context;

namespace SHAM.Repository.Migrations
{
    [DbContext(typeof(SHAMDbContext))]
    partial class SHAMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("SHAM")
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SHAM.Domain.Entities.Activity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ACTIVITY_CREATOR")
                        .HasColumnType("int");

                    b.Property<string>("ACTIVITY_DETAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("ACTIVITY_PRIORITY")
                        .HasColumnType("int");

                    b.Property<bool>("ACTIVITY_STATUS")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CREATED_DATE")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("CREATED_TIME")
                        .HasColumnType("time");

                    b.Property<DateTime?>("END_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ESTIMATE_END_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ESTIMATE_START_DATE")
                        .HasColumnType("datetime2");

                    b.Property<bool>("INVOICE")
                        .HasColumnType("bit");

                    b.Property<int>("PROJECT_NUMBER")
                        .HasColumnType("int");

                    b.Property<DateTime>("START_DATE")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ACTIVITY_CREATOR");

                    b.HasIndex("ACTIVITY_PRIORITY");

                    b.HasIndex("PROJECT_NUMBER");

                    b.ToTable("ACTIVITIES");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ACTIVITY_CREATOR = 2,
                            ACTIVITY_DETAIL = "Send to Shell when finished",
                            ACTIVITY_PRIORITY = 3,
                            ACTIVITY_STATUS = false,
                            CREATED_DATE = new DateTime(2019, 12, 5, 12, 33, 2, 116, DateTimeKind.Local).AddTicks(7490),
                            CREATED_TIME = new TimeSpan(451821167505),
                            END_DATE = new DateTime(2019, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ESTIMATE_END_DATE = new DateTime(2019, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ESTIMATE_START_DATE = new DateTime(2019, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            INVOICE = false,
                            PROJECT_NUMBER = 1,
                            START_DATE = new DateTime(2019, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 2,
                            ACTIVITY_CREATOR = 2,
                            ACTIVITY_DETAIL = "Notify Mr. Kaya when finished",
                            ACTIVITY_PRIORITY = 3,
                            ACTIVITY_STATUS = true,
                            CREATED_DATE = new DateTime(2019, 12, 5, 12, 33, 2, 117, DateTimeKind.Local).AddTicks(3124),
                            CREATED_TIME = new TimeSpan(451821173132),
                            ESTIMATE_END_DATE = new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ESTIMATE_START_DATE = new DateTime(2019, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            INVOICE = false,
                            PROJECT_NUMBER = 1,
                            START_DATE = new DateTime(2019, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SHAM.Domain.Entities.ActivityEmployee", b =>
                {
                    b.Property<int>("ActivityID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.HasKey("ActivityID", "EmployeeID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("ActivityEmployees");

                    b.HasData(
                        new
                        {
                            ActivityID = 1,
                            EmployeeID = 1
                        },
                        new
                        {
                            ActivityID = 1,
                            EmployeeID = 2
                        },
                        new
                        {
                            ActivityID = 2,
                            EmployeeID = 3
                        },
                        new
                        {
                            ActivityID = 2,
                            EmployeeID = 1
                        });
                });

            modelBuilder.Entity("SHAM.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CREATED_DATE")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("CREATED_TIME")
                        .HasColumnType("time");

                    b.Property<string>("CUSTOMER_ADRESS")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("CUSTOMER_CREATOR")
                        .HasColumnType("int");

                    b.Property<string>("CUSTOMER_MAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("CUSTOMER_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("CUSTOMER_PHONE_NO")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<bool>("CUSTOMER_STATUS")
                        .HasColumnType("bit");

                    b.Property<string>("CUSTOMER_TYPE")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.HasIndex("CUSTOMER_CREATOR");

                    b.ToTable("CUSTOMERS");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CREATED_DATE = new DateTime(2019, 12, 5, 12, 33, 2, 113, DateTimeKind.Local).AddTicks(2251),
                            CREATED_TIME = new TimeSpan(451821132260),
                            CUSTOMER_ADRESS = "Maltepe/Istanbul",
                            CUSTOMER_CREATOR = 2,
                            CUSTOMER_MAIL = "shell123@shell.com.tr",
                            CUSTOMER_NAME = "Shell",
                            CUSTOMER_PHONE_NO = "021632145215",
                            CUSTOMER_STATUS = true,
                            CUSTOMER_TYPE = "Indirect"
                        },
                        new
                        {
                            ID = 2,
                            CREATED_DATE = new DateTime(2019, 12, 5, 12, 33, 2, 113, DateTimeKind.Local).AddTicks(8955),
                            CREATED_TIME = new TimeSpan(451821138989),
                            CUSTOMER_ADRESS = "Fatih/Istanbul",
                            CUSTOMER_CREATOR = 3,
                            CUSTOMER_MAIL = "hhhsssqqq@solen.com.tr",
                            CUSTOMER_NAME = "Şölen",
                            CUSTOMER_PHONE_NO = "02125422311",
                            CUSTOMER_STATUS = true,
                            CUSTOMER_TYPE = "Direct"
                        },
                        new
                        {
                            ID = 3,
                            CREATED_DATE = new DateTime(2019, 12, 5, 12, 33, 2, 113, DateTimeKind.Local).AddTicks(9111),
                            CREATED_TIME = new TimeSpan(451821139113),
                            CUSTOMER_ADRESS = "Kadıköy/Istanbul",
                            CUSTOMER_CREATOR = 1,
                            CUSTOMER_MAIL = "supppp@foriba.com.tr",
                            CUSTOMER_NAME = "Foriba",
                            CUSTOMER_PHONE_NO = "02163112400",
                            CUSTOMER_STATUS = true,
                            CUSTOMER_TYPE = "Direct"
                        });
                });

            modelBuilder.Entity("SHAM.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CREATED_DATE")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("CREATED_TIME")
                        .HasColumnType("time");

                    b.Property<string>("EMPLOYEE_ADRESS")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("EMPLOYEE_CREATOR")
                        .HasColumnType("int");

                    b.Property<string>("EMPLOYEE_MAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("EMPLOYEE_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("EMPLOYEE_PHONE_NO")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.Property<bool>("EMPLOYEE_STATUS")
                        .HasColumnType("bit");

                    b.Property<string>("EMPLOYEE_SURNAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("EMPLOYEE_TITLE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EMPLOYEE_CREATOR");

                    b.HasIndex("EMPLOYEE_TITLE");

                    b.ToTable("EMPLOYEES");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CREATED_DATE = new DateTime(2019, 12, 5, 12, 33, 2, 109, DateTimeKind.Local).AddTicks(7970),
                            CREATED_TIME = new TimeSpan(451821113585),
                            EMPLOYEE_ADRESS = "Sancaktepe/İstanbul",
                            EMPLOYEE_CREATOR = 1,
                            EMPLOYEE_MAIL = "sevinctekin.hasan@gmail.com",
                            EMPLOYEE_NAME = "Hasan",
                            EMPLOYEE_PHONE_NO = "05363403660",
                            EMPLOYEE_STATUS = true,
                            EMPLOYEE_SURNAME = "Sevinçtekin",
                            EMPLOYEE_TITLE = 1
                        },
                        new
                        {
                            ID = 2,
                            CREATED_DATE = new DateTime(2019, 12, 5, 12, 33, 2, 112, DateTimeKind.Local).AddTicks(8449),
                            CREATED_TIME = new TimeSpan(451821128471),
                            EMPLOYEE_ADRESS = "Kartal/İstanbul",
                            EMPLOYEE_CREATOR = 1,
                            EMPLOYEE_MAIL = "aaaaasssddn@gmail.com",
                            EMPLOYEE_NAME = "Ömer Faruk",
                            EMPLOYEE_PHONE_NO = "05322545362",
                            EMPLOYEE_STATUS = true,
                            EMPLOYEE_SURNAME = "Kaya",
                            EMPLOYEE_TITLE = 1
                        },
                        new
                        {
                            ID = 3,
                            CREATED_DATE = new DateTime(2019, 12, 5, 12, 33, 2, 112, DateTimeKind.Local).AddTicks(8741),
                            CREATED_TIME = new TimeSpan(451821128743),
                            EMPLOYEE_ADRESS = "Üsküdar/İstanbul",
                            EMPLOYEE_CREATOR = 2,
                            EMPLOYEE_MAIL = "qwwwweeeqq@gmail.com",
                            EMPLOYEE_NAME = "Fatih",
                            EMPLOYEE_PHONE_NO = "05348796582",
                            EMPLOYEE_STATUS = true,
                            EMPLOYEE_SURNAME = "Balcıoğlu",
                            EMPLOYEE_TITLE = 1
                        });
                });

            modelBuilder.Entity("SHAM.Domain.Entities.Level", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LEVEL_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("ID");

                    b.ToTable("LEVELS");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            LEVEL_NAME = "Accept"
                        },
                        new
                        {
                            ID = 2,
                            LEVEL_NAME = "Planning"
                        },
                        new
                        {
                            ID = 3,
                            LEVEL_NAME = "Design"
                        },
                        new
                        {
                            ID = 4,
                            LEVEL_NAME = "Coding"
                        },
                        new
                        {
                            ID = 5,
                            LEVEL_NAME = "Test"
                        },
                        new
                        {
                            ID = 6,
                            LEVEL_NAME = "Completed"
                        });
                });

            modelBuilder.Entity("SHAM.Domain.Entities.Priority", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PRIORITY_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("PRIORITY");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            PRIORITY_NAME = "SO IMMEDIATE"
                        },
                        new
                        {
                            ID = 2,
                            PRIORITY_NAME = "IMMEDIATE"
                        },
                        new
                        {
                            ID = 3,
                            PRIORITY_NAME = "NORMAL"
                        },
                        new
                        {
                            ID = 4,
                            PRIORITY_NAME = "NOT IMMEDIATE"
                        },
                        new
                        {
                            ID = 5,
                            PRIORITY_NAME = "NOT IMPORTANT"
                        });
                });

            modelBuilder.Entity("SHAM.Domain.Entities.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CREATED_DATE")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("CREATED_TIME")
                        .HasColumnType("time");

                    b.Property<int>("CUSTOMER_NUMBER")
                        .HasColumnType("int");

                    b.Property<DateTime?>("END_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ESTIMATE_END_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ESTIMATE_START_DATE")
                        .HasColumnType("datetime2");

                    b.Property<int>("PROJECT_CREATOR")
                        .HasColumnType("int");

                    b.Property<int>("PROJECT_LEVEL")
                        .HasColumnType("int");

                    b.Property<string>("PROJECT_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("PROJECT_STATUS")
                        .HasColumnType("bit");

                    b.Property<int>("PROJECT_TYPE")
                        .HasColumnType("int");

                    b.Property<DateTime?>("START_DATE")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CUSTOMER_NUMBER");

                    b.HasIndex("PROJECT_CREATOR");

                    b.HasIndex("PROJECT_LEVEL");

                    b.HasIndex("PROJECT_TYPE");

                    b.ToTable("PROJECTS");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CREATED_DATE = new DateTime(2019, 12, 5, 12, 33, 2, 114, DateTimeKind.Local).AddTicks(5748),
                            CREATED_TIME = new TimeSpan(451821145770),
                            CUSTOMER_NUMBER = 3,
                            END_DATE = new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ESTIMATE_END_DATE = new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ESTIMATE_START_DATE = new DateTime(2019, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PROJECT_CREATOR = 2,
                            PROJECT_LEVEL = 1,
                            PROJECT_NAME = "Project Management",
                            PROJECT_STATUS = true,
                            PROJECT_TYPE = 2,
                            START_DATE = new DateTime(2019, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 2,
                            CREATED_DATE = new DateTime(2019, 12, 5, 12, 33, 2, 116, DateTimeKind.Local).AddTicks(4244),
                            CREATED_TIME = new TimeSpan(451821164265),
                            CUSTOMER_NUMBER = 1,
                            END_DATE = new DateTime(2019, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ESTIMATE_END_DATE = new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ESTIMATE_START_DATE = new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PROJECT_CREATOR = 3,
                            PROJECT_LEVEL = 3,
                            PROJECT_NAME = "Game Simulator",
                            PROJECT_STATUS = true,
                            PROJECT_TYPE = 1,
                            START_DATE = new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SHAM.Domain.Entities.ProjectEmployee", b =>
                {
                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.HasKey("ProjectID", "EmployeeID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("ProjectEmployees");

                    b.HasData(
                        new
                        {
                            ProjectID = 1,
                            EmployeeID = 3
                        },
                        new
                        {
                            ProjectID = 1,
                            EmployeeID = 2
                        },
                        new
                        {
                            ProjectID = 2,
                            EmployeeID = 2
                        },
                        new
                        {
                            ProjectID = 2,
                            EmployeeID = 1
                        });
                });

            modelBuilder.Entity("SHAM.Domain.Entities.Project_Type", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TYPE_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("PROJECT_TYPE");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            TYPE_NAME = "Visual"
                        },
                        new
                        {
                            ID = 2,
                            TYPE_NAME = "Object - Oriented"
                        });
                });

            modelBuilder.Entity("SHAM.Domain.Entities.Title", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TITLE_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("TITLES");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            TITLE_NAME = "Junior"
                        },
                        new
                        {
                            ID = 2,
                            TITLE_NAME = "Senior"
                        });
                });

            modelBuilder.Entity("SHAM.Domain.Entities.Activity", b =>
                {
                    b.HasOne("SHAM.Domain.Entities.Employee", "CREATED_EMPLOYEE")
                        .WithMany("CREATED_ACTIVITY")
                        .HasForeignKey("ACTIVITY_CREATOR")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SHAM.Domain.Entities.Priority", "PRIORITY")
                        .WithMany("ACTIVITIES")
                        .HasForeignKey("ACTIVITY_PRIORITY")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SHAM.Domain.Entities.Project", "PROJECT")
                        .WithMany("ACTIVITIES")
                        .HasForeignKey("PROJECT_NUMBER")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHAM.Domain.Entities.ActivityEmployee", b =>
                {
                    b.HasOne("SHAM.Domain.Entities.Activity", "ACTIVITY")
                        .WithMany("EMPLOYEES")
                        .HasForeignKey("ActivityID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SHAM.Domain.Entities.Employee", "EMPLOYEE")
                        .WithMany("ACTIVITIES")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SHAM.Domain.Entities.Customer", b =>
                {
                    b.HasOne("SHAM.Domain.Entities.Employee", "CREATED_CUSTOMER")
                        .WithMany("CUSTOMERS")
                        .HasForeignKey("CUSTOMER_CREATOR")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SHAM.Domain.Entities.Employee", b =>
                {
                    b.HasOne("SHAM.Domain.Entities.Employee", "CREATED_EMPLOYEE")
                        .WithMany("CREATED_EMPLOYEES")
                        .HasForeignKey("EMPLOYEE_CREATOR")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SHAM.Domain.Entities.Title", "TITLE")
                        .WithMany("EMPLOYEES")
                        .HasForeignKey("EMPLOYEE_TITLE")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SHAM.Domain.Entities.Project", b =>
                {
                    b.HasOne("SHAM.Domain.Entities.Customer", "CUSTOMER")
                        .WithMany("PROJECTS")
                        .HasForeignKey("CUSTOMER_NUMBER")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SHAM.Domain.Entities.Employee", "CREATED_EMPLOYEE")
                        .WithMany("CREATED_PROJECTS")
                        .HasForeignKey("PROJECT_CREATOR")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SHAM.Domain.Entities.Level", "LEVEL")
                        .WithMany("PROJECTS")
                        .HasForeignKey("PROJECT_LEVEL")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SHAM.Domain.Entities.Project_Type", "PROJECT_TYPE_")
                        .WithMany("PROJECTS")
                        .HasForeignKey("PROJECT_TYPE")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SHAM.Domain.Entities.ProjectEmployee", b =>
                {
                    b.HasOne("SHAM.Domain.Entities.Employee", "EMPLOYEE")
                        .WithMany("PROJECTS")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SHAM.Domain.Entities.Project", "PROJECT")
                        .WithMany("EMPLOYEES")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
