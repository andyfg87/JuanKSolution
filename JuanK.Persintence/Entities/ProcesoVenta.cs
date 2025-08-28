using JuanK.Persintence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Persintence.Entities
{
    public class ProcesoVenta : IEntity<System.Guid>
    {
        public ProcesoVenta() 
        { 
            Id = System.Guid.NewGuid(); 
            Estado = Estado.Abierto;
        }
        public Guid Id { get; set; }
        public System.Guid UsuarioCliente { get; set; }
        public System.Guid UsuarioMensajero { get; set; }
        public Estado Estado { get; set; }
        public virtual ICollection<ProcesoVentaProducto> ProductosVendidos { get; set; } // Reemplaza ICollection<Producto>

    }
}
