using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHAM.Repository.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "LOCATION" },
                values: new object[] { new DateTime(2020, 3, 6, 15, 0, 4, 460, DateTimeKind.Local).AddTicks(7054), new TimeSpan(540044607063), "Onsite" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "LOCATION" },
                values: new object[] { new DateTime(2020, 3, 6, 15, 0, 4, 462, DateTimeKind.Local).AddTicks(8109), new TimeSpan(540044628158), "Remote" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 15, 0, 4, 459, DateTimeKind.Local).AddTicks(254), new TimeSpan(540044590262) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 15, 0, 4, 459, DateTimeKind.Local).AddTicks(4209), new TimeSpan(540044594216) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 15, 0, 4, 459, DateTimeKind.Local).AddTicks(4275), new TimeSpan(540044594277) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 15, 0, 4, 457, DateTimeKind.Local).AddTicks(2900), new TimeSpan(540044581849) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 15, 0, 4, 458, DateTimeKind.Local).AddTicks(7728), new TimeSpan(540044587737) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 15, 0, 4, 458, DateTimeKind.Local).AddTicks(7834), new TimeSpan(540044587836) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 15, 0, 4, 458, DateTimeKind.Local).AddTicks(7841), new TimeSpan(540044587842) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 15, 0, 4, 458, DateTimeKind.Local).AddTicks(7846), new TimeSpan(540044587848) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 15, 0, 4, 459, DateTimeKind.Local).AddTicks(7017), new TimeSpan(540044597025) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 15, 0, 4, 460, DateTimeKind.Local).AddTicks(4890), new TimeSpan(540044604898) });
        }
    }
}
