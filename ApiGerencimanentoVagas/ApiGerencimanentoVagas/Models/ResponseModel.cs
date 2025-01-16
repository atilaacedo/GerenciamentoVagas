namespace ApiGerencimanentoVagas.Models
{
    public class ResponseModel<T>
    {
        public T? Data {get; set; }

        public string message { get; set; } = string.Empty;

        public bool Status { get; set; } = true;

    }
}
