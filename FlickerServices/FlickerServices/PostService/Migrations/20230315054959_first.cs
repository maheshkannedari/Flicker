using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostService.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Posts",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Posts",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "MobileNumber",
                table: "Posts",
                newName: "mobileNumber");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Posts",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Posts",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Posts",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Posts",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "Posts",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Posts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "mobileNumber",
                table: "Posts",
                newName: "MobileNumber");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Posts",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Posts",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Posts",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Posts",
                newName: "Id");
        }
    }
}
