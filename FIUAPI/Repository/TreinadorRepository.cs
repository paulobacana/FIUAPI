using FIUAPI.Data;
using FIUAPI.Model;

namespace FIUAPI.Repository
{
    public class TreinadorRepository : Repository<TreinadorModel>
    {
        public TreinadorRepository(ConnectionContext context) : base(context) { }
    }
}
