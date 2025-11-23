using FIUAPI.Model;
using FIUAPI.Repository.Interface;

namespace FIUAPI.Controllers
{
    public class RelatorioController : GenericController<RelatorioModel>
    {
        public RelatorioController(IRepository<RelatorioModel> repository) : base(repository) { }
    }
}
