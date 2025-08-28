using DeliveryApp.API.Interfaces;
using JuanK.Persintence.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class GenericViewModelController<
        TEntity,
        TKey,
        TInputViewModel,
        TDisplayViewModel> : ControllerBase
        where TEntity : class, IEntity<TKey>
        where TInputViewModel : IEntityInputModel<TEntity, TKey>, new()
        where TDisplayViewModel : IEntityDisplayModel<TEntity, TKey>, new()
    {
        protected readonly IEntityRepository<TEntity, TKey> _repository;
        protected readonly ILogger<GenericViewModelController<TEntity, TKey, TInputViewModel, TDisplayViewModel>> _logger;

        public GenericViewModelController(
            IEntityRepository<TEntity, TKey> repository,
            ILogger<GenericViewModelController<TEntity, TKey, TInputViewModel, TDisplayViewModel>> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/{entity}
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TDisplayViewModel>>> GetAll(
            [FromQuery] string includeProperties = "",
            [FromQuery] string filter = "",
            [FromQuery] string orderBy = "")
        {
            try
            {
                IQueryable<TEntity> query = await _repository.GetAll();

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProperty in includeProperties.Split(','))
                    {
                        query = query.Include(includeProperty.Trim());
                    }
                }

                var entities = await query.ToListAsync();
                var viewModels = entities.Select(e =>
                {
                    var vm = new TDisplayViewModel();
                    vm.Import(e);
                    return vm;
                });

                return Ok(viewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener entidades");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // GET: api/{entity}/{id}
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TDisplayViewModel>> GetById(
            TKey id,
            [FromQuery] string includeProperties = "")
        {
            try
            {
                IQueryable<TEntity> query = await _repository.GetAll();
                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProperty in includeProperties.Split(','))
                    {
                        query = query.Include(includeProperty.Trim());
                    }
                }

                var entity = await query.FirstOrDefaultAsync(e => e.Id.Equals(id));

                if (entity == null)
                {
                    return NotFound();
                }

                var viewModel = new TDisplayViewModel();
                viewModel.Import(entity);
                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener entidad con ID {id}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // POST: api/{entity}
        [HttpPost]
        public virtual async Task<ActionResult<TDisplayViewModel>> Create([FromBody] TInputViewModel inputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var entity = inputModel.Export();

                await _repository.AddAsync(entity);
                await _repository.SaveChangesAsync();

                var displayVm = new TDisplayViewModel();
                displayVm.Import(entity);

                return CreatedAtAction(nameof(GetById), new { id = entity.Id }, displayVm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear entidad");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // PUT: api/{entity}/{id}
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(TKey id, [FromBody] TInputViewModel inputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingEntity = await _repository.GetByIdAsync(id);
                if (existingEntity == null)
                {
                    return NotFound();
                }

                inputModel.Merge(existingEntity);

                await _repository.UpdateAsync(existingEntity);
                await _repository.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar entidad con ID {id}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // DELETE: api/{entity}/{id}
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(TKey id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    return NotFound();
                }

                await _repository.DeleteAsync(id);
                await _repository.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar entidad con ID {id}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
