using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenManagement.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Keepers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keepers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeeperPlantChart",
                columns: table => new
                {
                    KeepersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeeperPlantChart", x => new { x.KeepersId, x.PlantsId });
                    table.ForeignKey(
                        name: "FK_KeeperPlantChart_Keepers_KeepersId",
                        column: x => x.KeepersId,
                        principalTable: "Keepers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeeperPlantChart_Plants_PlantsId",
                        column: x => x.PlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeeperPlantChart_PlantsId",
                table: "KeeperPlantChart",
                column: "PlantsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeeperPlantChart");

            migrationBuilder.DropTable(
                name: "Keepers");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
