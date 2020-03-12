using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHAM.Repository.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "WHOUR",
                schema: "SHAM",
                table: "ACTIVITIES",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "WHOUR" },
                values: new object[] { new DateTime(2020, 3, 6, 15, 0, 4, 460, DateTimeKind.Local).AddTicks(7054), new TimeSpan(540044607063), 8.0 });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "WHOUR" },
                values: new object[] { new DateTime(2020, 3, 6, 15, 0, 4, 462, DateTimeKind.Local).AddTicks(8109), new TimeSpan(540044628158), 4.4500000000000002 });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WHOUR",
                schema: "SHAM",
                table: "ACTIVITIES",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "WHOUR" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 774, DateTimeKind.Local).AddTicks(9589), new TimeSpan(428217749607), 8 });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "WHOUR" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 776, DateTimeKind.Local).AddTicks(2321), new TimeSpan(428217762334), 4 });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 771, DateTimeKind.Local).AddTicks(4023), new TimeSpan(428217714034) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 772, DateTimeKind.Local).AddTicks(3140), new TimeSpan(428217723159) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 772, DateTimeKind.Local).AddTicks(3305), new TimeSpan(428217723308) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 768, DateTimeKind.Local).AddTicks(4725), new TimeSpan(428217700243) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 771, DateTimeKind.Local).AddTicks(744), new TimeSpan(428217710765) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 771, DateTimeKind.Local).AddTicks(934), new TimeSpan(428217710937) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 771, DateTimeKind.Local).AddTicks(943), new TimeSpan(428217710945) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 771, DateTimeKind.Local).AddTicks(950), new TimeSpan(428217710952) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 772, DateTimeKind.Local).AddTicks(8786), new TimeSpan(428217728802) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 774, DateTimeKind.Local).AddTicks(5011), new TimeSpan(428217745046) });
        }
    }
}
