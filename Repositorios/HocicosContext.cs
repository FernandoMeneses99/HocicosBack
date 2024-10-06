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

            modelBuilder.Entity<Productos>().HasOne(p => p.ID_Proveedor).WithMany().HasForeignKey(p => p.ID_Proveedor);

            // Configuración de Sabor
            modelBuilder.Entity<Sabores>().ToTable("Sabores").HasKey(s => s.SaboresID);

            modelBuilder.Entity<Sabores>().HasOne(s => s.Productos).WithMany().HasForeignKey(s => s.ProductosID);

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
            modelBuilder.Entity<Pedidos>().ToTable("Pedido").HasKey(c => c.PedidoID);
            //el value se pone en todos los campos que sean llaves primarias
            modelBuilder.Entity<Pedidos>().Property(p => p.PedidoID).HasColumnName("PedidoID").ValueGeneratedOnAdd();
            modelBuilder.Entity<Pedidos>().Property(p => p.ClienteID).HasColumnName("ClienteID");
            modelBuilder.Entity<Pedidos>().Property(p => p.FechaDePedido).HasColumnName("FechaDePedido");
            modelBuilder.Entity<Pedidos>().Property(p => p.MontoTotal).HasColumnName("MontoTotal");
            modelBuilder.Entity<Pedidos>().Property(p => p.EstadoDelPedido).HasColumnName("EstadoDelPedido");

            //configuracion de la relaciion entre pedidos y clientes
            modelBuilder.Entity<Pedidos>().HasOne(p => p.Clientes).WithMany(c => c.Pedidos).HasForeignKey(p => p.ClienteID);

      




            // Configuración de Pedido
            modelBuilder.Entity<Pedidos>().ToTable("Pedidos").HasKey(p => p.PedidoID);

            modelBuilder.Entity<Pedidos>().HasOne(p => p.Cliente).WithMany().HasForeignKey(p => p.ClienteID);

            // Configuración de ItemDePedido
            modelBuilder.Entity<ItemsDePedido>().ToTable("ItemsDePedido").HasKey(i => i.ItemDePedidoID);

            modelBuilder.Entity<ItemsDePedido>().HasOne(i => i.Pedidos).WithMany(p => p.ItemsDePedido).HasForeignKey(i => i.PedidoID);

            modelBuilder.Entity<ItemsDePedido>().HasOne(i => i.Productos).WithMany().HasForeignKey(i => i.ProductoID);

            modelBuilder.Entity<ItemsDePedido>().HasOne(i => i.Sabores).WithMany().HasForeignKey(i => i.SaborID);

            // Configuración de Pago
            modelBuilder.Entity<Pagos>().ToTable("Pagos").HasKey(pa => pa.PagoID);

            modelBuilder.Entity<Pagos>().HasOne(pa => pa.Pedido).WithMany().HasForeignKey(pa => pa.PedidoID);

            // Configuración de Envio
            modelBuilder.Entity<Envios>().ToTable("Envios").HasKey(e => e.EnvioID);

            modelBuilder.Entity<Envios>().HasOne(e => e.Pedido).WithMany().HasForeignKey(e => e.PedidoID);
        }




    }

    // Método para guardar los cambios
    public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}

