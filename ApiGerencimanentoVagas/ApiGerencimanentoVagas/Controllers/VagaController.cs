using ApiGerencimanentoVagas.Data;
using ApiGerencimanentoVagas.Models;
using ApiGerencimanentoVagas.Models.Enums;
using ApiGerencimanentoVagas.Services.Vaga;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGerencimanentoVagas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VagaController : ControllerBase
    {
        private readonly IVagaInterface _vagaInterface;

        public VagaController(IVagaInterface vagaInterface) 
        { 
            _vagaInterface = vagaInterface;
        }

        [HttpGet("List")]
        public async Task<ActionResult<ResponseModel<List<VagaModel>>>> Index()
        {
            try
            {
                var vagas = await _vagaInterface.Index();
                return Ok(vagas);

            }
            catch (Exception ex)
            {
                ResponseModel<List<VagaModel>> response = new ResponseModel<List<VagaModel>>();
                response.Status = false;
                response.message = ex.Message;
                return BadRequest(response);
            }

        }

        [HttpPost("Create")]
        public async Task<ActionResult<ResponseModel<List<VagaModel>>>> Create(CreateVagaRequest createVagaRequest)
        {
            try
            {
                var vagas = await _vagaInterface.Create(createVagaRequest);
                return Ok(vagas);

            }
            catch (Exception ex)
            {
                ResponseModel<List<VagaModel>> response = new ResponseModel<List<VagaModel>>();
                response.Status = false;
                response.message = ex.Message;
                return BadRequest(response);
            }

        }

        [HttpPut("Edit")]
        public async Task<ActionResult<ResponseModel<List<VagaModel>>>> Edit(EditVagaRequest EditVagaRequest)
        {
            try
            {
                var vagas = await _vagaInterface.Edit(EditVagaRequest);
                return Ok(vagas);

            }
            catch (Exception ex)
            {
                ResponseModel<List<VagaModel>> response = new ResponseModel<List<VagaModel>>();
                response.Status = false;
                response.message = ex.Message;
                return BadRequest(response);
            }

        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ResponseModel<List<VagaModel>>>> Delete(int idVaga)
        {
            try
            {
                var vagas = await _vagaInterface.Delete(idVaga);

                return Ok(vagas);
            }
            catch (Exception ex) {
                ResponseModel<List<VagaModel>> response = new ResponseModel<List<VagaModel>>();
                response.Status = false;
                response.message = ex.Message;
                return BadRequest(response);
            }

        }
    }
}
