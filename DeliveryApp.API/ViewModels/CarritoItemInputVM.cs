using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.API.ViewModels
{
    public class CarritoItemInputVM : IEntityInputModel<CarritoItem, Guid>
    {
        [Required] public Guid Id { get; set; }
        [Required] public Guid CarritoId { get; set; }
        [Required] public Guid ProductoId { get; set; }
        [Required, Range(1, int.MaxValue)] public int Cantidad { get; set; }
        [Required, Range(0.01, double.MaxValue)] public decimal PrecioUnitario { get; set; }

        public CarritoItem Export()
        {
            var entity = new CarritoItem();
            Merge(entity);
            return entity;
        }

        public void Import(CarritoItem entity)
        {
            throw new NotImplementedException();
        }

        public void Merge(CarritoItem entity)
        {
            entity.CarritoId = CarritoId;
            entity.ProductoId = ProductoId;
            entity.Cantidad = Cantidad;
            entity.PrecioUnitario = PrecioUnitario;
        }
    }
}
