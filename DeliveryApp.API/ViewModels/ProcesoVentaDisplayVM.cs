using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;

namespace DeliveryApp.API.ViewModels
{
    public class ProcesoVentaDisplayVM : IEntityDisplayModel<ProcesoVenta, Guid>
    {
        public Guid Id { get; set; }
        public string ClienteNombre { get; set; }
        public string MensajeroNombre { get; set; }
        public Estado Estado { get; set; }
        public int ProductosCount { get; set; }

        public void Import(ProcesoVenta entity)
        {
            Id = entity.Id;
            ClienteNombre = entity.UsuarioCliente.ToString();
            MensajeroNombre = entity.UsuarioMensajero.ToString();
            Estado = entity.Estado;
            ProductosCount = entity.ProductosVendidos?.Count() ?? 0;
        }
    }
}
