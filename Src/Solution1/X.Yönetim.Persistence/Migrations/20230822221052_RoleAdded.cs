using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace X.Yönetim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RoleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ROLE",
                table: "USER");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "ACCOUNTS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "ACCOUNTS");

            migrationBuilder.AddColumn<int>(
                name: "ROLE",
                table: "USER",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 10);
        }
    }
}
