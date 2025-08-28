﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JuanK.Maui.Models
{
    public class AuthResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("usuario")]
        public UsuarioDisplayVM Usuario { get; set; }

        [JsonPropertyName("expiracion")]
        public DateTime Expiracion { get; set; }
    }
}
