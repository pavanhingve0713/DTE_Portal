using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalEducationPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMstPostType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MstPostTypes",
                columns: table => new
                {
                    TypeOfPostId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostNameEng = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PostNameHin = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PostCode = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IPAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstPostTypes", x => x.TypeOfPostId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MstPostTypes");
        }
    }
}
