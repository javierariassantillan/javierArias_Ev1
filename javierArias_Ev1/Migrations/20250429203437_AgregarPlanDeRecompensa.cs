using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace javierArias_Ev1.Migrations
{
    /// <inheritdoc />
    public partial class AgregarPlanDeRecompensa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanDeRecompensa_Cliente_ClienteId",
                table: "PlanDeRecompensa");

            migrationBuilder.DropIndex(
                name: "IX_PlanDeRecompensa_ClienteId",
                table: "PlanDeRecompensa");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "PlanDeRecompensa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanDeRecompensa_ClienteId",
                table: "PlanDeRecompensa",
                column: "ClienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDeRecompensa_Cliente_ClienteId",
                table: "PlanDeRecompensa",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanDeRecompensa_Cliente_ClienteId",
                table: "PlanDeRecompensa");

            migrationBuilder.DropIndex(
                name: "IX_PlanDeRecompensa_ClienteId",
                table: "PlanDeRecompensa");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "PlanDeRecompensa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDeRecompensa_ClienteId",
                table: "PlanDeRecompensa",
                column: "ClienteId",
                unique: true,
                filter: "[ClienteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDeRecompensa_Cliente_ClienteId",
                table: "PlanDeRecompensa",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId");
        }
    }
}
