using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gradiscent.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMergeMappingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MergeMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoadmapItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MergeMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MergeMappings_RoadmapItems_RoadmapItemId",
                        column: x => x.RoadmapItemId,
                        principalTable: "RoadmapItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MergeMappings_EntityId",
                table: "MergeMappings",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MergeMappings_RoadmapItemId",
                table: "MergeMappings",
                column: "RoadmapItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MergeMappings");
        }
    }
}
