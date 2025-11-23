using FIUAPI.Data;
using FIUAPI.Model;

namespace FIUAPI.Repository
{
    public class CTRepository : Repository<CTModel> 
    {
        public CTRepository(ConnectionContext context) : base(context) { }
    }
}
