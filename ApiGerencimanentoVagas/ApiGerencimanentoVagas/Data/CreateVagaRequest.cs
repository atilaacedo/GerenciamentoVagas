using ApiGerencimanentoVagas.Models.Enums;

namespace ApiGerencimanentoVagas.Data
{
    public class CreateVagaRequest
    {
        public string Title { get; set; }
        public StatusVaga Status { get; set; }
    }
}
