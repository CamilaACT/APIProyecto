using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProyecto.Migrations
{
    /// <inheritdoc />
    public partial class tablaproducttallacolor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "IdProduto",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "sgc_ColorProducto",
                keyColumn: "IdColorProducto",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "sgc_TallaProducto",
                keyColumn: "IdTallaProducto",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "sgc_TipoProducto",
                keyColumn: "IdTipoProducto",
                keyValue: 1);

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

            migrationBuilder.CreateTable(
                name: "sgc_ProductoColorTalla",
                columns: table => new
                {
                    IdProductoColorTalla = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoIdProducto = table.Column<int>(type: "int", nullable: false),
                    ColorProductoIdColorProducto = table.Column<int>(type: "int", nullable: false),
                    TallaProductIdTallaProducto = table.Column<int>(type: "int", nullable: false),
                    StockIndi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sgc_ProductoColorTalla", x => x.IdProductoColorTalla);
                    table.ForeignKey(
                        name: "FK_sgc_ProductoColorTalla_sgc_ColorProducto_ColorProductoIdColorProducto",
                        column: x => x.ColorProductoIdColorProducto,
                        principalTable: "sgc_ColorProducto",
                        principalColumn: "IdColorProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sgc_TallaProducto_ProductoColorTallaIdProductoColorTalla",
                table: "sgc_TallaProducto",
                column: "ProductoColorTallaIdProductoColorTalla");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_ProductoColorTallaIdProductoColorTalla",
                table: "Producto",
                column: "ProductoColorTallaIdProductoColorTalla");

            migrationBuilder.CreateIndex(
                name: "IX_sgc_ProductoColorTalla_ColorProductoIdColorProducto",
                table: "sgc_ProductoColorTalla",
                column: "ColorProductoIdColorProducto",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_sgc_ProductoColorTalla_ProductoColorTallaIdProductoColorTalla",
                table: "Producto",
                column: "ProductoColorTallaIdProductoColorTalla",
                principalTable: "sgc_ProductoColorTalla",
                principalColumn: "IdProductoColorTalla",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sgc_TallaProducto_sgc_ProductoColorTalla_ProductoColorTallaIdProductoColorTalla",
                table: "sgc_TallaProducto",
                column: "ProductoColorTallaIdProductoColorTalla",
                principalTable: "sgc_ProductoColorTalla",
                principalColumn: "IdProductoColorTalla",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_sgc_ProductoColorTalla_ProductoColorTallaIdProductoColorTalla",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_sgc_TallaProducto_sgc_ProductoColorTalla_ProductoColorTallaIdProductoColorTalla",
                table: "sgc_TallaProducto");

            migrationBuilder.DropTable(
                name: "sgc_ProductoColorTalla");

            migrationBuilder.DropIndex(
                name: "IX_sgc_TallaProducto_ProductoColorTallaIdProductoColorTalla",
                table: "sgc_TallaProducto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_ProductoColorTallaIdProductoColorTalla",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "ProductoColorTallaIdProductoColorTalla",
                table: "sgc_TallaProducto");

            migrationBuilder.DropColumn(
                name: "ProductoColorTallaIdProductoColorTalla",
                table: "Producto");

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

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "IdProduto", "Stock", "StockMIn", "StockMa", "TipoProductoIdTipoProducto" },
                values: new object[] { 1, 100, 50, 200, 1 });
        }
    }
}
