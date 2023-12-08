using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProyecto.Migrations
{
    /// <inheritdoc />
    public partial class ArregloUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroSeguridad",
                table: "sgc_Cliente");

            migrationBuilder.AddColumn<string>(
                name: "Contrasenia",
                table: "sgc_Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "sgc_Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "sgc_Cliente",
                keyColumn: "IdCliente",
                keyValue: 1,
                columns: new[] { "Contrasenia", "Login" },
                values: new object[] { "123", "cliente1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contrasenia",
                table: "sgc_Cliente");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "sgc_Cliente");

            migrationBuilder.AddColumn<int>(
                name: "NumeroSeguridad",
                table: "sgc_Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "sgc_Cliente",
                keyColumn: "IdCliente",
                keyValue: 1,
                column: "NumeroSeguridad",
                value: 153);
        }
    }
}
