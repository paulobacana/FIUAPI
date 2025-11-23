using FIUAPI.Data;
using FIUAPI.Model;

namespace FIUAPI.Repository
{
    public class FaixaRepository : Repository<FaixaModel>
    {
        public FaixaRepository(ConnectionContext context) : base(context) { }
    }
}
