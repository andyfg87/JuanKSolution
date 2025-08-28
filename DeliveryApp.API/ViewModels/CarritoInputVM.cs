using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.API.ViewModels
{
    public class CarritoInputVM : IEntityInputModel<Carrito, Guid>
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UsuarioId { get; set; }

        public List<CarritoItemInputVM> Items { get; set; } = new();

        public Carrito Export()
        {
            var entity = new Carrito
            {
                Id = Id,
            };
            Merge(entity);
            return entity;
        }

        public void Import(Carrito entity)
        {
            throw new NotImplementedException();
        }

        public void Merge(Carrito entity)
        {
            entity.UsuarioId = UsuarioId;
            // Se recomienda manejar los items mediante lógica separada (Agregar/Eliminar)
        }
    }

}
