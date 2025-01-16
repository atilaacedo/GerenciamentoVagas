using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGerencimanentoVagas.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckConstraintStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Vagas ADD CONSTRAINT CK_Vagas_Status CHECK (Status IN ('ABERTA', 'FINALIZADA'))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql("ALTER TABLE Vagas DROP CONSTRAINT CK_Vagas_Status");
        }
    }
}
