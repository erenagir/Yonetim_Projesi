using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace X.Yönetim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class firstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    IDENTITY_NUMBER = table.Column<string>(type: "nchar(11)", nullable: false),
                    BIRTHDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "nchar(13)", nullable: false),
                    GENDER = table.Column<int>(type: "int", nullable: false),
                    ROLE = table.Column<int>(type: "int", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    USER_NAME = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LAST_LOGIN_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LAST_LOGIN_IP = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNTS", x => x.ID);
                    table.ForeignKey(
                        name: "ACCOUNT_PERSON_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BUDGETS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSONID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    STARTDATE = table.Column<DateTime>(type: "date", nullable: false),
                    ENDDATE = table.Column<DateTime>(type: "date", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUDGETS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BUDGETS_USER_PERSONID",
                        column: x => x.PERSONID,
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "EXPENSES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSONID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TRANSACTİON_DATE = table.Column<DateTime>(type: "date", nullable: false),
                    DESCRİPTİON = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPENSES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EXPENSES_USER_PERSONID",
                        column: x => x.PERSONID,
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GOALS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSONID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TARGET_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TARGET_DATE = table.Column<DateTime>(type: "date", nullable: false),
                    DESCRİPTİON = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GOALS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GOALS_USER_PERSONID",
                        column: x => x.PERSONID,
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "INCOMES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSONID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TRANSACTION_DATE = table.Column<DateTime>(type: "date", nullable: false),
                    DESCRİPTİON = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INCOMES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INCOMES_USER_PERSONID",
                        column: x => x.PERSONID,
                        principalTable: "USER",
                        principalColumn: "ID");
                });

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

            migrationBuilder.CreateTable(
                name: "USER_IMAGES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    PATH = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_IMAGES", x => x.ID);
                    table.ForeignKey(
                        name: "USER_IMAGE_USER_USER_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_PERSON_ID",
                table: "ACCOUNTS",
                column: "PERSON_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BUDGETS_PERSONID",
                table: "BUDGETS",
                column: "PERSONID");

            migrationBuilder.CreateIndex(
                name: "IX_EXPENSES_PERSONID",
                table: "EXPENSES",
                column: "PERSONID");

            migrationBuilder.CreateIndex(
                name: "IX_GOALS_PERSONID",
                table: "GOALS",
                column: "PERSONID");

            migrationBuilder.CreateIndex(
                name: "IX_INCOMES_PERSONID",
                table: "INCOMES",
                column: "PERSONID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTİON_PERSONID",
                table: "TRANSACTİON",
                column: "PERSONID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_IMAGES_PRODUCT_ID",
                table: "USER_IMAGES",
                column: "PRODUCT_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCOUNTS");

            migrationBuilder.DropTable(
                name: "BUDGETS");

            migrationBuilder.DropTable(
                name: "EXPENSES");

            migrationBuilder.DropTable(
                name: "GOALS");

            migrationBuilder.DropTable(
                name: "INCOMES");

            migrationBuilder.DropTable(
                name: "TRANSACTİON");

            migrationBuilder.DropTable(
                name: "USER_IMAGES");

            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
