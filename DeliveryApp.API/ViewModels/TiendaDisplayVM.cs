using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;

namespace DeliveryApp.API.ViewModels
{
    public class TiendaDisplayVM : IEntityDisplayModel<Tienda, Guid>
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int ProductosCount { get; set; }
        public int CategoriasCount { get; set; }

        public void Import(Tienda entity)
        {
            Id = entity.Id;
            Nombre = entity.Nombre;
            ProductosCount = entity.Productos?.Count() ?? 0;
            CategoriasCount = entity.Categorias?.Count() ?? 0;
        }
    }
}
