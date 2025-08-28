using JuanK.Persintence.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Persintence.Entities
{
    public class ProcesoVentaProducto: IEntity<Guid>
    {
        public ProcesoVentaProducto() { Id =  Guid.NewGuid(); }
        public Guid ProcesoVentaId { get; set; }  // FK a ProcesoVenta
        public Guid ProductoId { get; set; }      // FK a Producto
        public int Cantidad { get; set; }         // Ej: 3 unidades del producto
        public decimal PrecioUnitario { get; set; } // Precio en el momento de la venta (por si cambia después)

        // Propiedades de navegación
        public virtual ProcesoVenta ProcesoVenta { get; set; }
        public virtual Producto Producto { get; set; }
        [Key]
        public Guid Id { get; set; }
    }
}
