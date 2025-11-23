using FIUAPI.Model;
using FIUAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FIUAPI.Controllers
{
    [ApiController]
    [Route("api/v1/avaliacao")]
    public class AvaliacaoController : GenericController<AvaliacaoModel>
    {
        public AvaliacaoController(IRepository<AvaliacaoModel> repository) : base(repository) { }
    }
}
