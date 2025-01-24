using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalEducationPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMstBloodGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "MstBloodGroups",
                columns: table => new
                {
                    BloodGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodGroupName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstBloodGroups", x => x.BloodGroupId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MstBloodGroups");

           
        }
    }
}
