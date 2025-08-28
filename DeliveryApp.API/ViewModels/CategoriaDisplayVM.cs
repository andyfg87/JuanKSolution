using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;

namespace DeliveryApp.API.ViewModels
{
    public class CategoriaDisplayVM : IEntityDisplayModel<Categoria, Guid>
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TiendaNombre { get; set; }

        public void Import(Categoria entity)
        {
            Id = entity.Id;
            Nombre = entity.Nombre;
            Descripcion = entity.Descripcion;
            TiendaNombre = entity.Tienda?.Nombre ?? "Sin tienda";
        }
    }
}
