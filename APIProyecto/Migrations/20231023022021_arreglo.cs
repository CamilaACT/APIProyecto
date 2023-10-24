using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProyecto.Migrations
{
    /// <inheritdoc />
    public partial class arreglo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_sgc_ProductoColorTalla_ProductoColorTallaIdProductoColorTalla",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_sgc_ProductoColorTalla_sgc_ColorProducto_ColorProductoIdColorProducto",
                table: "sgc_ProductoColorTalla");

            migrationBuilder.DropForeignKey(
                name: "FK_sgc_TallaProducto_sgc_ProductoColorTalla_ProductoColorTallaIdProductoColorTalla",
                table: "sgc_TallaProducto");

            migrationBuilder.DropIndex(
                name: "IX_sgc_TallaProducto_ProductoColorTallaIdProductoColorTalla",
                table: "sgc_TallaProducto");

            migrationBuilder.DropIndex(
                name: "IX_sgc_ProductoColorTalla_ColorProductoIdColorProducto",
                table: "sgc_ProductoColorTalla");

            migrationBuilder.DropIndex(
                name: "IX_Producto_ProductoColorTallaIdProductoColorTalla",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "ProductoColorTallaIdProductoColorTalla",
                table: "sgc_TallaProducto");

            migrationBuilder.DropColumn(
                name: "ProductoColorTallaIdProductoColorTalla",
                table: "Producto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductoColorTallaIdProductoColorTalla",
                table: "sgc_TallaProducto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoColorTallaIdProductoColorTalla",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_sgc_TallaProducto_ProductoColorTallaIdProductoColorTalla",
                table: "sgc_TallaProducto",
                column: "ProductoColorTallaIdProductoColorTalla");

            migrationBuilder.CreateIndex(
                name: "IX_sgc_ProductoColorTalla_ColorProductoIdColorProducto",
                table: "sgc_ProductoColorTalla",
                column: "ColorProductoIdColorProducto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_ProductoColorTallaIdProductoColorTalla",
                table: "Producto",
                column: "ProductoColorTallaIdProductoColorTalla");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_sgc_ProductoColorTalla_ProductoColorTallaIdProductoColorTalla",
                table: "Producto",
                column: "ProductoColorTallaIdProductoColorTalla",
                principalTable: "sgc_ProductoColorTalla",
                principalColumn: "IdProductoColorTalla",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sgc_ProductoColorTalla_sgc_ColorProducto_ColorProductoIdColorProducto",
                table: "sgc_ProductoColorTalla",
                column: "ColorProductoIdColorProducto",
                principalTable: "sgc_ColorProducto",
                principalColumn: "IdColorProducto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sgc_TallaProducto_sgc_ProductoColorTalla_ProductoColorTallaIdProductoColorTalla",
                table: "sgc_TallaProducto",
                column: "ProductoColorTallaIdProductoColorTalla",
                principalTable: "sgc_ProductoColorTalla",
                principalColumn: "IdProductoColorTalla",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
