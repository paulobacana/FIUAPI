using FIUAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FIUAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : class
    {
        protected readonly IRepository<T> _repository;

        public GenericController(IRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            var items = await _repository.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(long id)
        {
            var item = await _repository.GetById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<T>> Post([FromBody] T entity)
        {
            var createdEntity = await _repository.Add(entity);
            return Ok(createdEntity);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] T entity, long id)
        {
            var entityData = await _repository.GetById(id);
            if (entityData == null) return NotFound();
            
            foreach (var prop in typeof(T).GetProperties())
            {
                if(prop.Name.Equals("Id", StringComparison.OrdinalIgnoreCase)) continue;
                var newValue = prop.GetValue(entity);
                prop.SetValue(entityData, newValue);
            }

            await _repository.Update(entityData);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
