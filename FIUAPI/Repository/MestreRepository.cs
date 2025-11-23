using FIUAPI.Data;
using FIUAPI.Model;

namespace FIUAPI.Repository
{
    public class MestreRepository : Repository<MestreModel>
    {
        public MestreRepository(ConnectionContext context) : base(context) { }
    }
}
