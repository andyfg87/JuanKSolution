using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.API.ViewModels
{
    public class ProcesoVentaProductoInputVM : IEntityInputModel<ProcesoVentaProducto, Guid>
    {
        [Required] public Guid ProcesoVentaId { get; set; }
        [Required] public Guid ProductoId { get; set; }
        [Required, Range(1, int.MaxValue)] public int Cantidad { get; set; }
        [Required, Range(0.01, double.MaxValue)] public decimal PrecioUnitario { get; set; }
        public Guid Id { get; set; }

        public ProcesoVentaProducto Export()
        {
            var entity = new ProcesoVentaProducto();
            Merge(entity);
            return entity;
        }

        public void Import(ProcesoVentaProducto entity)
        {
            throw new NotImplementedException();
        }

        public void Merge(ProcesoVentaProducto entity)
        {
            entity.ProcesoVentaId = ProcesoVentaId;
            entity.ProductoId = ProductoId;
            entity.Cantidad = Cantidad;
            entity.PrecioUnitario = PrecioUnitario;
        }
    }
}
