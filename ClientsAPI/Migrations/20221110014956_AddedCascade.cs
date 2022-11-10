using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_CLIENTE_ENDERECOS",
                table: "CLIENTE_ENDERECOS");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTE_CLIENTE_ENDERECOS",
                table: "CLIENTE_ENDERECOS",
                column: "ID_CLIENTE",
                principalTable: "CLIENTES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_CLIENTE_ENDERECOS",
                table: "CLIENTE_ENDERECOS");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTE_CLIENTE_ENDERECOS",
                table: "CLIENTE_ENDERECOS",
                column: "ID_CLIENTE",
                principalTable: "CLIENTES",
                principalColumn: "ID");
        }
    }
}
