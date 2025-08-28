using JuanK.Persintence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Persintence.Entities
{
    public class Rol : IEntity<System.Guid>
    {
        public Rol() { 
            Id = System.Guid.NewGuid(); 
            Usuarios = new HashSet<Usuario>();
        }
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
