using FIUAPI.Data;
using FIUAPI.Model;

namespace FIUAPI.Repository
{
    public class ParticipacaoEventoRepository : Repository<ParticipacaoEventoModel>
    {
        public ParticipacaoEventoRepository(ConnectionContext context) : base(context) { }
    }
}
