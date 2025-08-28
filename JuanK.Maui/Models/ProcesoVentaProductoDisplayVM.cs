using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JuanK.Maui.Models
{
    public class ProcesoVentaProductoDisplayVM
    {
        [JsonPropertyName("procesoVentaId")]
        public Guid ProcesoVentaId { get; set; }

        [JsonPropertyName("productoId")]
        public Guid ProductoId { get; set; }

        [JsonPropertyName("productoNombre")]
        public string ProductoNombre { get; set; }

        [JsonPropertyName("cantidad")]
        public int Cantidad { get; set; }

        [JsonPropertyName("precioUnitario")]
        public decimal PrecioUnitario { get; set; }

        [JsonPropertyName("subtotal")]
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
