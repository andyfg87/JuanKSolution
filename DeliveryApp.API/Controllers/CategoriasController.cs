using DeliveryApp.API.Controllers.Base;
using DeliveryApp.API.Interfaces;
using DeliveryApp.API.ViewModels;
using JuanK.Persintence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.API.Controllers
{
    [Route("api/categorias")]
    public class CategoriasController :
        GenericViewModelController<Categoria, Guid, CategoriaInputVM, CategoriaDisplayVM>
    {
        public CategoriasController(
            IEntityRepository<Categoria, Guid> repository,
            ILogger<CategoriasController> logger)
            : base(repository, logger)
        {
        }
    }
}
