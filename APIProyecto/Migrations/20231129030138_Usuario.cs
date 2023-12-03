using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProyecto.Migrations
{
    /// <inheritdoc />
    public partial class Usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sgc_Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroSeguridad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sgc_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.InsertData(
                table: "sgc_Usuarios",
                columns: new[] { "IdUsuario", "Apellido", "Cedula", "Contrasenia", "Login", "Nombre", "NumeroSeguridad" },
                values: new object[] { 1, "APELLIDO USUARIO 1", "1711512663", "CONTRASENIAADMIN", "USUARIOADMIN", "USUARIO 1", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sgc_Usuarios");
        }
    }
}
