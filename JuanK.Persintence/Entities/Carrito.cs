using JuanK.Persintence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Persintence.Entities
{
    public class Carrito : IEntity<System.Guid>
    {
        public Carrito() { Id = System.Guid.NewGuid(); }
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<CarritoItem> Items { get; set; } = new HashSet<CarritoItem>();
    }
}
