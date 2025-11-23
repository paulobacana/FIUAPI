using FIUAPI.DTO;
using FIUAPI.Model;

namespace FIUAPI.Repository.Interface
{
    public interface IEventoRepository : IRepository<EventoModel>
    {
        Task<IEnumerable<EventoCalendarioDTO>> GetCalendarioAsync(string viewType, DateTime data);
        Task<IEnumerable<AvaliacaoEventoDTO>> GetAvaliacoesAsync(long? modalidadeId, DateTime? data, long? localId);
        Task RegistrarPresencaAsync(long atletaId, long eventoId);
        Task<IEnumerable<ParticipanteEventoDTO>> GetParticipantesAsync(long eventoId);
        Task<IEnumerable<DetalhesEncontroDTO>> GetDetalhesEncontroAsync(long eventoId);
        Task<IEnumerable<EncontroModalidadeDTO>> GetPorModalidadeAsync(long modaliadeId);
    }
}
