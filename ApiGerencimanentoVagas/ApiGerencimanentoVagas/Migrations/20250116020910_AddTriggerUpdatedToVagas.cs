using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGerencimanentoVagas.Migrations
{
    /// <inheritdoc />
    public partial class AddTriggerUpdatedToVagas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql("CREATE OR ALTER TRIGGER UpdateVagaUpdatedAt ON Vagas AFTER UPDATE AS BEGIN UPDATE Vagas SET Updated_at = GETDATE() FROM inserted WHERE Vagas.Id = inserted.Id; END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER UpdateVagaUpdatedAt");
        }
    }
}
