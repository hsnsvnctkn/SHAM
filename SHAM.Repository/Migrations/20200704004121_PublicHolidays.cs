using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHAM.Repository.Migrations
{
    public partial class PublicHolidays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PUBLICHOLIDAYS",
                schema: "SHAM",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    kind = table.Column<string>(nullable: true),
                    etag = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    htmlLink = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(nullable: false),
                    updated = table.Column<DateTime>(nullable: false),
                    summary = table.Column<string>(nullable: true),
                    start = table.Column<DateTime>(nullable: false),
                    end = table.Column<DateTime>(nullable: false),
                    transparency = table.Column<string>(nullable: true),
                    visibility = table.Column<string>(nullable: true),
                    iCalUID = table.Column<string>(nullable: true),
                    sequence = table.Column<int>(nullable: false),
                    lastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUBLICHOLIDAYS", x => x.id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PUBLICHOLIDAYS",
                schema: "SHAM");

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 4, 9, 3, 52, 20, 909, DateTimeKind.Local).AddTicks(3936), new TimeSpan(139409093944) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 4, 9, 3, 52, 20, 910, DateTimeKind.Local).AddTicks(134), new TimeSpan(139409100141) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 4, 9, 3, 52, 20, 908, DateTimeKind.Local).AddTicks(635), new TimeSpan(139409080643) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 4, 9, 3, 52, 20, 908, DateTimeKind.Local).AddTicks(4593), new TimeSpan(139409084600) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 4, 9, 3, 52, 20, 908, DateTimeKind.Local).AddTicks(4662), new TimeSpan(139409084664) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 4, 9, 3, 52, 20, 906, DateTimeKind.Local).AddTicks(1324), new TimeSpan(139409071048) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 4, 9, 3, 52, 20, 907, DateTimeKind.Local).AddTicks(8101), new TimeSpan(139409078113) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 4, 9, 3, 52, 20, 907, DateTimeKind.Local).AddTicks(8244), new TimeSpan(139409078247) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 4, 9, 3, 52, 20, 907, DateTimeKind.Local).AddTicks(8251), new TimeSpan(139409078254) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 4, 9, 3, 52, 20, 907, DateTimeKind.Local).AddTicks(8261), new TimeSpan(139409078263) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 4, 9, 3, 52, 20, 908, DateTimeKind.Local).AddTicks(6254), new TimeSpan(139409086261) });

            migrationBuilder.UpdateData(
                schema: "SHAM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2020, 4, 9, 3, 52, 20, 909, DateTimeKind.Local).AddTicks(2222), new TimeSpan(139409092228) });
        }
    }
}
