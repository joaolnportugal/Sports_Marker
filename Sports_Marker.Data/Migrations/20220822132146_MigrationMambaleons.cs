using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sports_Marker.Data.Migrations
{
    public partial class MigrationMambaleons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Marker",
                table: "Marker");

            migrationBuilder.RenameTable(
                name: "Marker",
                newName: "Markers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Markers",
                table: "Markers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Markers",
                table: "Markers");

            migrationBuilder.RenameTable(
                name: "Markers",
                newName: "Marker");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marker",
                table: "Marker",
                column: "Id");
        }
    }
}
