using FIUAPI.Data;
using FIUAPI.Model;

namespace FIUAPI.Repository
{
    public class EquipeRepository : Repository<EquipeModel>
    {
        public EquipeRepository(ConnectionContext context) : base(context) { }
    }
}
