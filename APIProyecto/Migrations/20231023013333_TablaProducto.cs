using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProyecto.Migrations
{
    /// <inheritdoc />
    public partial class TablaProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sgc_Cliente",
                table: "sgc_Cliente");

            migrationBuilder.RenameTable(
                name: "sgc_Cliente",
                newName: "Cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "IdCliente");

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoProductoIdTipoProducto = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    StockMa = table.Column<int>(type: "int", nullable: false),
                    StockMIn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Producto_sgc_TipoProducto_TipoProductoIdTipoProducto",
                        column: x => x.TipoProductoIdTipoProducto,
                        principalTable: "sgc_TipoProducto",
                        principalColumn: "IdTipoProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "IdProduto", "Stock", "StockMIn", "StockMa", "TipoProductoIdTipoProducto" },
                values: new object[] { 1, 100, 50, 200, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_TipoProductoIdTipoProducto",
                table: "Producto",
                column: "TipoProductoIdTipoProducto",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "sgc_Cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sgc_Cliente",
                table: "sgc_Cliente",
                column: "IdCliente");
        }
    }
}
