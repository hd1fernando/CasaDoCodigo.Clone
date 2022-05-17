using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaDoCodigo.Clone.Api.Migrations
{
    public partial class CreateState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StateEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateEntity_CountryEntity_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StateEntity_CountryId",
                table: "StateEntity",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StateEntity");
        }
    }
}
