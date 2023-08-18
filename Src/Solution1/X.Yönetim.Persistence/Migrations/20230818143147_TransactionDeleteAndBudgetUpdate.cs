using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace X.Yönetim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TransactionDeleteAndBudgetUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRANSACTİON");

            migrationBuilder.AddColumn<int>(
                name: "BudgetId",
                table: "INCOMES",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BudgetId",
                table: "EXPENSES",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_INCOMES_BudgetId",
                table: "INCOMES",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_EXPENSES_BudgetId",
                table: "EXPENSES",
                column: "BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_EXPENSES_BUDGETS_BudgetId",
                table: "EXPENSES",
                column: "BudgetId",
                principalTable: "BUDGETS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_INCOMES_BUDGETS_BudgetId",
                table: "INCOMES",
                column: "BudgetId",
                principalTable: "BUDGETS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EXPENSES_BUDGETS_BudgetId",
                table: "EXPENSES");

            migrationBuilder.DropForeignKey(
                name: "FK_INCOMES_BUDGETS_BudgetId",
                table: "INCOMES");

            migrationBuilder.DropIndex(
                name: "IX_INCOMES_BudgetId",
                table: "INCOMES");

            migrationBuilder.DropIndex(
                name: "IX_EXPENSES_BudgetId",
                table: "EXPENSES");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "INCOMES");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "EXPENSES");

            migrationBuilder.CreateTable(
                name: "TRANSACTİON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSONID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TRANSACTİON_DATE = table.Column<DateTime>(type: "date", nullable: false),
                    TYPE = table.Column<int>(type: "int", nullable: false),
                    DESCRİPTON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACTİON", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRANSACTİON_USER_PERSONID",
                        column: x => x.PERSONID,
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTİON_PERSONID",
                table: "TRANSACTİON",
                column: "PERSONID");
        }
    }
}
