using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHAM.Repository.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "SHAM",
                table: "ProjectEmployees",
                keyColumns: new[] { "ProjectID", "EmployeeID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                schema: "SHAM",
                table: "ProjectEmployees",
                keyColumns: new[] { "ProjectID", "EmployeeID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                schema: "SHAM",
                table: "ProjectEmployees",
                keyColumns: new[] { "ProjectID", "EmployeeID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                schema: "SHAM",
                table: "ProjectEmployees",
                keyColumns: new[] { "ProjectID", "EmployeeID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.AlterColumn<string>(
                name: "ACTIVITY_DETAIL",
                schema: "SHAM",
                table: "ACTIVITIES",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "LOCATION" },
                values: new object[] { new DateTime(2020, 3, 12, 12, 53, 39, 413, DateTimeKind.Local).AddTicks(6894), new TimeSpan(464194136911), "Onsite" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "LOCATION" },
                values: new object[] { new DateTime(2020, 3, 12, 12, 53, 39, 415, DateTimeKind.Local).AddTicks(3696), new TimeSpan(464194153739), "Remote" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ACTIVITY_DETAIL",
                schema: "SHAM",
                table: "ACTIVITIES",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "LOCATION" },
                values: new object[] { new DateTime(2020, 3, 10, 12, 21, 16, 791, DateTimeKind.Local).AddTicks(2786), new TimeSpan(444767912794), "Ofiste" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "LOCATION" },
                values: new object[] { new DateTime(2020, 3, 10, 12, 21, 16, 791, DateTimeKind.Local).AddTicks(8655), new TimeSpan(444767918661), "Yerinde" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 10, 12, 21, 16, 789, DateTimeKind.Local).AddTicks(7663), new TimeSpan(444767897672) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 10, 12, 21, 16, 790, DateTimeKind.Local).AddTicks(1349), new TimeSpan(444767901356) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 10, 12, 21, 16, 790, DateTimeKind.Local).AddTicks(1414), new TimeSpan(444767901415) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 10, 12, 21, 16, 787, DateTimeKind.Local).AddTicks(9419), new TimeSpan(444767889510) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 10, 12, 21, 16, 789, DateTimeKind.Local).AddTicks(5490), new TimeSpan(444767895497) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 10, 12, 21, 16, 789, DateTimeKind.Local).AddTicks(5601), new TimeSpan(444767895602) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 10, 12, 21, 16, 789, DateTimeKind.Local).AddTicks(5605), new TimeSpan(444767895607) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 10, 12, 21, 16, 789, DateTimeKind.Local).AddTicks(5611), new TimeSpan(444767895612) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 10, 12, 21, 16, 790, DateTimeKind.Local).AddTicks(3981), new TimeSpan(444767903988) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 10, 12, 21, 16, 791, DateTimeKind.Local).AddTicks(1235), new TimeSpan(444767911243) });

            migrationBuilder.InsertData(
                schema: "SHAM",
                table: "ProjectEmployees",
                columns: new[] { "ProjectID", "EmployeeID" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 1 }
                });
        }
    }
}
