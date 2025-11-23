using FIUAPI.DTO;
using FIUAPI.Model;

namespace FIUAPI.Repository.Interface
{
    public interface IAtletaRepository : IRepository<AtletaModel>
    {
        Task<IEnumerable<HistoricoAtletaDTO>> GetHistoricoAsync(long atletaId);
    }
}
