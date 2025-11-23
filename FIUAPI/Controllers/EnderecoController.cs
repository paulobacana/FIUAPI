using FIUAPI.Model;
using FIUAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FIUAPI.Controllers
{
    [ApiController]
    [Route("api/v1/endereco")]
    public class EnderecoController : GenericController<EnderecoModel>
    {
        public EnderecoController(IRepository<EnderecoModel> repository) : base(repository) { }
    }
}
