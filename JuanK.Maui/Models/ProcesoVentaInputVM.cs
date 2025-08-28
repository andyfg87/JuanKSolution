using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JuanK.Maui.Models
{
    public class ProcesoVentaInputVM
    {
        [JsonPropertyName("usuarioClienteId")]
        [Required(ErrorMessage = "El cliente es obligatorio")]
        public Guid UsuarioClienteId { get; set; }

        [JsonPropertyName("usuarioMensajeroId")]
        public Guid? UsuarioMensajeroId { get; set; }

        [JsonPropertyName("productos")]
        [Required(ErrorMessage = "Debe agregar al menos un producto")]
        public List<CarritoItemInputVM> Productos { get; set; } = new List<CarritoItemInputVM>();

        [JsonPropertyName("direccionEntrega")]
        public string DireccionEntrega { get; set; }

        [JsonPropertyName("notas")]
        public string Notas { get; set; }
    }
}
