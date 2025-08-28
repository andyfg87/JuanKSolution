using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;

namespace DeliveryApp.API.ViewModels
{
    public class CarritoItemDisplayVM : IEntityDisplayModel<CarritoItem, Guid>
    {
        public Guid Id { get; set; }
        public Guid CarritoId { get; set; }
        public Guid ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public void Import(CarritoItem entity)
        {
            Id = entity.Id;
            CarritoId = entity.CarritoId;
            ProductoId = entity.ProductoId;
            NombreProducto = entity.Producto?.Nombre ?? "Desconocido";
            Cantidad = entity.Cantidad;
            PrecioUnitario = entity.PrecioUnitario;
        }
    }
}
