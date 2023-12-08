using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProyecto.Migrations
{
    /// <inheritdoc />
    public partial class tablascompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sgc_Factura",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sgc_Factura", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_sgc_Factura_sgc_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "sgc_Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sgc_IntencionCompra",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sgc_IntencionCompra", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_sgc_IntencionCompra_sgc_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "sgc_Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sgc_Descripcion",
                columns: table => new
                {
                    IdDescripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ProductoColorTallaIdProductoColorTalla = table.Column<int>(type: "int", nullable: false),
                    FacturaIdFactura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sgc_Descripcion", x => x.IdDescripcion);
                    table.ForeignKey(
                        name: "FK_sgc_Descripcion_sgc_Factura_FacturaIdFactura",
                        column: x => x.FacturaIdFactura,
                        principalTable: "sgc_Factura",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sgc_Descripcion_sgc_ProductoColorTalla_ProductoColorTallaIdProductoColorTalla",
                        column: x => x.ProductoColorTallaIdProductoColorTalla,
                        principalTable: "sgc_ProductoColorTalla",
                        principalColumn: "IdProductoColorTalla",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sgc_IntencionDescripcion",
                columns: table => new
                {
                    IdDescripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ProductoColorTallaIdProductoColorTalla = table.Column<int>(type: "int", nullable: false),
                    FacturaIdFactura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sgc_IntencionDescripcion", x => x.IdDescripcion);
                    table.ForeignKey(
                        name: "FK_sgc_IntencionDescripcion_sgc_Factura_FacturaIdFactura",
                        column: x => x.FacturaIdFactura,
                        principalTable: "sgc_Factura",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sgc_IntencionDescripcion_sgc_ProductoColorTalla_ProductoColorTallaIdProductoColorTalla",
                        column: x => x.ProductoColorTallaIdProductoColorTalla,
                        principalTable: "sgc_ProductoColorTalla",
                        principalColumn: "IdProductoColorTalla",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sgc_Descripcion_FacturaIdFactura",
                table: "sgc_Descripcion",
                column: "FacturaIdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_sgc_Descripcion_ProductoColorTallaIdProductoColorTalla",
                table: "sgc_Descripcion",
                column: "ProductoColorTallaIdProductoColorTalla");

            migrationBuilder.CreateIndex(
                name: "IX_sgc_Factura_ClienteIdCliente",
                table: "sgc_Factura",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_sgc_IntencionCompra_ClienteIdCliente",
                table: "sgc_IntencionCompra",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_sgc_IntencionDescripcion_FacturaIdFactura",
                table: "sgc_IntencionDescripcion",
                column: "FacturaIdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_sgc_IntencionDescripcion_ProductoColorTallaIdProductoColorTalla",
                table: "sgc_IntencionDescripcion",
                column: "ProductoColorTallaIdProductoColorTalla");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sgc_Descripcion");

            migrationBuilder.DropTable(
                name: "sgc_IntencionCompra");

            migrationBuilder.DropTable(
                name: "sgc_IntencionDescripcion");

            migrationBuilder.DropTable(
                name: "sgc_Factura");
        }
    }
}
