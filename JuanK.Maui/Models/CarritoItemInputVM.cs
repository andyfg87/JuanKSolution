using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JuanK.Maui.Models
{
    public class CarritoItemInputVM
    {
        [JsonPropertyName("productoId")]
        [Required(ErrorMessage = "El producto es obligatorio")]
        public Guid ProductoId { get; set; }

        [JsonPropertyName("cantidad")]
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1")]
        public int Cantidad { get; set; }

        [JsonPropertyName("precioUnitario")]
        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal PrecioUnitario { get; set; }
    }
}
