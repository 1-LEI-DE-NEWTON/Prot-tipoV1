using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_NET6.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaVendedores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IccdFinal",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IccdInicial",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Pdv",
                table: "Vendas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "VendedorId",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    VendedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.VendedorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VendedorId",
                table: "Vendas",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Vendedores_VendedorId",
                table: "Vendas",
                column: "VendedorId",
                principalTable: "Vendedores",
                principalColumn: "VendedorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Vendedores_VendedorId",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "Vendedores");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_VendedorId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "IccdFinal",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "IccdInicial",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "Pdv",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "VendedorId",
                table: "Vendas");
        }
    }
}
