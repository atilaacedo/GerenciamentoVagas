using ApiGerencimanentoVagas.Data;
using ApiGerencimanentoVagas.Models.Enums;
using ApiGerencimanentoVagas.Models;

public class AppDbContextSeed
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!context.Vagas.Any())
        {
            context.Vagas.AddRange(
                new VagaModel
                {
                    Title = "Vaga de Desenvolvedor Backend",
                    Status = StatusVaga.ABERTA
                },
                new VagaModel
                {
                    Title = "Vaga de Desenvolvedor Frontend",
                    Status = StatusVaga.ABERTA
                },
                new VagaModel
                {
                    Title = "Vaga de Analista de Dados",
                    Status = StatusVaga.Finalizada
                },
                new VagaModel
                {
                    Title = "Vaga de Designer UX/UI",
                    Status = StatusVaga.ABERTA
                },
                new VagaModel
                {
                    Title = "Vaga de Gerente de Projetos",
                    Status = StatusVaga.Finalizada
                }
            );

            await context.SaveChangesAsync();
        }
    }
}
