using FIUAPI.Data;
using FIUAPI.Model;

namespace FIUAPI.Repository
{
    public class EnderecoRepository : Repository<EnderecoModel>
    {
        public EnderecoRepository(ConnectionContext context) : base(context) { }
    }
}
