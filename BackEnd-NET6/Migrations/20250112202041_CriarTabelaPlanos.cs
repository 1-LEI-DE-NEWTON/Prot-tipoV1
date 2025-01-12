using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_NET6.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaPlanos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanoId",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    PlanoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.PlanoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_PlanoId",
                table: "Vendas",
                column: "PlanoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Planos_PlanoId",
                table: "Vendas",
                column: "PlanoId",
                principalTable: "Planos",
                principalColumn: "PlanoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Planos_PlanoId",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "Planos");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_PlanoId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "PlanoId",
                table: "Vendas");
        }
    }
}
