using FIUAPI.Data;
using FIUAPI.Model;

namespace FIUAPI.Repository
{
    public class LocalRepository : Repository<LocalModel>
    {
        public LocalRepository(ConnectionContext context) : base(context) { }
    }
}
