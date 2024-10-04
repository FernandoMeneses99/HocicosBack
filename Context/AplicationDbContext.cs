using HocicosBacks.Models;
using Microsoft.EntityFrameworkCore;

namespace HocicosBack.Context
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        public DbSet<Productos> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la tabla Productos
            modelBuilder.Entity<Productos>(entity =>
            // modelBuilder.Entity<Productos>().ToTable("Productos");
            {
                entity.HasKey(p => p.ProductoId); // Llave primaria

                // Asignando nombres de columnas personalizados
                entity.Property(p => p.Nombre).HasColumnName("nombre_producto");
                entity.Property(p => p.PrecioDeCompra).HasColumnName("precio_producto");
                entity.Property(p => p.Descripcion).HasColumnName("descripcion_producto");
                entity.Property(p => p.PrecioDeVenta).HasColumnName("pdv_producto");
                entity.Property(p => p.FechaDeCreacion).HasColumnName("Fecha");
                entity.Property(p => p.ID_Proveedor).HasColumnName("ID_prov");
            });
        }
    }
}
