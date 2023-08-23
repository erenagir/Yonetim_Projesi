using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace X.Yönetim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BugdetUserIdUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PERSON_ID",
                table: "ACCOUNTS",
                newName: "USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_ACCOUNTS_PERSON_ID",
                table: "ACCOUNTS",
                newName: "IX_ACCOUNTS_USER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "ACCOUNTS",
                newName: "PERSON_ID");

            migrationBuilder.RenameIndex(
                name: "IX_ACCOUNTS_USER_ID",
                table: "ACCOUNTS",
                newName: "IX_ACCOUNTS_PERSON_ID");
        }
    }
}
