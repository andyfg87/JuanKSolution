using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.API.ViewModels
{
    public class CategoriaVM : IEntityInputModel<Categoria, Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[]? Image { get; set; }
        public System.Guid IdTienda { get; set; }
        public string NombreTienda {  get; set; }



        public Categoria Export()
        {
           var entity = new Categoria();

            Merge(entity);

            return entity;
        }

        public void Import(Categoria entity)
        {
            Id = entity.Id;
            Nombre = entity.Nombre;
            Descripcion = entity.Descripcion;
            IdTienda = entity.IdTienda;
            NombreTienda = entity.Tienda?.Nombre;
        }

        public void Merge(Categoria entity)
        {
            entity.Nombre = Nombre;
            entity.Descripcion = Descripcion;
            entity.IdTienda = IdTienda;
        }
    }
}
