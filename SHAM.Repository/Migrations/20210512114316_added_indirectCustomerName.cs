using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHAM.Repository.Migrations
{
    public partial class added_indirectCustomerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IndirectCustomerName",
                schema: "SHAM",
                table: "ACTIVITIES",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2021, 5, 12, 14, 43, 15, 460, DateTimeKind.Local).AddTicks(2115), new TimeSpan(529954602122) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2021, 5, 12, 14, 43, 15, 460, DateTimeKind.Local).AddTicks(6767), new TimeSpan(529954606775) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2021, 5, 12, 14, 43, 15, 459, DateTimeKind.Local).AddTicks(2220), new TimeSpan(529954592227) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2021, 5, 12, 14, 43, 15, 459, DateTimeKind.Local).AddTicks(4874), new TimeSpan(529954594881) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2021, 5, 12, 14, 43, 15, 459, DateTimeKind.Local).AddTicks(4885), new TimeSpan(529954594886) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2021, 5, 12, 14, 43, 15, 457, DateTimeKind.Local).AddTicks(3516), new TimeSpan(529954585165) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2021, 5, 12, 14, 43, 15, 459, DateTimeKind.Local).AddTicks(122), new TimeSpan(529954590131) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2021, 5, 12, 14, 43, 15, 459, DateTimeKind.Local).AddTicks(136), new TimeSpan(529954590137) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2021, 5, 12, 14, 43, 15, 459, DateTimeKind.Local).AddTicks(140), new TimeSpan(529954590141) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2021, 5, 12, 14, 43, 15, 459, DateTimeKind.Local).AddTicks(146), new TimeSpan(529954590147) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2021, 5, 12, 14, 43, 15, 459, DateTimeKind.Local).AddTicks(6041), new TimeSpan(529954596048) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2021, 5, 12, 14, 43, 15, 460, DateTimeKind.Local).AddTicks(643), new TimeSpan(529954600651) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndirectCustomerName",
                schema: "SHAM",
                table: "ACTIVITIES");

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 7, 4, 3, 41, 20, 183, DateTimeKind.Local).AddTicks(6908), new TimeSpan(132801836917) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 7, 4, 3, 41, 20, 184, DateTimeKind.Local).AddTicks(1296), new TimeSpan(132801841312) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 7, 4, 3, 41, 20, 182, DateTimeKind.Local).AddTicks(4028), new TimeSpan(132801824037) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 7, 4, 3, 41, 20, 182, DateTimeKind.Local).AddTicks(7429), new TimeSpan(132801827438) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 7, 4, 3, 41, 20, 182, DateTimeKind.Local).AddTicks(7532), new TimeSpan(132801827535) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 7, 4, 3, 41, 20, 180, DateTimeKind.Local).AddTicks(590), new TimeSpan(132801815599) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 7, 4, 3, 41, 20, 182, DateTimeKind.Local).AddTicks(750), new TimeSpan(132801820769) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 7, 4, 3, 41, 20, 182, DateTimeKind.Local).AddTicks(981), new TimeSpan(132801820983) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 7, 4, 3, 41, 20, 182, DateTimeKind.Local).AddTicks(989), new TimeSpan(132801820991) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 7, 4, 3, 41, 20, 182, DateTimeKind.Local).AddTicks(997), new TimeSpan(132801821001) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 7, 4, 3, 41, 20, 183, DateTimeKind.Local).AddTicks(100), new TimeSpan(132801830111) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 7, 4, 3, 41, 20, 183, DateTimeKind.Local).AddTicks(4692), new TimeSpan(132801834707) });
        }
    }
}
