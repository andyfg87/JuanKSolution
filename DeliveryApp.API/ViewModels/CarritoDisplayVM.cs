using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;

namespace DeliveryApp.API.ViewModels
{
    public class CarritoDisplayVM : IEntityDisplayModel<Carrito, Guid>
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public List<CarritoItemDisplayVM> Items { get; set; } = new();

        public void Import(Carrito entity)
        {
            Id = entity.Id;
            UsuarioId = entity.UsuarioId;
            Items = entity.Items?.Select(p => new CarritoItemDisplayVM
            {
                ProductoId = p.Producto.Id,
                NombreProducto = p.Producto.Nombre,
                Cantidad = p.Cantidad,
                PrecioUnitario = p.Producto.Precio
            }).ToList() ?? new List<CarritoItemDisplayVM>();
        }
    }
}
