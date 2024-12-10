using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_NET6.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusVendaToVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Vendas");
        }
    }
}
