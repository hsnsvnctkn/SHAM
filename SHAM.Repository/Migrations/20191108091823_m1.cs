using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHAM.Repository.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SHAM");

            migrationBuilder.CreateTable(
                name: "LEVELS",
                schema: "SHAM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LEVEL_NAME = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEVELS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRIORITY",
                schema: "SHAM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRIORITY_NAME = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRIORITY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PROJECT_TYPE",
                schema: "SHAM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TYPE_NAME = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_TYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TITLES",
                schema: "SHAM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE_NAME = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TITLES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                schema: "SHAM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMPLOYEE_NAME = table.Column<string>(maxLength: 50, nullable: false),
                    EMPLOYEE_SURNAME = table.Column<string>(maxLength: 50, nullable: false),
                    EMPLOYEE_PHONE_NO = table.Column<string>(maxLength: 13, nullable: false),
                    EMPLOYEE_ADRESS = table.Column<string>(maxLength: 100, nullable: false),
                    EMPLOYEE_MAIL = table.Column<string>(maxLength: 50, nullable: false),
                    EMPLOYEE_STATUS = table.Column<bool>(nullable: false),
                    EMPLOYEE_TITLE = table.Column<int>(nullable: false),
                    EMPLOYEE_CREATOR = table.Column<int>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_TIME = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_EMPLOYEES_EMPLOYEE_CREATOR",
                        column: x => x.EMPLOYEE_CREATOR,
                        principalSchema: "SHAM",
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_TITLES_EMPLOYEE_TITLE",
                        column: x => x.EMPLOYEE_TITLE,
                        principalSchema: "SHAM",
                        principalTable: "TITLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                schema: "SHAM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_NAME = table.Column<string>(maxLength: 30, nullable: false),
                    CUSTOMER_TYPE = table.Column<string>(maxLength: 20, nullable: false),
                    CUSTOMER_PHONE_NO = table.Column<string>(maxLength: 15, nullable: false),
                    CUSTOMER_ADRESS = table.Column<string>(maxLength: 100, nullable: false),
                    CUSTOMER_MAIL = table.Column<string>(maxLength: 40, nullable: false),
                    CUSTOMER_STATUS = table.Column<bool>(nullable: false),
                    CUSTOMER_CREATOR = table.Column<int>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_TIME = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMERS_EMPLOYEES_CUSTOMER_CREATOR",
                        column: x => x.CUSTOMER_CREATOR,
                        principalSchema: "SHAM",
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PROJECTS",
                schema: "SHAM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROJECT_TYPE = table.Column<int>(nullable: false),
                    PROJECT_NAME = table.Column<string>(maxLength: 50, nullable: false),
                    CUSTOMER_NUMBER = table.Column<int>(nullable: false),
                    EMPLOYEE_NUMBER = table.Column<int>(nullable: false),
                    ESTIMATE_START_DATE = table.Column<DateTime>(nullable: false),
                    ESTIMATE_END_DATE = table.Column<DateTime>(nullable: false),
                    START_DATE = table.Column<DateTime>(nullable: false),
                    END_DATE = table.Column<DateTime>(nullable: true),
                    PROJECT_STATUS = table.Column<bool>(nullable: false),
                    PROJECT_LEVEL = table.Column<int>(nullable: false),
                    PROJECT_CREATOR = table.Column<int>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_TIME = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PROJECTS_CUSTOMERS_CUSTOMER_NUMBER",
                        column: x => x.CUSTOMER_NUMBER,
                        principalSchema: "SHAM",
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROJECTS_EMPLOYEES_PROJECT_CREATOR",
                        column: x => x.PROJECT_CREATOR,
                        principalSchema: "SHAM",
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROJECTS_LEVELS_PROJECT_LEVEL",
                        column: x => x.PROJECT_LEVEL,
                        principalSchema: "SHAM",
                        principalTable: "LEVELS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROJECTS_PROJECT_TYPE_PROJECT_TYPE",
                        column: x => x.PROJECT_TYPE,
                        principalSchema: "SHAM",
                        principalTable: "PROJECT_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ACTIVITIES",
                schema: "SHAM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROJECT_NUMBER = table.Column<int>(nullable: false),
                    ACTIVITY_DETAIL = table.Column<string>(maxLength: 100, nullable: false),
                    EMPLOYEE_NUMBER = table.Column<int>(nullable: false),
                    ACTIVITY_CREATOR = table.Column<int>(nullable: false),
                    ESTIMATE_START_DATE = table.Column<DateTime>(nullable: false),
                    ESTIMATE_END_DATE = table.Column<DateTime>(nullable: false),
                    START_DATE = table.Column<DateTime>(nullable: false),
                    END_DATE = table.Column<DateTime>(nullable: true),
                    ACTIVITY_STATUS = table.Column<bool>(nullable: false),
                    ACTIVITY_PRIORITY = table.Column<int>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_TIME = table.Column<TimeSpan>(nullable: false),
                    INVOICE = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTIVITIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACTIVITIES_PRIORITY_ACTIVITY_PRIORITY",
                        column: x => x.ACTIVITY_PRIORITY,
                        principalSchema: "SHAM",
                        principalTable: "PRIORITY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ACTIVITIES_EMPLOYEES_EMPLOYEE_NUMBER",
                        column: x => x.EMPLOYEE_NUMBER,
                        principalSchema: "SHAM",
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ACTIVITIES_PROJECTS_PROJECT_NUMBER",
                        column: x => x.PROJECT_NUMBER,
                        principalSchema: "SHAM",
                        principalTable: "PROJECTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployees",
                schema: "SHAM",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployees", x => new { x.ProjectID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_EMPLOYEES_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "SHAM",
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_PROJECTS_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "SHAM",
                        principalTable: "PROJECTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityEmployees",
                schema: "SHAM",
                columns: table => new
                {
                    ActivityID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityEmployees", x => new { x.ActivityID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_ActivityEmployees_ACTIVITIES_ActivityID",
                        column: x => x.ActivityID,
                        principalSchema: "SHAM",
                        principalTable: "ACTIVITIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityEmployees_EMPLOYEES_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "SHAM",
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "TITLES",
                columns: new[] { "ID", "TITLE_NAME" },
                values: new object[] { 1, "Junior" });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "TITLES",
                columns: new[] { "ID", "TITLE_NAME" },
                values: new object[] { 2, "Senior" });

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITIES_ACTIVITY_PRIORITY",
                schema: "SHAM",
                table: "ACTIVITIES",
                column: "ACTIVITY_PRIORITY");

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITIES_EMPLOYEE_NUMBER",
                schema: "SHAM",
                table: "ACTIVITIES",
                column: "EMPLOYEE_NUMBER");

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITIES_PROJECT_NUMBER",
                schema: "SHAM",
                table: "ACTIVITIES",
                column: "PROJECT_NUMBER");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEmployees_EmployeeID",
                schema: "SHAM",
                table: "ActivityEmployees",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_CUSTOMER_CREATOR",
                schema: "SHAM",
                table: "CUSTOMERS",
                column: "CUSTOMER_CREATOR");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_EMPLOYEE_CREATOR",
                schema: "SHAM",
                table: "EMPLOYEES",
                column: "EMPLOYEE_CREATOR");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_EMPLOYEE_TITLE",
                schema: "SHAM",
                table: "EMPLOYEES",
                column: "EMPLOYEE_TITLE");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_EmployeeID",
                schema: "SHAM",
                table: "ProjectEmployees",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTS_CUSTOMER_NUMBER",
                schema: "SHAM",
                table: "PROJECTS",
                column: "CUSTOMER_NUMBER");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTS_PROJECT_CREATOR",
                schema: "SHAM",
                table: "PROJECTS",
                column: "PROJECT_CREATOR");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTS_PROJECT_LEVEL",
                schema: "SHAM",
                table: "PROJECTS",
                column: "PROJECT_LEVEL");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTS_PROJECT_TYPE",
                schema: "SHAM",
                table: "PROJECTS",
                column: "PROJECT_TYPE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityEmployees",
                schema: "SHAM");

            migrationBuilder.DropTable(
                name: "ProjectEmployees",
                schema: "SHAM");

            migrationBuilder.DropTable(
                name: "ACTIVITIES",
                schema: "SHAM");

            migrationBuilder.DropTable(
                name: "PRIORITY",
                schema: "SHAM");

            migrationBuilder.DropTable(
                name: "PROJECTS",
                schema: "SHAM");

            migrationBuilder.DropTable(
                name: "CUSTOMERS",
                schema: "SHAM");

            migrationBuilder.DropTable(
                name: "LEVELS",
                schema: "SHAM");

            migrationBuilder.DropTable(
                name: "PROJECT_TYPE",
                schema: "SHAM");

            migrationBuilder.DropTable(
                name: "EMPLOYEES",
                schema: "SHAM");

            migrationBuilder.DropTable(
                name: "TITLES",
                schema: "SHAM");
        }
    }
}
