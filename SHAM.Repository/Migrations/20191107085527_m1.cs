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
                        name: "FK_EMPLOYEES_TITLES_EMPLOYEE_TITLE",
                        column: x => x.EMPLOYEE_TITLE,
                        principalSchema: "SHAM",
                        principalTable: "TITLES",
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
                name: "IX_EMPLOYEES_EMPLOYEE_TITLE",
                schema: "SHAM",
                table: "EMPLOYEES",
                column: "EMPLOYEE_TITLE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPLOYEES",
                schema: "SHAM");

            migrationBuilder.DropTable(
                name: "TITLES",
                schema: "SHAM");
        }
    }
}
