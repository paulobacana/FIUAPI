using FIUAPI.Model;
using FIUAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FIUAPI.Controllers
{
    [ApiController]
    [Route("api/v1/treinador")]
    public class TreinadorController : GenericController<TreinadorModel>
    {
        public TreinadorController(IRepository<TreinadorModel> repository) : base(repository)
        {
        }
    }
}
