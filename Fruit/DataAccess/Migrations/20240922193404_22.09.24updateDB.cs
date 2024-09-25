using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _220924updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usercomments",
                table: "usercomments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_testimonials",
                table: "testimonials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shippings",
                table: "shippings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_payments",
                table: "payments");

            migrationBuilder.RenameTable(
                name: "usercomments",
                newName: "Usercomments");

            migrationBuilder.RenameTable(
                name: "testimonials",
                newName: "Testimonials");

            migrationBuilder.RenameTable(
                name: "shippings",
                newName: "Shippings");

            migrationBuilder.RenameTable(
                name: "payments",
                newName: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "TotalOrderPrice",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usercomments",
                table: "Usercomments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testimonials",
                table: "Testimonials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shippings",
                table: "Shippings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usercomments",
                table: "Usercomments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testimonials",
                table: "Testimonials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shippings",
                table: "Shippings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "TotalOrderPrice",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Usercomments",
                newName: "usercomments");

            migrationBuilder.RenameTable(
                name: "Testimonials",
                newName: "testimonials");

            migrationBuilder.RenameTable(
                name: "Shippings",
                newName: "shippings");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "payments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usercomments",
                table: "usercomments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_testimonials",
                table: "testimonials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shippings",
                table: "shippings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_payments",
                table: "payments",
                column: "Id");
        }
    }
}
