using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace javierArias_Ev1.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAriasJ_AddNombre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AriasJ",
                table: "Cliente",
                newName: "Nombre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Cliente",
                newName: "AriasJ");
        }
    }
}
