using DeliveryApp.API.Controllers.Base;
using DeliveryApp.API.Interfaces;
using DeliveryApp.API.ViewModels;
using JuanK.Persintence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.API.Controllers
{
    [Route("api/tiendas")]
    public class TiendasController :
        GenericViewModelController<Tienda, Guid, TiendaInputVM, TiendaDisplayVM>
    {
        public TiendasController(
            IEntityRepository<Tienda, Guid> repository,
            ILogger<TiendasController> logger)
            : base(repository, logger)
        {
        }
    }
}
