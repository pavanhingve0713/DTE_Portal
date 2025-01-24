using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalEducationPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMstCaste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MstCastes",
                columns: table => new
                {
                    CasteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasteNameEng = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    CasteNameHin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIP = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedByIP = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstCastes", x => x.CasteId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MstCastes");
        }
    }
}
