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
                    LEVEL_NAME = table.Column<string>(maxLength: 15, nullable: false),
                    i = table.Column<int>(nullable: false)
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
                    EMPLOYEE_PHONE_NO = table.Column<string>(maxLength: 14, nullable: false),
                    EMPLOYEE_ADRESS = table.Column<string>(maxLength: 100, nullable: false),
                    EMPLOYEE_MAIL = table.Column<string>(maxLength: 50, nullable: false),
                    EMPLOYEE_STATUS = table.Column<bool>(nullable: false),
                    EMPLOYEE_TITLE = table.Column<int>(nullable: false),
                    EMPLOYEE_CREATOR = table.Column<int>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_TIME = table.Column<TimeSpan>(nullable: false),
                    PASSWORD = table.Column<string>(nullable: false),
                    ROLE = table.Column<string>(nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_TITLES_EMPLOYEE_TITLE",
                        column: x => x.EMPLOYEE_TITLE,
                        principalSchema: "SHAM",
                        principalTable: "TITLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROJECTS_EMPLOYEES_PROJECT_CREATOR",
                        column: x => x.PROJECT_CREATOR,
                        principalSchema: "SHAM",
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROJECTS_LEVELS_PROJECT_LEVEL",
                        column: x => x.PROJECT_LEVEL,
                        principalSchema: "SHAM",
                        principalTable: "LEVELS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROJECTS_PROJECT_TYPE_PROJECT_TYPE",
                        column: x => x.PROJECT_TYPE,
                        principalSchema: "SHAM",
                        principalTable: "PROJECT_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                    ACTIVITY_CREATOR = table.Column<int>(nullable: false),
                    ACTIVITY_EMPLOYEE = table.Column<int>(nullable: false),
                    ACTIVITY_DATE = table.Column<DateTime>(nullable: false),
                    START_TIME = table.Column<TimeSpan>(nullable: false),
                    END_TIME = table.Column<TimeSpan>(nullable: false),
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
                        name: "FK_ACTIVITIES_EMPLOYEES_ACTIVITY_CREATOR",
                        column: x => x.ACTIVITY_CREATOR,
                        principalSchema: "SHAM",
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACTIVITIES_EMPLOYEES_ACTIVITY_EMPLOYEE",
                        column: x => x.ACTIVITY_EMPLOYEE,
                        principalSchema: "SHAM",
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ACTIVITIES_PRIORITY_ACTIVITY_PRIORITY",
                        column: x => x.ACTIVITY_PRIORITY,
                        principalSchema: "SHAM",
                        principalTable: "PRIORITY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACTIVITIES_PROJECTS_PROJECT_NUMBER",
                        column: x => x.PROJECT_NUMBER,
                        principalSchema: "SHAM",
                        principalTable: "PROJECTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_PROJECTS_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "SHAM",
                        principalTable: "PROJECTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "LEVELS",
                columns: new[] { "ID", "LEVEL_NAME", "i" },
                values: new object[,]
                {
                    { 1, "Accept", 1 },
                    { 2, "Planning", 2 },
                    { 3, "Design", 3 },
                    { 4, "Coding", 4 },
                    { 5, "Test", 5 },
                    { 6, "Completed", 6 }
                });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "PRIORITY",
                columns: new[] { "ID", "PRIORITY_NAME" },
                values: new object[,]
                {
                    { 1, "SO IMMEDIATE" },
                    { 2, "IMMEDIATE" },
                    { 3, "NORMAL" },
                    { 4, "NOT IMMEDIATE" },
                    { 5, "NOT IMPORTANT" }
                });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "PROJECT_TYPE",
                columns: new[] { "ID", "TYPE_NAME" },
                values: new object[,]
                {
                    { 1, "Visual" },
                    { 2, "Object - Oriented" }
                });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "TITLES",
                columns: new[] { "ID", "TITLE_NAME" },
                values: new object[,]
                {
                    { 1, "Junior" },
                    { 2, "Senior" }
                });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "EMPLOYEES",
                columns: new[] { "ID", "CREATED_DATE", "CREATED_TIME", "EMPLOYEE_ADRESS", "EMPLOYEE_CREATOR", "EMPLOYEE_MAIL", "EMPLOYEE_NAME", "EMPLOYEE_PHONE_NO", "EMPLOYEE_STATUS", "EMPLOYEE_SURNAME", "EMPLOYEE_TITLE", "PASSWORD", "ROLE" },
                values: new object[] { 1, new DateTime(2020, 2, 22, 20, 39, 46, 906, DateTimeKind.Local).AddTicks(2025), new TimeSpan(743869070635), "Sancaktepe/İstanbul", 1, "hasan.sevinctekin@sagita.com.tr", "Hasan", "5363403660", true, "Sevinçtekin", 1, "test", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "CUSTOMERS",
                columns: new[] { "ID", "CREATED_DATE", "CREATED_TIME", "CUSTOMER_ADRESS", "CUSTOMER_CREATOR", "CUSTOMER_MAIL", "CUSTOMER_NAME", "CUSTOMER_PHONE_NO", "CUSTOMER_STATUS", "CUSTOMER_TYPE" },
                values: new object[] { 3, new DateTime(2020, 2, 22, 20, 39, 46, 908, DateTimeKind.Local).AddTicks(1520), new TimeSpan(743869081521), "Kadıköy/Istanbul", 1, "supppp@foriba.com.tr", "Foriba", "2163112400", true, "Direct" });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "EMPLOYEES",
                columns: new[] { "ID", "CREATED_DATE", "CREATED_TIME", "EMPLOYEE_ADRESS", "EMPLOYEE_CREATOR", "EMPLOYEE_MAIL", "EMPLOYEE_NAME", "EMPLOYEE_PHONE_NO", "EMPLOYEE_STATUS", "EMPLOYEE_SURNAME", "EMPLOYEE_TITLE", "PASSWORD", "ROLE" },
                values: new object[] { 2, new DateTime(2020, 2, 22, 20, 39, 46, 907, DateTimeKind.Local).AddTicks(6147), new TimeSpan(743869076154), "Kartal/İstanbul", 1, "omer.kaya@sagita.com.tr", "Ömer Faruk", "5550000000", true, "Kaya", 2, "test", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "CUSTOMERS",
                columns: new[] { "ID", "CREATED_DATE", "CREATED_TIME", "CUSTOMER_ADRESS", "CUSTOMER_CREATOR", "CUSTOMER_MAIL", "CUSTOMER_NAME", "CUSTOMER_PHONE_NO", "CUSTOMER_STATUS", "CUSTOMER_TYPE" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 2, 22, 20, 39, 46, 907, DateTimeKind.Local).AddTicks(7852), new TimeSpan(743869077860), "Maltepe/Istanbul", 2, "shell123@shell.com.tr", "Shell", "21632145215", true, "Indirect" },
                    { 2, new DateTime(2020, 2, 22, 20, 39, 46, 908, DateTimeKind.Local).AddTicks(1414), new TimeSpan(743869081420), "Fatih/Istanbul", 2, "hhhsssqqq@solen.com.tr", "Şölen", "2125422311", true, "Direct" }
                });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "EMPLOYEES",
                columns: new[] { "ID", "CREATED_DATE", "CREATED_TIME", "EMPLOYEE_ADRESS", "EMPLOYEE_CREATOR", "EMPLOYEE_MAIL", "EMPLOYEE_NAME", "EMPLOYEE_PHONE_NO", "EMPLOYEE_STATUS", "EMPLOYEE_SURNAME", "EMPLOYEE_TITLE", "PASSWORD", "ROLE" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 2, 22, 20, 39, 46, 907, DateTimeKind.Local).AddTicks(6271), new TimeSpan(743869076272), "Üsküdar/İstanbul", 2, "fatih.balcioglu@sagita.com.tr", "Fatih", "5550000000", true, "Balcıoğlu", 2, "test", "ADMIN" },
                    { 4, new DateTime(2020, 2, 22, 20, 39, 46, 907, DateTimeKind.Local).AddTicks(6276), new TimeSpan(743869076277), "Üsküdar/İstanbul", 2, "yunus.gulbeyen@sagita.com.tr", "Yunus", "5550000000", true, "Gülbeyen", 2, "test", "NORMAL" },
                    { 5, new DateTime(2020, 2, 22, 20, 39, 46, 907, DateTimeKind.Local).AddTicks(6280), new TimeSpan(743869076281), "Üsküdar/İstanbul", 2, "ufuk@sagita.com.tr", "Ufuk", "5550000000", true, "Çelik", 2, "test", "NORMAL" }
                });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "PROJECTS",
                columns: new[] { "ID", "CREATED_DATE", "CREATED_TIME", "CUSTOMER_NUMBER", "END_DATE", "ESTIMATE_END_DATE", "ESTIMATE_START_DATE", "PROJECT_CREATOR", "PROJECT_LEVEL", "PROJECT_NAME", "PROJECT_STATUS", "PROJECT_TYPE", "START_DATE" },
                values: new object[] { 1, new DateTime(2020, 2, 22, 20, 39, 46, 908, DateTimeKind.Local).AddTicks(4165), new TimeSpan(743869084173), 3, new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Project Management", true, 2, new DateTime(2019, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "ACTIVITIES",
                columns: new[] { "ID", "ACTIVITY_CREATOR", "ACTIVITY_DATE", "ACTIVITY_DETAIL", "ACTIVITY_EMPLOYEE", "ACTIVITY_PRIORITY", "ACTIVITY_STATUS", "CREATED_DATE", "CREATED_TIME", "END_TIME", "INVOICE", "PROJECT_NUMBER", "START_TIME" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2019, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Send to Shell when finished", 1, 3, false, new DateTime(2020, 2, 22, 20, 39, 46, 909, DateTimeKind.Local).AddTicks(2940), new TimeSpan(743869092946), new TimeSpan(0, 18, 15, 0, 0), false, 1, new TimeSpan(0, 10, 45, 0, 0) },
                    { 2, 2, new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Notify Mr. Kaya when finished", 3, 3, true, new DateTime(2020, 2, 22, 20, 39, 46, 909, DateTimeKind.Local).AddTicks(9579), new TimeSpan(743869099586), new TimeSpan(0, 19, 25, 0, 0), false, 1, new TimeSpan(0, 11, 45, 0, 0) }
                });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "PROJECTS",
                columns: new[] { "ID", "CREATED_DATE", "CREATED_TIME", "CUSTOMER_NUMBER", "END_DATE", "ESTIMATE_END_DATE", "ESTIMATE_START_DATE", "PROJECT_CREATOR", "PROJECT_LEVEL", "PROJECT_NAME", "PROJECT_STATUS", "PROJECT_TYPE", "START_DATE" },
                values: new object[] { 2, new DateTime(2020, 2, 22, 20, 39, 46, 909, DateTimeKind.Local).AddTicks(1263), new TimeSpan(743869091269), 1, new DateTime(2019, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Game Simulator", true, 1, new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "ProjectEmployees",
                columns: new[] { "ProjectID", "EmployeeID" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "ProjectEmployees",
                columns: new[] { "ProjectID", "EmployeeID" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "ProjectEmployees",
                columns: new[] { "ProjectID", "EmployeeID" },
                values: new object[] { 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITIES_ACTIVITY_CREATOR",
                schema: "SHAM",
                table: "ACTIVITIES",
                column: "ACTIVITY_CREATOR");

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITIES_ACTIVITY_EMPLOYEE",
                schema: "SHAM",
                table: "ACTIVITIES",
                column: "ACTIVITY_EMPLOYEE");

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITIES_ACTIVITY_PRIORITY",
                schema: "SHAM",
                table: "ACTIVITIES",
                column: "ACTIVITY_PRIORITY");

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITIES_PROJECT_NUMBER",
                schema: "SHAM",
                table: "ACTIVITIES",
                column: "PROJECT_NUMBER");

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
                name: "ACTIVITIES",
                schema: "SHAM");

            migrationBuilder.DropTable(
                name: "ProjectEmployees",
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
