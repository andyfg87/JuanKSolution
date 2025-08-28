using DeliveryApp.API.Controllers.Base;
using DeliveryApp.API.Interfaces;
using DeliveryApp.API.ViewModels;
using JuanK.Persintence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.API.Controllers
{
    [Route("api/carritos")]
    public class CarritosController :
        GenericViewModelController<Carrito, Guid, CarritoInputVM, CarritoDisplayVM>
    {
        public CarritosController(
            IEntityRepository<Carrito, Guid> repository,
            ILogger<CarritosController> logger)
            : base(repository, logger)
        {
        }
    }
}
