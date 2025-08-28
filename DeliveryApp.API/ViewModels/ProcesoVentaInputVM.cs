using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.API.ViewModels
{
    public class ProcesoVentaInputVM : IEntityInputModel<ProcesoVenta, Guid>
    {
        public Guid Id { get; set; }

        [Required] public Guid UsuarioClienteId { get; set; }
        [Required] public Guid UsuarioMensajeroId { get; set; }

        public Estado Estado { get; set; } = Estado.Abierto;

        public ProcesoVenta Export()
        {
            var entity = new ProcesoVenta();
            Merge(entity);
            return entity;
        }

        public void Import(ProcesoVenta entity)
        {
            throw new NotImplementedException();
        }

        public void Merge(ProcesoVenta entity)
        {
            entity.UsuarioCliente = UsuarioClienteId;
            entity.UsuarioMensajero = UsuarioMensajeroId;
            entity.Estado = Estado;
        }
    }
}
