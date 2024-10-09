using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SYS_Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: true),
                    IcNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "SYS_Logins",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pin = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_Logins", x => x.LoginId);
                    table.ForeignKey(
                        name: "FK_SYS_Logins_SYS_Users_LoginId",
                        column: x => x.LoginId,
                        principalTable: "SYS_Users",
                        principalColumn: "UserId");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SYS_Logins");

            migrationBuilder.DropTable(
                name: "SYS_Users");
        }
    }
}
