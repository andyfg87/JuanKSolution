using JuanK.Persintence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Persintence.Entities
{
    public class CarritoItem: IEntity<Guid>
    {
        public CarritoItem() { Id = Guid.NewGuid(); }
        public Guid Id { get; set; }
        public Guid CarritoId { get; set; }
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public virtual Carrito Carrito { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
