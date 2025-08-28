using JuanK.Persintence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Persintence.Entities
{
    public class UsuarioRol
    {
        public Guid UsuarioId { get; set; }
        public Guid RolId { get; set; }

        // Propiedades de navegación
        public virtual Usuario Usuario { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
