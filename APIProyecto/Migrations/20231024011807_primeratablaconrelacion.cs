using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProyecto.Migrations
{
    /// <inheritdoc />
    public partial class primeratablaconrelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_sgc_TipoProducto_TipoProductoIdTipoProducto",
                table: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producto",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_TipoProductoIdTipoProducto",
                table: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "StockMIn",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "StockMa",
                table: "Producto");

            migrationBuilder.RenameTable(
                name: "Producto",
                newName: "sgc_ProductoTab");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "sgc_Cliente");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "sgc_TipoProducto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "sgc_ProductoTab",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sgc_ProductoTab",
                table: "sgc_ProductoTab",
                column: "IdProduto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sgc_Cliente",
                table: "sgc_Cliente",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_sgc_ProductoTab_TipoProductoIdTipoProducto",
                table: "sgc_ProductoTab",
                column: "TipoProductoIdTipoProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_sgc_ProductoTab_sgc_TipoProducto_TipoProductoIdTipoProducto",
                table: "sgc_ProductoTab",
                column: "TipoProductoIdTipoProducto",
                principalTable: "sgc_TipoProducto",
                principalColumn: "IdTipoProducto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sgc_ProductoTab_sgc_TipoProducto_TipoProductoIdTipoProducto",
                table: "sgc_ProductoTab");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sgc_ProductoTab",
                table: "sgc_ProductoTab");

            migrationBuilder.DropIndex(
                name: "IX_sgc_ProductoTab_TipoProductoIdTipoProducto",
                table: "sgc_ProductoTab");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sgc_Cliente",
                table: "sgc_Cliente");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "sgc_TipoProducto");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "sgc_ProductoTab");

            migrationBuilder.RenameTable(
                name: "sgc_ProductoTab",
                newName: "Producto");

            migrationBuilder.RenameTable(
                name: "sgc_Cliente",
                newName: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockMIn",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockMa",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producto",
                table: "Producto",
                column: "IdProduto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_TipoProductoIdTipoProducto",
                table: "Producto",
                column: "TipoProductoIdTipoProducto",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_sgc_TipoProducto_TipoProductoIdTipoProducto",
                table: "Producto",
                column: "TipoProductoIdTipoProducto",
                principalTable: "sgc_TipoProducto",
                principalColumn: "IdTipoProducto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
