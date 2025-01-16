using ApiGerencimanentoVagas.Data;
using ApiGerencimanentoVagas.Models;
using ApiGerencimanentoVagas.Models.Enums;

namespace ApiGerencimanentoVagas.Services.Vaga
{
    public interface IVagaInterface
    {
        Task<ResponseModel<List<VagaModel>>> Index();
        Task<ResponseModel<List<VagaModel>>> Create(CreateVagaRequest createVagaRequest);
        Task<ResponseModel<List<VagaModel>>> Edit(EditVagaRequest EditVagaRequest);
        Task<ResponseModel<List<VagaModel>>> Delete(int idVaga);
    }
}
