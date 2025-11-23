using FIUAPI.DTO;
using FIUAPI.Model;
using FIUAPI.Repository.Interface;
using FIUAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace FIUAPI.Controllers
{
    [ApiController]
    [Route("api/v1/ct")]
    public class CTController : GenericController<CTModel>
    {
        private readonly CTService _ctService;
        public CTController(IRepository<CTModel> repository, CTService service) : base(repository) { _ctService = service; }


        [HttpPost("cadastro-completo")]
        public async Task<IActionResult> Post([FromBody] CadastroCTDTO dto)
        {
            try
            {
                var result = await _ctService.CadastrarCTCompleto(dto);
                return Created(string.Empty, result);
            }
            catch (Exception ex)
            {
                var mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest($"Erro no banco: {mensagemErro}");
            }
        }
    }
}
