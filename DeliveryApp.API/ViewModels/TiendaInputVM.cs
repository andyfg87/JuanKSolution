using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.API.ViewModels
{
    public class TiendaInputVM : IEntityInputModel<Tienda, Guid>
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El nombre de la tienda es obligatorio")]
        [StringLength(120)]
        public string Nombre { get; set; }

        public Tienda Export()
        {
            var entity = new Tienda();
            Merge(entity);
            return entity;
        }

        public void Import(Tienda entity)
        {
            throw new NotImplementedException();
        }

        public void Merge(Tienda entity)
        {
            entity.Nombre = Nombre.Trim();
        }
    }
}
