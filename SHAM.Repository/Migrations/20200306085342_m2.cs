using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHAM.Repository.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "END_TIME",
                schema: "SHAM",
                table: "ACTIVITIES",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "ACTIVITY_DETAIL",
                schema: "SHAM",
                table: "ACTIVITIES",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "LOCATION",
                schema: "SHAM",
                table: "ACTIVITIES",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WHOUR",
                schema: "SHAM",
                table: "ACTIVITIES",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ACTIVITY_CREATOR", "CREATED_DATE", "CREATED_TIME", "LOCATION", "WHOUR" },
                values: new object[] { 1, new DateTime(2020, 3, 6, 11, 53, 41, 774, DateTimeKind.Local).AddTicks(9589), new TimeSpan(428217749607), "Onsite", 8 });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ACTIVITY_CREATOR", "CREATED_DATE", "CREATED_TIME", "END_TIME", "LOCATION", "WHOUR" },
                values: new object[] { 3, new DateTime(2020, 3, 6, 11, 53, 41, 776, DateTimeKind.Local).AddTicks(2321), new TimeSpan(428217762334), null, "Remote", 4 });

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
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "PASSWORD" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 768, DateTimeKind.Local).AddTicks(4725), new TimeSpan(428217700243), "qPHubpjeaXvlBFg8JJb0DA==" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "PASSWORD" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 771, DateTimeKind.Local).AddTicks(744), new TimeSpan(428217710765), "qPHubpjeaXvlBFg8JJb0DA==" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "PASSWORD" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 771, DateTimeKind.Local).AddTicks(934), new TimeSpan(428217710937), "qPHubpjeaXvlBFg8JJb0DA==" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "PASSWORD" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 771, DateTimeKind.Local).AddTicks(943), new TimeSpan(428217710945), "qPHubpjeaXvlBFg8JJb0DA==" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "EMPLOYEE_MAIL", "PASSWORD" },
                values: new object[] { new DateTime(2020, 3, 6, 11, 53, 41, 771, DateTimeKind.Local).AddTicks(950), new TimeSpan(428217710952), "ufuk.celik@sagita.com.tr", "qPHubpjeaXvlBFg8JJb0DA==" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LOCATION",
                schema: "SHAM",
                table: "ACTIVITIES");

            migrationBuilder.DropColumn(
                name: "WHOUR",
                schema: "SHAM",
                table: "ACTIVITIES");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "END_TIME",
                schema: "SHAM",
                table: "ACTIVITIES",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ACTIVITY_DETAIL",
                schema: "SHAM",
                table: "ACTIVITIES",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ACTIVITY_CREATOR", "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { 2, new DateTime(2020, 2, 22, 20, 39, 46, 909, DateTimeKind.Local).AddTicks(2940), new TimeSpan(743869092946) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ACTIVITY_CREATOR", "CREATED_DATE", "CREATED_TIME", "END_TIME" },
                values: new object[] { 2, new DateTime(2020, 2, 22, 20, 39, 46, 909, DateTimeKind.Local).AddTicks(9579), new TimeSpan(743869099586), new TimeSpan(0, 19, 25, 0, 0) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 2, 22, 20, 39, 46, 907, DateTimeKind.Local).AddTicks(7852), new TimeSpan(743869077860) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 2, 22, 20, 39, 46, 908, DateTimeKind.Local).AddTicks(1414), new TimeSpan(743869081420) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 2, 22, 20, 39, 46, 908, DateTimeKind.Local).AddTicks(1520), new TimeSpan(743869081521) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "PASSWORD" },
                values: new object[] { new DateTime(2020, 2, 22, 20, 39, 46, 906, DateTimeKind.Local).AddTicks(2025), new TimeSpan(743869070635), "test" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "PASSWORD" },
                values: new object[] { new DateTime(2020, 2, 22, 20, 39, 46, 907, DateTimeKind.Local).AddTicks(6147), new TimeSpan(743869076154), "test" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "PASSWORD" },
                values: new object[] { new DateTime(2020, 2, 22, 20, 39, 46, 907, DateTimeKind.Local).AddTicks(6271), new TimeSpan(743869076272), "test" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "PASSWORD" },
                values: new object[] { new DateTime(2020, 2, 22, 20, 39, 46, 907, DateTimeKind.Local).AddTicks(6276), new TimeSpan(743869076277), "test" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "CREATED_TIME", "EMPLOYEE_MAIL", "PASSWORD" },
                values: new object[] { new DateTime(2020, 2, 22, 20, 39, 46, 907, DateTimeKind.Local).AddTicks(6280), new TimeSpan(743869076281), "ufuk@sagita.com.tr", "test" });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 2, 22, 20, 39, 46, 908, DateTimeKind.Local).AddTicks(4165), new TimeSpan(743869084173) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 2, 22, 20, 39, 46, 909, DateTimeKind.Local).AddTicks(1263), new TimeSpan(743869091269) });
        }
    }
}
