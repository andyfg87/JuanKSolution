using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.API.ViewModels
{
    public class ProductoInputVM : IEntityInputModel<Producto, Guid>
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(120, ErrorMessage = "El nombre no puede superar los 120 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe ser mayor que 0")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El producto debe pertenecer a una tienda")]
        public Guid TiendaId { get; set; }

        public Producto Export()
        {
            var entity = new Producto();
            Merge(entity);
            return entity;
        }

        public void Import(Producto entity)
        {
            throw new NotImplementedException();
        }

        public void Merge(Producto entity)
        {
            entity.Nombre = Nombre.Trim();
            entity.Precio = Precio;
            entity.IdTienda = TiendaId;
        }
    }
}
