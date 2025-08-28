using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JuanK.Maui.Models
{
    public class LoginInputVM
    {
        [JsonPropertyName("correo")]
        public string Correo { get; set; }

        [JsonPropertyName("clave")]
        public string Clave { get; set; }
    }
}
