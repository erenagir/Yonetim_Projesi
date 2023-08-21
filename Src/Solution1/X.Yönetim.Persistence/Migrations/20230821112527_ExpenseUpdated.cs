using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace X.Yönetim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ExpenseUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EXPENSES_BUDGETS_BudgetId",
                table: "EXPENSES");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "EXPENSES",
                newName: "BUDGETID");

            migrationBuilder.RenameIndex(
                name: "IX_EXPENSES_BudgetId",
                table: "EXPENSES",
                newName: "IX_EXPENSES_BUDGETID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TRANSACTİON_DATE",
                table: "EXPENSES",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date")
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRİPTİON",
                table: "EXPENSES",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)")
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<int>(
                name: "BUDGETID",
                table: "EXPENSES",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "AMOUNT",
                table: "EXPENSES",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddForeignKey(
                name: "FK_EXPENSES_BUDGETS_BUDGETID",
                table: "EXPENSES",
                column: "BUDGETID",
                principalTable: "BUDGETS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EXPENSES_BUDGETS_BUDGETID",
                table: "EXPENSES");

            migrationBuilder.RenameColumn(
                name: "BUDGETID",
                table: "EXPENSES",
                newName: "BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_EXPENSES_BUDGETID",
                table: "EXPENSES",
                newName: "IX_EXPENSES_BudgetId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TRANSACTİON_DATE",
                table: "EXPENSES",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRİPTİON",
                table: "EXPENSES",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)")
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<int>(
                name: "BudgetId",
                table: "EXPENSES",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "AMOUNT",
                table: "EXPENSES",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddForeignKey(
                name: "FK_EXPENSES_BUDGETS_BudgetId",
                table: "EXPENSES",
                column: "BudgetId",
                principalTable: "BUDGETS",
                principalColumn: "ID");
        }
    }
}
