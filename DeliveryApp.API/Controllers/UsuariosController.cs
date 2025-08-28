using DeliveryApp.API.Controllers.Base;
using DeliveryApp.API.Interfaces;
using DeliveryApp.API.ViewModels;
using JuanK.Persintence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuariosController :
        GenericViewModelController<Usuario, Guid, UsuarioInputVM, UsuarioDisplayVM>
    {
        public UsuariosController(
            IEntityRepository<Usuario, Guid> repository,
            ILogger<UsuariosController> logger)
            : base(repository, logger)
        {
        }
    }
}
