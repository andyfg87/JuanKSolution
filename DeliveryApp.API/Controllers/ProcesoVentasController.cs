using DeliveryApp.API.Controllers.Base;
using DeliveryApp.API.Interfaces;
using DeliveryApp.API.ViewModels;
using JuanK.Persintence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.API.Controllers
{
    [Route("api/ventas")]
    public class ProcesoVentasController :
        GenericViewModelController<ProcesoVenta, Guid, ProcesoVentaInputVM, ProcesoVentaDisplayVM>
    {
        public ProcesoVentasController(
            IEntityRepository<ProcesoVenta, Guid> repository,
            ILogger<ProcesoVentasController> logger)
            : base(repository, logger)
        {
        }
    }
}
