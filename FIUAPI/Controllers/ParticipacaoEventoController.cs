using FIUAPI.Model;
using FIUAPI.Repository.Interface;

namespace FIUAPI.Controllers
{
    public class ParticipacaoEventoController : GenericController<ParticipacaoEventoModel>
    {
        public ParticipacaoEventoController(IRepository<ParticipacaoEventoModel> repository) : base(repository) { }
    }
}
