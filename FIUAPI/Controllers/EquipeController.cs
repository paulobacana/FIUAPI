using FIUAPI.Model;
using FIUAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FIUAPI.Controllers
{
    [ApiController]
    [Route("api/v1/equipe")]
    public class EquipeController : GenericController<EquipeModel>
    {
        public EquipeController(IRepository<EquipeModel> repository) : base(repository)
        {
        }
    }
}
