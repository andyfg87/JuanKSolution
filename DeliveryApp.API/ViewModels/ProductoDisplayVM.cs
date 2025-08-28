using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;

namespace DeliveryApp.API.ViewModels
{
    public class ProductoDisplayVM : IEntityDisplayModel<Producto, Guid>
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string TiendaNombre { get; set; }

        public void Import(Producto entity)
        {
            Id = entity.Id;
            Nombre = entity.Nombre;
            Precio = entity.Precio;
            TiendaNombre = entity.Tienda?.Nombre ?? "Sin tienda";
        }
    }
}
