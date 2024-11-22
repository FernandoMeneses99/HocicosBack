using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using HocicosBack.Models;


namespace HocicosBack.Repositorios
{
    public class HocicosContext : DbContext
    {
        public HocicosContext(DbContextOptions options) : base(options)
        {
        }

        // DbSet para cada entidad (tablas)de la base de datos
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Sabores> Sabores { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<ItemsDePedido> ItemsDePedido { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Envios> Envios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfuguration(modelBuilder);

        }
        private void EntityConfuguration(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Proveedor
            modelBuilder.Entity<Proveedores>().ToTable("Proveedores").HasKey(p => p.ID_Proveedor);

            // Configuración de Producto
            modelBuilder.Entity<Productos>().ToTable("Productos").HasKey(p => p.ProductoID);

            modelBuilder.Entity<Productos>().HasOne(p => p.Proveedor).WithMany(x => x.Productos);

            // Configuración de Sabor
            modelBuilder.Entity<Sabores>().ToTable("Sabores").HasKey(s => s.SaborID);

            modelBuilder.Entity<Sabores>().HasOne(s => s.Producto).WithMany(y => y.Sabores).HasForeignKey(s => s.ProductoID);

            // Configuración de Cliente
            modelBuilder.Entity<Clientes>().ToTable("Clientes").HasKey(c => c.ClienteID);

            //el value se pone en todos los campos que sean llaves primarias
            modelBuilder.Entity<Clientes>().Property(c => c.ClienteID).HasColumnName("ClienteID").ValueGeneratedOnAdd();
            modelBuilder.Entity<Clientes>().Property(c => c.NombreComercial).HasColumnName("NombreComercial");
            modelBuilder.Entity<Clientes>().Property(c => c.TipoDeCliente).HasColumnName("TipoDeCliente");
            modelBuilder.Entity<Clientes>().Property(c => c.CorreoElectronico).HasColumnName("CorreoElectrónico");
            modelBuilder.Entity<Clientes>().Property(c => c.ContrasenaHash).HasColumnName("ContrasenaHash");
            modelBuilder.Entity<Clientes>().Property(c => c.Direccion).HasColumnName("Direccion");
            modelBuilder.Entity<Clientes>().Property(c => c.Telefono).HasColumnName("Telefono");
            modelBuilder.Entity<Clientes>().Property(c => c.FechaDeCreacion).HasColumnName("FechaDeCreación");

            //configuracion de pedidos
            modelBuilder.Entity<Pedidos>().ToTable("Pedidos").HasKey(c => c.PedidoID);

            //el value se pone en todos los campos que sean llaves primarias
            modelBuilder.Entity<Pedidos>().Property(p => p.PedidoID).HasColumnName("PedidoID").ValueGeneratedOnAdd();
            modelBuilder.Entity<Pedidos>().Property(p => p.ClienteID).HasColumnName("ClienteID");
            modelBuilder.Entity<Pedidos>().Property(p => p.FechaDePedido).HasColumnName("FechaDePedido");
            modelBuilder.Entity<Pedidos>().Property(p => p.MontoTotal).HasColumnName("MontoTotal");
            modelBuilder.Entity<Pedidos>().Property(p => p.EstadoDelPedido).HasColumnName("EstadoDelPedido");

            //configuracion de la relacion entre pedidos y clientes
            modelBuilder.Entity<Pedidos>().HasOne(p => p.Cliente).WithMany(c => c.Pedidos).HasForeignKey(p => p.ClienteID);


            modelBuilder.Entity<ItemsDePedido>().HasOne(p => p.Producto).WithMany(c => c.ItemsDePedidos).HasForeignKey(y => y.ProductoID);


            // Configuración de Pedido
            modelBuilder.Entity<Pedidos>().ToTable("Pedidos").HasKey(p => p.PedidoID);

            modelBuilder.Entity<Pedidos>().HasOne(p => p.Cliente).WithMany(c => c.Pedidos).HasForeignKey(p => p.ClienteID).OnDelete(DeleteBehavior.Cascade);

            // Configuración de ItemDePedido
            modelBuilder.Entity<ItemsDePedido>().ToTable("ItemsDePedido").HasKey(i => i.ItemDePedidoID);

            object value = modelBuilder.Entity<ItemsDePedido>().HasOne(i => i.Pedido).WithMany(static p => p.ItemsDePedidos).HasForeignKey(i => i.PedidoID);

            modelBuilder.Entity<ItemsDePedido>().HasOne(i => i.Producto).WithMany().HasForeignKey(i => i.ProductoID);

            modelBuilder.Entity<ItemsDePedido>().HasOne(i => i.Sabor).WithMany().HasForeignKey(i => i.SaborID);

            // Configuración de Pago
            modelBuilder.Entity<Pagos>().ToTable("Pagos").HasKey(pa => pa.PagoId);

            modelBuilder.Entity<Pagos>().HasOne(pa => pa.Pedido).WithMany(px => px.Pagos).HasForeignKey(pa => pa.PedidoId);

            // Configuración de la entidad Envios
            modelBuilder.Entity<Envios>(entity =>
            {
                entity.ToTable("Envios");entity.HasKey(e => e.EnvioID); // Clave primaria

                // Configuración de relaciones
                entity.HasOne(e => e.Pedido).WithMany().HasForeignKey(e => e.PedidoID);

                // Configuración de propiedades
                entity.Property(p => p.EnvioID).HasColumnName("EnvioID").ValueGeneratedOnAdd();

                entity.Property(p => p.PedidoID).HasColumnName("PedidoID").IsRequired();

                entity.Property(p => p.MetodoDeEnvio).HasColumnName("MetodoDeEnvio").HasMaxLength(50).IsRequired();

                entity.Property(p => p.DireccionDeEnvio).HasColumnName("DireccionDeEnvio").HasMaxLength(500).IsRequired();

                entity.Property(p => p.FechaDeEnvio).HasColumnName("FechaDeEnvio").HasColumnType("datetime");
            });
        }

        // Método para guardar los cambios
        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

    }
}

