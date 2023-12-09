using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProyecto.Migrations
{
    /// <inheritdoc />
    public partial class cambiodato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PrecioTotal",
                table: "sgc_Descripcion",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "PrecioTotal",
                table: "sgc_Descripcion",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
