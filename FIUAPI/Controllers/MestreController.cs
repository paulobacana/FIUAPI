using FIUAPI.Model;
using FIUAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FIUAPI.Controllers
{
    [ApiController]
    [Route("api/v1/mestre")]
    public class MestreController : GenericController<MestreModel>
    {
        public MestreController(IRepository<MestreModel> repository) : base(repository) { }

    }
}
