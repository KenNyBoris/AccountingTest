using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Domain.Migrations
{
    public partial class ManyToManyRelatinshipPositionEmployeeUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Salary = table.Column<decimal>(nullable: false),
                    AppointmentDate = table.Column<DateTime>(nullable: false),
                    DismissalDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionEmployees",
                columns: table => new
                {
                    PositionId = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionEmployees", x => new { x.EmployeeId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_PositionEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionEmployees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AppointmentDate", "DismissalDate", "FirstName", "IsDeleted", "LastName", "Salary" },
                values: new object[,]
                {
                    { new Guid("c890c92c-7826-48dd-a4b0-0c88bdd978ee"), new DateTime(2019, 7, 23, 12, 16, 6, 775, DateTimeKind.Local).AddTicks(4997), null, "Boris", false, "Boguslavskiy", 5000m },
                    { new Guid("327265bc-9211-4696-8b72-8b9c609e3b38"), new DateTime(2018, 7, 23, 12, 16, 6, 777, DateTimeKind.Local).AddTicks(6098), null, "Ivan", false, "Ivanovich", 2000m },
                    { new Guid("e50ffdcc-90e2-41c6-aef4-e9f0ad6261d3"), new DateTime(2014, 7, 23, 12, 16, 6, 777, DateTimeKind.Local).AddTicks(6152), new DateTime(2020, 5, 23, 12, 16, 6, 777, DateTimeKind.Local).AddTicks(6158), "Anton", false, "Antonovich", 9999m }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("b4b007c6-fe83-4ae4-a504-a0c4dc5891d8"), false, "Junior .NET Full-stack" },
                    { new Guid("33562529-4f2e-41b4-86fe-ce2165e61a8c"), false, "Middle .NET Full-stack" },
                    { new Guid("3814ee6b-253f-4be6-ab75-af7b4dd54c86"), false, "Senior .NET Back-end" }
                });

            migrationBuilder.InsertData(
                table: "PositionEmployees",
                columns: new[] { "EmployeeId", "PositionId", "Id", "IsDeleted" },
                values: new object[] { new Guid("c890c92c-7826-48dd-a4b0-0c88bdd978ee"), new Guid("b4b007c6-fe83-4ae4-a504-a0c4dc5891d8"), new Guid("dfd5ea15-f796-4579-9aad-45a2dbd0e2d2"), false });

            migrationBuilder.InsertData(
                table: "PositionEmployees",
                columns: new[] { "EmployeeId", "PositionId", "Id", "IsDeleted" },
                values: new object[] { new Guid("327265bc-9211-4696-8b72-8b9c609e3b38"), new Guid("33562529-4f2e-41b4-86fe-ce2165e61a8c"), new Guid("acdd9f99-4c04-4f26-b408-e6c4fee59fa3"), false });

            migrationBuilder.InsertData(
                table: "PositionEmployees",
                columns: new[] { "EmployeeId", "PositionId", "Id", "IsDeleted" },
                values: new object[] { new Guid("e50ffdcc-90e2-41c6-aef4-e9f0ad6261d3"), new Guid("3814ee6b-253f-4be6-ab75-af7b4dd54c86"), new Guid("dc7b86c5-9869-4b98-af35-c02db3105795"), false });

            migrationBuilder.CreateIndex(
                name: "IX_PositionEmployees_PositionId",
                table: "PositionEmployees",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionEmployees");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
