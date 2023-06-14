using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.Migrations
{
    public partial class UpdatePostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("829b828d-4a5e-4185-8384-f97dc98aacee"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("9598541f-1d27-44a9-b7dc-db227d027fde"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("bdb70bea-9554-4bbd-9fa9-8254138a3dc0"));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("029f539a-607d-46f5-9d18-75c886935d30"), "This is my third post. CRUD operations in MVC. It's so much fun!", "My first post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("4ca50236-acaf-4043-84f7-cd18d87134b9"), "This is my second post. CRUD operations in MVC. It's so much fun!", "My second post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("549bee0f-507b-497e-bf07-c1088c1aadee"), "My first post will be about performing CRUD operations in MVC. It's so much fun!", "My first post" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("029f539a-607d-46f5-9d18-75c886935d30"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("4ca50236-acaf-4043-84f7-cd18d87134b9"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("549bee0f-507b-497e-bf07-c1088c1aadee"));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("829b828d-4a5e-4185-8384-f97dc98aacee"), "This is my second post. CRUD operations in MVC. It's so much fun!", "My second post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("9598541f-1d27-44a9-b7dc-db227d027fde"), "This is my third post. CRUD operations in MVC. It's so much fun!", "My first post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("bdb70bea-9554-4bbd-9fa9-8254138a3dc0"), "My first post will be about performing CRUD operations in MVC. It's so much fun!", "My first post" });
        }
    }
}
