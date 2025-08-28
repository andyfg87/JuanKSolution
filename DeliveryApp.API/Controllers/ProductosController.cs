using DeliveryApp.API.Controllers.Base;
using DeliveryApp.API.Interfaces;
using DeliveryApp.API.ViewModels;
using JuanK.Persintence.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.API.Controllers
{
    [Route("api/productos")]
    public class ProductosController :
        GenericViewModelController<Producto, Guid, ProductoInputVM, ProductoDisplayVM>
    {
        public ProductosController(
            IEntityRepository<Producto, Guid> repository,
            ILogger<ProductosController> logger)
            : base(repository, logger)
        {
        }
    }
}
