using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.API.ViewModels
{
    public class TiendaVM : IEntityInputModel<Tienda, Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        public List<Categoria> Categorias { get; set; } = new List<Categoria>();
        public List<Producto> Productos { get; set; } = new List<Producto>();

        public Tienda Export()
        {
            var entity = new Tienda();

            Merge(entity);

            return entity;
        }

        public void Import(Tienda entity)
        {
            Id = entity.Id;
            Nombre = entity.Nombre;
        }

        public void Merge(Tienda entity)
        {
            entity.Nombre = Nombre;
        }
    }
}
