using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.ReferenceMyData.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubscribeFilm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscribeFilmsData = table.Column<string>(type: "nvarchar(355)", maxLength: 355, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribeFilm", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscribeFilm");
        }
    }
}
