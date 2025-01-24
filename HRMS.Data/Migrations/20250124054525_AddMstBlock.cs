using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalEducationPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMstBlock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MstBlocks",
                columns: table => new
                {
                    BlockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<short>(type: "smallint", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    BlockNameEng = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    BlockNameHin = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    BlockCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "Varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstBlocks", x => x.BlockId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MstBlocks");
        }
    }
}
