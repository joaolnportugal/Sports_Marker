using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sports_Marker.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    team = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    teamColor = table.Column<int>(type: "int", nullable: false, defaultValue: 50),
                    fouls = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    goals = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    inGame = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Start = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Stop = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Restart = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Markers");
        }
    }
}
