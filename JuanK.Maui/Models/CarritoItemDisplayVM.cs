using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JuanK.Maui.Models
{
    public class CarritoItemDisplayVM
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("carritoId")]
        public Guid CarritoId { get; set; }

        [JsonPropertyName("productoId")]
        public Guid ProductoId { get; set; }

        [JsonPropertyName("nombreProducto")]
        public string NombreProducto { get; set; }

        [JsonPropertyName("cantidad")]
        public int Cantidad { get; set; }

        [JsonPropertyName("precioUnitario")]
        public decimal PrecioUnitario { get; set; }

        [JsonPropertyName("subtotal")]
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
