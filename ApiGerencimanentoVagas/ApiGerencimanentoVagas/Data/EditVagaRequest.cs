using ApiGerencimanentoVagas.Models.Enums;

namespace ApiGerencimanentoVagas.Data
{
    public class EditVagaRequest
    {
        public int IdVaga { get; set; }
        public string Title { get; set; }
        public StatusVaga Status { get; set; }
    }
}
