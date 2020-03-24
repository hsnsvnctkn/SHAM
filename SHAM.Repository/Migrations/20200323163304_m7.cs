using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHAM.Repository.Migrations
{
    public partial class m7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "START_TIME",
                schema: "SHAM",
                table: "NOTIFICATION",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "END_TIME",
                schema: "SHAM",
                table: "NOTIFICATION",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 33, 4, 28, DateTimeKind.Local).AddTicks(7541), new TimeSpan(703840287548) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 33, 4, 29, DateTimeKind.Local).AddTicks(3109), new TimeSpan(703840293116) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 33, 4, 27, DateTimeKind.Local).AddTicks(5760), new TimeSpan(703840275766) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 33, 4, 27, DateTimeKind.Local).AddTicks(9288), new TimeSpan(703840279295) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 33, 4, 27, DateTimeKind.Local).AddTicks(9376), new TimeSpan(703840279377) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 33, 4, 26, DateTimeKind.Local).AddTicks(332), new TimeSpan(703840268955) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 33, 4, 27, DateTimeKind.Local).AddTicks(4176), new TimeSpan(703840274183) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 33, 4, 27, DateTimeKind.Local).AddTicks(4280), new TimeSpan(703840274281) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 33, 4, 27, DateTimeKind.Local).AddTicks(4284), new TimeSpan(703840274286) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 33, 4, 27, DateTimeKind.Local).AddTicks(4288), new TimeSpan(703840274290) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 33, 4, 28, DateTimeKind.Local).AddTicks(768), new TimeSpan(703840280776) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 3, 23, 19, 33, 4, 28, DateTimeKind.Local).AddTicks(5994), new TimeSpan(703840286001) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "START_TIME",
                schema: "SHAM",
                table: "NOTIFICATION",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "END_TIME",
                schema: "SHAM",
                table: "NOTIFICATION",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

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
        }
    }
}
