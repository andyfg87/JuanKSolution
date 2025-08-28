using JuanK.Persintence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Persintence.EF
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<UsuarioRol> UsuarioRoles { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProcesoVenta> Ventas { get; set; }
        public DbSet<ProcesoVentaProducto> VentasProductos { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<CarritoItem> CarritoItems { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar relación Many-to-Many Usuario-Rol
            modelBuilder.Entity<UsuarioRol>()
                .HasKey(ur => new { ur.UsuarioId, ur.RolId });

            // Configurar relación Many-to-Many ProcesoVenta-Producto
            modelBuilder.Entity<ProcesoVentaProducto>()
        .HasKey(vp => new { vp.ProcesoVentaId, vp.ProductoId }); // Clave compuesta

            modelBuilder.Entity<ProcesoVentaProducto>()
                .HasOne(vp => vp.ProcesoVenta)
                .WithMany(pv => pv.ProductosVendidos) // Cambia ICollection<Producto> por ICollection<ProcesoVentaProducto>
                .HasForeignKey(vp => vp.ProcesoVentaId);

            modelBuilder.Entity<ProcesoVentaProducto>()
                .HasOne(vp => vp.Producto)
                .WithMany() // Si Producto no tiene una colección de ProcesoVenta
                .HasForeignKey(vp => vp.ProductoId);
        }
    }
}
