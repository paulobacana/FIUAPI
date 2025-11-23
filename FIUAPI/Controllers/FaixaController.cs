using FIUAPI.Model;
using FIUAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FIUAPI.Controllers
{
    [ApiController]
    [Route("api/v1/faixa")]
    public class FaixaController : GenericController<FaixaModel>
    {
        public FaixaController(IRepository<FaixaModel> repository) : base(repository) { }
    }
}
