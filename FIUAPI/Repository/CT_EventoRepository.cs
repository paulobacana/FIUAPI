using FIUAPI.Data;
using FIUAPI.Model;

namespace FIUAPI.Repository
{
    public class CT_EventoRepository : Repository<CT_EventoModel>
    {
        public CT_EventoRepository(ConnectionContext context) : base(context) { }
    }
}
