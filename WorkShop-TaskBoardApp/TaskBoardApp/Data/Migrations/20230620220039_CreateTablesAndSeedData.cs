using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class CreateTablesAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("3167f05b-8e03-44f8-8354-c7b860b5ef5b"), 1, new DateTime(2023, 1, 21, 1, 0, 38, 747, DateTimeKind.Local).AddTicks(2031), "Create Android client app for the TaskBoard RESTful API", "bdc7d1a9-f7fc-43be-a5c4-75307e710e33", "Android Client App" },
                    { new Guid("42f7bbda-0845-4c1c-bb1e-da4aad101d98"), 1, new DateTime(2022, 12, 3, 1, 0, 38, 747, DateTimeKind.Local).AddTicks(1974), "Implement better styling for all public pages", "5bce5f4e-3c8a-4a30-a3f5-ca0c242ca371", "Improve CSS styles" },
                    { new Guid("786c1be5-a5a5-48a9-8d64-b75deefe4ac8"), 2, new DateTime(2023, 5, 21, 1, 0, 38, 747, DateTimeKind.Local).AddTicks(2039), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "5bce5f4e-3c8a-4a30-a3f5-ca0c242ca371", "Dekstop Client App" },
                    { new Guid("fc3a7cd7-4ec9-44a9-b801-73c7eeba6b61"), 3, new DateTime(2022, 6, 21, 1, 0, 38, 747, DateTimeKind.Local).AddTicks(2046), "Implement [Create Tasks] page for adding new tasks", "5bce5f4e-3c8a-4a30-a3f5-ca0c242ca371", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
