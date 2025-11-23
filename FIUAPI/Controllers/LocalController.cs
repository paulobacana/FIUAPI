using FIUAPI.Model;
using FIUAPI.Repository.Interface;

namespace FIUAPI.Controllers
{
    public class LocalController : GenericController<LocalModel>
    {
        public LocalController(IRepository<LocalModel> repository) : base(repository) { }
    }
}
