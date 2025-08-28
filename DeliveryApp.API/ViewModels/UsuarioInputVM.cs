using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.API.ViewModels
{
    public class UsuarioInputVM : IEntityInputModel<Usuario, Guid>
    {
        public Guid Id { get; set; }

        [Required] public string Nombre { get; set; }
        [Required] public string CI { get; set; }

        [Required, EmailAddress] public string Correo { get; set; }

        [Required, MinLength(6)] public string Clave { get; set; }

        public string Direccion { get; set; }
        public string Celular { get; set; }
        public Guid[] RolesId { get; set; } = { };

        public Usuario Export()
        {
            var entity = new Usuario();
            Merge(entity);
            return entity;
        }

        public void Import(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Merge(Usuario entity)
        {
            entity.Nombre = Nombre;
            entity.CI = CI;
            entity.Clave = Clave;
            entity.Correo = Correo;
            entity.Direccion = Direccion;
            entity.Celular = Celular;
        }
    }
}
