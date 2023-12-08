using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProyecto.Migrations
{
    /// <inheritdoc />
    public partial class Relaciondescripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sgc_IntencionDescripcion_sgc_Factura_FacturaIdFactura",
                table: "sgc_IntencionDescripcion");

            migrationBuilder.RenameColumn(
                name: "FacturaIdFactura",
                table: "sgc_IntencionDescripcion",
                newName: "IntencionCompraIdIntencionCompra");

            migrationBuilder.RenameIndex(
                name: "IX_sgc_IntencionDescripcion_FacturaIdFactura",
                table: "sgc_IntencionDescripcion",
                newName: "IX_sgc_IntencionDescripcion_IntencionCompraIdIntencionCompra");

            migrationBuilder.AddForeignKey(
                name: "FK_sgc_IntencionDescripcion_sgc_IntencionCompra_IntencionCompraIdIntencionCompra",
                table: "sgc_IntencionDescripcion",
                column: "IntencionCompraIdIntencionCompra",
                principalTable: "sgc_IntencionCompra",
                principalColumn: "IdIntencionCompra",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sgc_IntencionDescripcion_sgc_IntencionCompra_IntencionCompraIdIntencionCompra",
                table: "sgc_IntencionDescripcion");

            migrationBuilder.RenameColumn(
                name: "IntencionCompraIdIntencionCompra",
                table: "sgc_IntencionDescripcion",
                newName: "FacturaIdFactura");

            migrationBuilder.RenameIndex(
                name: "IX_sgc_IntencionDescripcion_IntencionCompraIdIntencionCompra",
                table: "sgc_IntencionDescripcion",
                newName: "IX_sgc_IntencionDescripcion_FacturaIdFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_sgc_IntencionDescripcion_sgc_Factura_FacturaIdFactura",
                table: "sgc_IntencionDescripcion",
                column: "FacturaIdFactura",
                principalTable: "sgc_Factura",
                principalColumn: "IdFactura",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
