using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;

namespace DeliveryApp.API.ViewModels
{
    public class ProcesoVentaProductoDisplayVM : IEntityDisplayModel<ProcesoVentaProducto, Guid>
    {
        public Guid ProcesoVentaId { get; set; }
        public Guid ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public Guid Id { get; set; }

        public void Import(ProcesoVentaProducto entity)
        {
            ProcesoVentaId = entity.ProcesoVentaId;
            ProductoId = entity.ProductoId;
            ProductoNombre = entity.Producto?.Nombre ?? "Desconocido";
            Cantidad = entity.Cantidad;
            PrecioUnitario = entity.PrecioUnitario;
        }
    }
}
