using FIUAPI.Data;
using FIUAPI.Model;

namespace FIUAPI.Repository
{
    public class AvaliacaoRepository : Repository<AvaliacaoModel>
    {
        public AvaliacaoRepository(ConnectionContext context) : base(context){ }
    }
}
