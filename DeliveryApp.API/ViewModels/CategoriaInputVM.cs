using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.API.ViewModels
{
    public class CategoriaInputVM : IEntityInputModel<Categoria, Guid>
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required]
        public Guid TiendaId { get; set; }

        public Categoria Export()
        {
            var entity = new Categoria();
            Merge(entity);
            return entity;
        }

        public void Import(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public void Merge(Categoria entity)
        {
            entity.Nombre = Nombre.Trim();
            entity.Descripcion = Descripcion?.Trim();
            entity.IdTienda = TiendaId;
        }
    }
}
