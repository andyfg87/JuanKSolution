using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Maui.Services
{
    public static class GlobalExceptionHandler
    {
        public static void HandleException(Exception ex)
        {
            Debug.WriteLine($"Global Exception: {ex.Message}");
            Debug.WriteLine($"Stack Trace: {ex.StackTrace}");

            // Puedes agregar más lógica aquí como enviar a un servicio de logging
        }
    }
}
