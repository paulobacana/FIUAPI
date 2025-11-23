using FIUAPI.Model;
using FIUAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FIUAPI.Controllers
{
    [ApiController]
    [Route("api/v1/modalidade")]
    public class ModalidadeController : GenericController<ModalidadeModel>
    {
        public ModalidadeController(IRepository<ModalidadeModel> repository) : base(repository){}
    }
}
