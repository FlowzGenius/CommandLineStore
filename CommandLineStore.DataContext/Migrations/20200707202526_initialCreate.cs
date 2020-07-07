using Microsoft.EntityFrameworkCore.Migrations;

namespace CommandLineStore.DataContext.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommandLines",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    HowTo = table.Column<string>(maxLength: 500, nullable: false),
                    Line = table.Column<string>(maxLength: 100, nullable: false),
                    PlatForm = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandLines", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandLines");
        }
    }
}
