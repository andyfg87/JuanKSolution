using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.API.ViewModels
{
    public class ProductoVM :
        IEntityInputModel<Producto, Guid>,
        IEntityDisplayModel<Producto, Guid>
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Precio { get; set; }

        [Required]
        public Guid TiendaId { get; set; }

        // Implementación de IEntityInputModel
        public Producto Export()
        {
            return new Producto
            {
                Id = this.Id,
                Nombre = this.Nombre,
                Precio = this.Precio,
                IdTienda = this.TiendaId
            };
        }

        public void Merge(Producto entity)
        {
            entity.Nombre = this.Nombre;
            entity.Precio = this.Precio;
            entity.IdTienda = this.TiendaId;
        }

        // Implementación de IEntityDisplayModel
        public void Import(Producto entity)
        {
            this.Id = entity.Id;
            this.Nombre = entity.Nombre;
            this.Precio = entity.Precio;
            this.TiendaId = entity.IdTienda;
        }
    }
}
