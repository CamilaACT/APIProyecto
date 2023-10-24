using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProyecto.Migrations
{
    /// <inheritdoc />
    public partial class CreacionBaseDatosyTablasReferenciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sgc_Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTarjeta = table.Column<int>(type: "int", nullable: false),
                    NumeroSeguridad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sgc_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "sgc_ColorProducto",
                columns: table => new
                {
                    IdColorProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sgc_ColorProducto", x => x.IdColorProducto);
                });

            migrationBuilder.CreateTable(
                name: "sgc_TallaProducto",
                columns: table => new
                {
                    IdTallaProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Talla = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sgc_TallaProducto", x => x.IdTallaProducto);
                });

            migrationBuilder.CreateTable(
                name: "sgc_TipoProducto",
                columns: table => new
                {
                    IdTipoProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sgc_TipoProducto", x => x.IdTipoProducto);
                });

            migrationBuilder.InsertData(
                table: "sgc_Cliente",
                columns: new[] { "IdCliente", "Apellido", "Cedula", "Direccion", "Nombre", "NumeroSeguridad", "NumeroTarjeta" },
                values: new object[] { 1, "APELLIDO CLEINTE 1", "1711512663", "DIRECCION CLIETE", "CLIENTE 1", 153, 123234345 });

            migrationBuilder.InsertData(
                table: "sgc_ColorProducto",
                columns: new[] { "IdColorProducto", "Nombre" },
                values: new object[] { 1, "Café" });

            migrationBuilder.InsertData(
                table: "sgc_TallaProducto",
                columns: new[] { "IdTallaProducto", "Talla" },
                values: new object[] { 1, "S" });

            migrationBuilder.InsertData(
                table: "sgc_TipoProducto",
                columns: new[] { "IdTipoProducto", "Nombre" },
                values: new object[] { 1, "Pantalones" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sgc_Cliente");

            migrationBuilder.DropTable(
                name: "sgc_ColorProducto");

            migrationBuilder.DropTable(
                name: "sgc_TallaProducto");

            migrationBuilder.DropTable(
                name: "sgc_TipoProducto");
        }
    }
}
