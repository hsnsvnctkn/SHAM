using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHAM.Repository.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectEmployees",
                schema: "SHAM",
                table: "ProjectEmployees");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEmployees_EmployeeID",
                schema: "SHAM",
                table: "ProjectEmployees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectEmployees",
                schema: "SHAM",
                table: "ProjectEmployees",
                columns: new[] { "EmployeeID", "ProjectID" });

            migrationBuilder.CreateTable(
                name: "NOTIFICATION",
                schema: "SHAM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEXT_INFO = table.Column<string>(nullable: false),
                    START_TIME = table.Column<TimeSpan>(nullable: false),
                    END_TIME = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATION", x => x.ID);
                });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 10, 56, 143, DateTimeKind.Local).AddTicks(8258), new TimeSpan(690561438266) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 10, 56, 144, DateTimeKind.Local).AddTicks(4071), new TimeSpan(690561444078) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 10, 56, 142, DateTimeKind.Local).AddTicks(4965), new TimeSpan(690561424974) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 10, 56, 142, DateTimeKind.Local).AddTicks(9101), new TimeSpan(690561429107) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 10, 56, 142, DateTimeKind.Local).AddTicks(9179), new TimeSpan(690561429180) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 10, 56, 140, DateTimeKind.Local).AddTicks(2339), new TimeSpan(690561410537) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 10, 56, 142, DateTimeKind.Local).AddTicks(3049), new TimeSpan(690561423060) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 10, 56, 142, DateTimeKind.Local).AddTicks(3162), new TimeSpan(690561423163) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 10, 56, 142, DateTimeKind.Local).AddTicks(3167), new TimeSpan(690561423168) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 10, 56, 142, DateTimeKind.Local).AddTicks(3172), new TimeSpan(690561423173) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 10, 56, 143, DateTimeKind.Local).AddTicks(653), new TimeSpan(690561430661) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 10, 56, 143, DateTimeKind.Local).AddTicks(6479), new TimeSpan(690561436486) });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_ProjectID",
                schema: "SHAM",
                table: "ProjectEmployees",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTIFICATION",
                schema: "SHAM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectEmployees",
                schema: "SHAM",
                table: "ProjectEmployees");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEmployees_ProjectID",
                schema: "SHAM",
                table: "ProjectEmployees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectEmployees",
                schema: "SHAM",
                table: "ProjectEmployees",
                columns: new[] { "ProjectID", "EmployeeID" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 12, 12, 53, 39, 413, DateTimeKind.Local).AddTicks(6894), new TimeSpan(464194136911) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 12, 12, 53, 39, 415, DateTimeKind.Local).AddTicks(3696), new TimeSpan(464194153739) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 12, 12, 53, 39, 410, DateTimeKind.Local).AddTicks(3230), new TimeSpan(464194103263) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 12, 12, 53, 39, 411, DateTimeKind.Local).AddTicks(2899), new TimeSpan(464194112934) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 12, 12, 53, 39, 411, DateTimeKind.Local).AddTicks(3089), new TimeSpan(464194113093) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 12, 12, 53, 39, 404, DateTimeKind.Local).AddTicks(6691), new TimeSpan(464194081844) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 12, 12, 53, 39, 409, DateTimeKind.Local).AddTicks(7205), new TimeSpan(464194097245) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 12, 12, 53, 39, 409, DateTimeKind.Local).AddTicks(7504), new TimeSpan(464194097509) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 12, 12, 53, 39, 409, DateTimeKind.Local).AddTicks(7517), new TimeSpan(464194097522) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 12, 12, 53, 39, 409, DateTimeKind.Local).AddTicks(7533), new TimeSpan(464194097537) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 12, 12, 53, 39, 411, DateTimeKind.Local).AddTicks(7469), new TimeSpan(464194117493) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 12, 12, 53, 39, 413, DateTimeKind.Local).AddTicks(2173), new TimeSpan(464194132198) });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_EmployeeID",
                schema: "SHAM",
                table: "ProjectEmployees",
                column: "EmployeeID");
        }
    }
}
