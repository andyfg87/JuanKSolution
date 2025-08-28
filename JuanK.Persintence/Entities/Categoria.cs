using JuanK.Persintence.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuanK.Persintence.Entities
{
    public class Categoria : IEntity<System.Guid>
    {
        public Categoria() 
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[]? Image { get; set; }
        [ForeignKey(nameof(Tienda))]
        public System.Guid IdTienda { get; set; }
        public Tienda Tienda { get; set; }
    }
}