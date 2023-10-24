using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProyecto.Migrations
{
    /// <inheritdoc />
    public partial class tablaProductoColorTalla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TallaProductIdTallaProducto",
                table: "sgc_ProductoColorTalla",
                newName: "TallaProductoIdTallaProducto");

            migrationBuilder.RenameColumn(
                name: "StockIndi",
                table: "sgc_ProductoColorTalla",
                newName: "StockMin");

            migrationBuilder.RenameColumn(
                name: "ProductoIdProducto",
                table: "sgc_ProductoColorTalla",
                newName: "StockMax");

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "sgc_ProductoColorTalla",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoIdProduto",
                table: "sgc_ProductoColorTalla",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "sgc_ProductoColorTalla",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_sgc_ProductoColorTalla_ColorProductoIdColorProducto",
                table: "sgc_ProductoColorTalla",
                column: "ColorProductoIdColorProducto");

            migrationBuilder.CreateIndex(
                name: "IX_sgc_ProductoColorTalla_ProductoIdProduto",
                table: "sgc_ProductoColorTalla",
                column: "ProductoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_sgc_ProductoColorTalla_TallaProductoIdTallaProducto",
                table: "sgc_ProductoColorTalla",
                column: "TallaProductoIdTallaProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_sgc_ProductoColorTalla_sgc_ColorProducto_ColorProductoIdColorProducto",
                table: "sgc_ProductoColorTalla",
                column: "ColorProductoIdColorProducto",
                principalTable: "sgc_ColorProducto",
                principalColumn: "IdColorProducto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sgc_ProductoColorTalla_sgc_ProductoTab_ProductoIdProduto",
                table: "sgc_ProductoColorTalla",
                column: "ProductoIdProduto",
                principalTable: "sgc_ProductoTab",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sgc_ProductoColorTalla_sgc_TallaProducto_TallaProductoIdTallaProducto",
                table: "sgc_ProductoColorTalla",
                column: "TallaProductoIdTallaProducto",
                principalTable: "sgc_TallaProducto",
                principalColumn: "IdTallaProducto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sgc_ProductoColorTalla_sgc_ColorProducto_ColorProductoIdColorProducto",
                table: "sgc_ProductoColorTalla");

            migrationBuilder.DropForeignKey(
                name: "FK_sgc_ProductoColorTalla_sgc_ProductoTab_ProductoIdProduto",
                table: "sgc_ProductoColorTalla");

            migrationBuilder.DropForeignKey(
                name: "FK_sgc_ProductoColorTalla_sgc_TallaProducto_TallaProductoIdTallaProducto",
                table: "sgc_ProductoColorTalla");

            migrationBuilder.DropIndex(
                name: "IX_sgc_ProductoColorTalla_ColorProductoIdColorProducto",
                table: "sgc_ProductoColorTalla");

            migrationBuilder.DropIndex(
                name: "IX_sgc_ProductoColorTalla_ProductoIdProduto",
                table: "sgc_ProductoColorTalla");

            migrationBuilder.DropIndex(
                name: "IX_sgc_ProductoColorTalla_TallaProductoIdTallaProducto",
                table: "sgc_ProductoColorTalla");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "sgc_ProductoColorTalla");

            migrationBuilder.DropColumn(
                name: "ProductoIdProduto",
                table: "sgc_ProductoColorTalla");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "sgc_ProductoColorTalla");

            migrationBuilder.RenameColumn(
                name: "TallaProductoIdTallaProducto",
                table: "sgc_ProductoColorTalla",
                newName: "TallaProductIdTallaProducto");

            migrationBuilder.RenameColumn(
                name: "StockMin",
                table: "sgc_ProductoColorTalla",
                newName: "StockIndi");

            migrationBuilder.RenameColumn(
                name: "StockMax",
                table: "sgc_ProductoColorTalla",
                newName: "ProductoIdProducto");
        }
    }
}
