using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmbienteEscolarCurso.Migrations
{
    /// <inheritdoc />
    public partial class addCampoModalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Modalidade",
                table: "Turmas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modalidade",
                table: "Turmas");
        }
    }
}
