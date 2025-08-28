using JuanK.Persintence.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Persintence.Entities
{
    public class Producto : IEntity<System.Guid>
    {
        public Producto() { Id = System.Guid.NewGuid(); }

        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen {  get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        [ForeignKey(nameof(Tienda))]
        public System.Guid IdTienda { get; set; }
        public Tienda Tienda { get; set; }

        public virtual ICollection<ProcesoVentaProducto> Ventas { get; set; }

    }
}
