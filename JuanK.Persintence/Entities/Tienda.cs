using JuanK.Persintence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Persintence.Entities
{
    public class Tienda : IEntity<System.Guid>
    {
        public Tienda() { Id = System.Guid.NewGuid(); }
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Categoria> Categorias { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
