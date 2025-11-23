using FIUAPI.Data;
using FIUAPI.Model;

namespace FIUAPI.Repository
{
    public class ModalidadeRepository : Repository<ModalidadeModel>
    {
        public ModalidadeRepository(ConnectionContext context) : base(context) { }
    }
}
