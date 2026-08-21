using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmbienteEscolarCurso.Migrations
{
    /// <inheritdoc />
    public partial class detalhe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorModelTurmaModel_Professres_ProfessoresId",
                table: "ProfessorModelTurmaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Professres_Materias_MateriaId",
                table: "Professres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professres",
                table: "Professres");

            migrationBuilder.RenameTable(
                name: "Professres",
                newName: "Professores");

            migrationBuilder.RenameIndex(
                name: "IX_Professres_MateriaId",
                table: "Professores",
                newName: "IX_Professores_MateriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professores",
                table: "Professores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Materias_MateriaId",
                table: "Professores",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorModelTurmaModel_Professores_ProfessoresId",
                table: "ProfessorModelTurmaModel",
                column: "ProfessoresId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Materias_MateriaId",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorModelTurmaModel_Professores_ProfessoresId",
                table: "ProfessorModelTurmaModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professores",
                table: "Professores");

            migrationBuilder.RenameTable(
                name: "Professores",
                newName: "Professres");

            migrationBuilder.RenameIndex(
                name: "IX_Professores_MateriaId",
                table: "Professres",
                newName: "IX_Professres_MateriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professres",
                table: "Professres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorModelTurmaModel_Professres_ProfessoresId",
                table: "ProfessorModelTurmaModel",
                column: "ProfessoresId",
                principalTable: "Professres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professres_Materias_MateriaId",
                table: "Professres",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
