using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JuanK.Maui.Models
{
    public class TiendaDisplayVM
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("productosCount")]
        public int ProductosCount { get; set; }

        [JsonPropertyName("categoriasCount")]
        public int CategoriasCount { get; set; }
    }
}
