using FIUAPI.Data;
using FIUAPI.Model;

namespace FIUAPI.Repository
{
    public class RelatorioRepository : Repository<RelatorioModel>
    {
        public RelatorioRepository(ConnectionContext context) : base(context) { }
    }
}
