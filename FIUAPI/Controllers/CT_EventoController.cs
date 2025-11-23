using FIUAPI.Model;
using FIUAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FIUAPI.Controllers
{
    [ApiController]
    [Route("api/v1/ct_evento")]
    public class CT_EventoController : GenericController<CT_EventoModel>
    {
        public CT_EventoController(IRepository<CT_EventoModel> repository) : base(repository) { }
    }
}
