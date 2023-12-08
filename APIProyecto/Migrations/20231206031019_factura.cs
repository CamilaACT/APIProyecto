using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProyecto.Migrations
{
    /// <inheritdoc />
    public partial class factura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sgc_Descripcion_sgc_Factura_FacturaIdFactura",
                table: "sgc_Descripcion");

            migrationBuilder.DropForeignKey(
                name: "FK_sgc_IntencionDescripcion_sgc_Factura_FacturaIdFactura",
                table: "sgc_IntencionDescripcion");

            migrationBuilder.DropIndex(
                name: "IX_sgc_IntencionDescripcion_FacturaIdFactura",
                table: "sgc_IntencionDescripcion");

            migrationBuilder.DropIndex(
                name: "IX_sgc_Descripcion_FacturaIdFactura",
                table: "sgc_Descripcion");

            migrationBuilder.RenameColumn(
                name: "IdFactura",
                table: "sgc_Factura",
                newName: "IdFacturaFinal");

            migrationBuilder.AddColumn<int>(
                name: "FacturaIdFacturaFinal",
                table: "sgc_IntencionDescripcion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacturaIdFacturaFinal",
                table: "sgc_Descripcion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_sgc_IntencionDescripcion_FacturaIdFacturaFinal",
                table: "sgc_IntencionDescripcion",
                column: "FacturaIdFacturaFinal");

            migrationBuilder.CreateIndex(
                name: "IX_sgc_Descripcion_FacturaIdFacturaFinal",
                table: "sgc_Descripcion",
                column: "FacturaIdFacturaFinal");

            migrationBuilder.AddForeignKey(
                name: "FK_sgc_Descripcion_sgc_Factura_FacturaIdFacturaFinal",
                table: "sgc_Descripcion",
                column: "FacturaIdFacturaFinal",
                principalTable: "sgc_Factura",
                principalColumn: "IdFacturaFinal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sgc_IntencionDescripcion_sgc_Factura_FacturaIdFacturaFinal",
                table: "sgc_IntencionDescripcion",
                column: "FacturaIdFacturaFinal",
                principalTable: "sgc_Factura",
                principalColumn: "IdFacturaFinal",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sgc_Descripcion_sgc_Factura_FacturaIdFacturaFinal",
                table: "sgc_Descripcion");

            migrationBuilder.DropForeignKey(
                name: "FK_sgc_IntencionDescripcion_sgc_Factura_FacturaIdFacturaFinal",
                table: "sgc_IntencionDescripcion");

            migrationBuilder.DropIndex(
                name: "IX_sgc_IntencionDescripcion_FacturaIdFacturaFinal",
                table: "sgc_IntencionDescripcion");

            migrationBuilder.DropIndex(
                name: "IX_sgc_Descripcion_FacturaIdFacturaFinal",
                table: "sgc_Descripcion");

            migrationBuilder.DropColumn(
                name: "FacturaIdFacturaFinal",
                table: "sgc_IntencionDescripcion");

            migrationBuilder.DropColumn(
                name: "FacturaIdFacturaFinal",
                table: "sgc_Descripcion");

            migrationBuilder.RenameColumn(
                name: "IdFacturaFinal",
                table: "sgc_Factura",
                newName: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_sgc_IntencionDescripcion_FacturaIdFactura",
                table: "sgc_IntencionDescripcion",
                column: "FacturaIdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_sgc_Descripcion_FacturaIdFactura",
                table: "sgc_Descripcion",
                column: "FacturaIdFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_sgc_Descripcion_sgc_Factura_FacturaIdFactura",
                table: "sgc_Descripcion",
                column: "FacturaIdFactura",
                principalTable: "sgc_Factura",
                principalColumn: "IdFactura",
                onDelete: ReferentialAction.Cascade);

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
