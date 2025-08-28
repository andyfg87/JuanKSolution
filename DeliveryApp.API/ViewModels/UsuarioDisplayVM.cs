using JuanK.Persintence.Entities;
using JuanK.Persintence.Interface;

namespace DeliveryApp.API.ViewModels
{
    public class UsuarioDisplayVM : IEntityDisplayModel<Usuario, Guid>
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string CI { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Roles { get; set; }

        public void Import(Usuario entity)
        {
            Id = entity.Id;
            Nombre = entity.Nombre;
            CI = entity.CI;
            Correo = entity.Correo;
            Direccion = entity.Direccion;
            Celular = entity.Celular;
            Roles = string.Join(", ", entity.Roles.Select(r => r.Nombre));
        }
    }
}
