using DeliveryApp.API.Controllers.Base;
using DeliveryApp.API.Interfaces;
using DeliveryApp.API.ViewModels;
using JuanK.Persintence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.API.Controllers
{
    [Route("api/venta-productos")]
    public class ProcesoVentaProductosController :
        GenericViewModelController<ProcesoVentaProducto, Guid, ProcesoVentaProductoInputVM, ProcesoVentaProductoDisplayVM>
    {
        public ProcesoVentaProductosController(
            IEntityRepository<ProcesoVentaProducto, Guid> repository,
            ILogger<ProcesoVentaProductosController> logger)
            : base(repository, logger)
        {
        }
    }
}
