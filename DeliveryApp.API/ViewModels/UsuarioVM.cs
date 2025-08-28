using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.API.ViewModels
{
    public class UsuarioVM : IEntityInputModel<Usuario, Guid>
    {
        public Guid Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required] 
        public string CI { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Introduce un correro válido ")]
        public string Correro {  get; set; }

        [Required]
        public string Clave { get; set; }

        public string ConfirmarClave { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public Guid [] RolesId { get; set; } = { };
        


        public Usuario Export()
        {
            var entity = new Usuario();

            Merge(entity);

            return entity;
        }

        public void Import(Usuario entity)
        {
            Id = entity.Id;
            Nombre = entity.Nombre;
            Correro = entity.Correo; 
            Clave = entity.Clave;
            Direccion = entity.Direccion;
            Celular = entity.Celular;

        }

        public void Merge(Usuario entity)
        {
            entity.Celular = Celular;
            entity.Direccion = Direccion;
            entity.Correo = Correro;
            entity.Clave = Clave;
            entity.CI = CI;
        }
    }
}
