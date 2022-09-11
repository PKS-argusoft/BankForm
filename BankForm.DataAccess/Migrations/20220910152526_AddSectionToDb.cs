using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankForm.DataAccess.Migrations
{
    public partial class AddSectionToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    FKTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_sections_Templates_FKTemplateId",
                        column: x => x.FKTemplateId,
                        principalTable: "Templates",
                        principalColumn: "TemplateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sections_FKTemplateId",
                table: "sections",
                column: "FKTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sections");
        }
    }
}
