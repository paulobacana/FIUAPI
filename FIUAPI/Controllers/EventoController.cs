using FIUAPI.DTO;
using FIUAPI.Model;
using FIUAPI.Repository.Interface;
using FIUAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace FIUAPI.Controllers
{
    [ApiController]
    [Route("api/v1/evento")]
    public class EventoController : GenericController<EventoModel>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly EventoService _eventoService;
        public EventoController(IEventoRepository repository, EventoService eventoService) : base(repository)
        {
            _eventoRepository = repository;
            _eventoService = eventoService;

        }

        [HttpGet("calendario")]
        public async Task<IActionResult> GetCalendario([FromQuery] string viewType, [FromQuery] DateTime data)
        {
            try
            {
                var eventos = await _eventoRepository.GetCalendarioAsync(viewType, data);
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("avaliacoes")]
        public async Task<IActionResult> GetAvaliacoes([FromQuery] long? modalidadeId, [FromQuery] DateTime? data, [FromQuery] long? localId)
        {
            try
            {
                var avaliacoes = await _eventoRepository.GetAvaliacoesAsync(modalidadeId, data, localId);
                return Ok(avaliacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("agendar")]
        public async Task<IActionResult> Agendar([FromBody] AgendarEventoDTO dto)
        {
            try
            {
                var result = await _eventoService.AgendarEvento(dto);
                return Created(string.Empty, result);
            }
            catch (Exception ex)
            {
                var mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest($"Erro no banco: {mensagemErro}");
            }
        }

        [HttpPost("{id}/inscrever/{atletaId}")]
        public async Task<IActionResult> InscreverAtleta(long id, long atletaId)
        {
            try
            {
                await _eventoRepository.RegistrarPresencaAsync(atletaId, id);

                return Created(string.Format("Presenca/Inscricao registrada com sucesso"), null);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao registrar presenca: {ex.Message}");
            }
        }

        [HttpGet("{id}/participantes")]
        public async Task<IActionResult> GetParticipantes(long id)
        {
            try
            {
                var participantes = await _eventoRepository.GetParticipantesAsync(id);

                return Ok(participantes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar participantes: {ex.Message}");
            }
        }

        [HttpGet("{id}/detalhes")]
        public async Task<IActionResult> GetDetalhes(long id)
        {
            try
            {
                var detalhes = await _eventoRepository.GetDetalhesEncontroAsync(id);
                return Ok(detalhes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar detalhes do evento: {ex.Message}");
            }
        }

        [HttpGet("filtro/modalidade/{id}")]
        public async Task<IActionResult> GetEventosPorModalidade(long id)
        {
            try
            {
                var eventos = await _eventoRepository.GetPorModalidadeAsync(id);
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar eventos por modalidade: {ex.Message}");
            }
        }
    }
}
