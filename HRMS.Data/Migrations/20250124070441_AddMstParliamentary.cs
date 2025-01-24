using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalEducationPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMstParliamentary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MstParliamentaries",
                columns: table => new
                {
                    ParliamentaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParliamentaryNameEng = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    ParliamentaryNameHin = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    ParliamentaryCode = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstParliamentaries", x => x.ParliamentaryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MstParliamentaries");
        }
    }
}
