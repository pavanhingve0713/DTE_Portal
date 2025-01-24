using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalEducationPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMstBoard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MstBoards",
                columns: table => new
                {
                    BoardId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardNameEng = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    BoardNameHin = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    BoardCode = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstBoards", x => x.BoardId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MstBoards");
        }
    }
}
