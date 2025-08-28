using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JuanK.Maui.Models
{
    public class UsuarioInputVM
    {
        [JsonPropertyName("nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [JsonPropertyName("ci")]
        [Required(ErrorMessage = "El CI es obligatorio")]
        public string CI { get; set; }

        [JsonPropertyName("correo")]
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Correo { get; set; }

        [JsonPropertyName("clave")]
        [Required(ErrorMessage = "La clave es obligatoria")]
        [MinLength(6, ErrorMessage = "Mínimo 6 caracteres")]
        public string Clave { get; set; }

        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }

        [JsonPropertyName("celular")]
        public string Celular { get; set; }
    }
}
