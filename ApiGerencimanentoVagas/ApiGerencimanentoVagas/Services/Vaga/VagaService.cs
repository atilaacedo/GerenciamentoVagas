using ApiGerencimanentoVagas.Data;
using ApiGerencimanentoVagas.Models;
using ApiGerencimanentoVagas.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ApiGerencimanentoVagas.Services.Vaga
{
    public class VagaService : IVagaInterface
    {

        private readonly AppDbContext _context;
        public VagaService(AppDbContext context) { 
            _context = context;
        }

        public async Task<ResponseModel<List<VagaModel>>> Create(CreateVagaRequest createVagaRequest)
        {
            ResponseModel<List<VagaModel>> response = new ResponseModel<List<VagaModel>>();


            var vaga = new VagaModel()
            {
                Title = createVagaRequest.Title,
                Status = createVagaRequest.Status
            };

            _context.Add(vaga);
            await _context.SaveChangesAsync();

            response.Data = await _context.Vagas.ToListAsync();
            response.message = "Vaga criada com sucesso!";
            return response;


        }

        public async Task<ResponseModel<List<VagaModel>>> Delete(int idVaga)
        {
            ResponseModel<List<VagaModel>> response = new ResponseModel<List<VagaModel>>();


            var vaga = await _context.Vagas.FirstOrDefaultAsync(vagaDb => vagaDb.Id == idVaga) ?? throw new Exception("Vaga não encontrada");
            _context.Remove(vaga);
            await _context.SaveChangesAsync();

            response.Data = await _context.Vagas.ToListAsync();
            response.message = "Vaga removida com sucesso!";

            return response;


        }

        public async Task<ResponseModel<List<VagaModel>>> Edit(EditVagaRequest vagaRequest)
        {
            ResponseModel<List<VagaModel>> response = new ResponseModel<List<VagaModel>>();


            var vaga = await _context.Vagas.FirstOrDefaultAsync(vagaDb => vagaDb.Id == vagaRequest.IdVaga) ?? throw new Exception("Vaga não encontrada");

            vaga.Title = vagaRequest.Title;
            vaga.Status = vagaRequest.Status;

            _context.Update(vaga);
            await _context.SaveChangesAsync();

            response.Data = await _context.Vagas.ToListAsync();
            response.message = "Vaga editada com sucesso!";

            return response;


        }

        public async Task<ResponseModel<List<VagaModel>>> Index()
        {
            ResponseModel<List<VagaModel>> response = new ResponseModel<List<VagaModel>>();


            var vagas = await _context.Vagas.ToListAsync();

            response.Data = vagas;
            response.message = "Vagas resgatadas com sucesso!";
            return response;

        }
    }
}
