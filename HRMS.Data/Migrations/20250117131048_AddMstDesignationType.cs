using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalEducationPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMstDesignationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MstDesignationTypes",
                columns: table => new
                {
                    DesignationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationTypeNameEng = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    DesignationTypeNameHin = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DesignationTypeCode = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIP = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastUpdatedBY = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedByIP = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstDesignationTypes", x => x.DesignationTypeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MstDesignationTypes");
        }
    }
}
