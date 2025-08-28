using JuanK.Persintence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Persintence.Entities
{
    public class Usuario : IEntity<System.Guid>
    {

        public Usuario() 
        {
            Id = Guid.NewGuid();
            Roles = new HashSet<Rol>();
        }
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string CI { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public virtual ICollection<Rol> Roles { get; set; }

    }
}
