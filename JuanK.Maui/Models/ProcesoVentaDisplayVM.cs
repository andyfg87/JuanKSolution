using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JuanK.Maui.Models
{
    public class ProcesoVentaDisplayVM
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("clienteNombre")]
        public string ClienteNombre { get; set; }

        [JsonPropertyName("mensajeroNombre")]
        public string MensajeroNombre { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("productosCount")]
        public int ProductosCount { get; set; }

        [JsonPropertyName("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [JsonPropertyName("total")]
        public decimal Total { get; set; }
    }
}
