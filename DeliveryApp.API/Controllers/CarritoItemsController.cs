using DeliveryApp.API.Controllers.Base;
using DeliveryApp.API.Interfaces;
using DeliveryApp.API.ViewModels;
using JuanK.Persintence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.API.Controllers
{
    [Route("api/carritos/items")]
    public class CarritoItemsController :
        GenericViewModelController<CarritoItem, Guid, CarritoItemInputVM, CarritoItemDisplayVM>
    {
        public CarritoItemsController(
            IEntityRepository<CarritoItem, Guid> repository,
            ILogger<CarritoItemsController> logger)
            : base(repository, logger)
        {
        }
    }
}
