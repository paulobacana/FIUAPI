using FIUAPI.DTO;
using FIUAPI.Model;
using FIUAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FIUAPI.Controllers
{
    [ApiController]
    [Route("api/v1/atleta")]
    public class AtletaController : GenericController<AtletaModel>
    {
        private readonly IAtletaRepository _atletaRepository;

        public AtletaController(IAtletaRepository repository) : base(repository)
        {
            _atletaRepository = repository;
        }

        [HttpGet("{id}/historico")]
        public async Task<IActionResult> GetHistorico(long id)
        {
            var historico = await _atletaRepository.GetHistoricoAsync(id);

            if (historico == null || !historico.Any()) return Ok(new List<HistoricoAtletaDTO>());

            return Ok(historico);
        }

    }
}
