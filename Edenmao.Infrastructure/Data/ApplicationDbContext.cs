using Edenmao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Infrastructure.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Articulo> Articulose  { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Clientes> Clientess { get; set; }
        public virtual DbSet<Pedidos> Pedidoss { get; set; }
        public virtual DbSet<DetallePedidos> DetallePedidoss { get; set; }
        public virtual DbSet<DetallePedidos_Articulos> DetallePedidos_Articuloss { get; set; }
        public virtual DbSet<Personificacion> Personificacions { get; set; }
        public virtual DbSet<Roles> Roless { get; set; }
        public virtual DbSet<Usuarios> Usuarioss { get; set; }
       //edward
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer("Server=DESKTOP-FSUML67\\SQLEXPRESS;Database=TimelyDBApplication;integrated security=true; TrustServerCertificate=True");
        //Creando las Relaciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            modelBuilder.Entity<DetallePedidos_Articulos>().HasKey(pa => new { pa.IDPedido, pa.IDArticulo });
            //
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.IDArticulo);

                entity.Property(e => e.IDArticulo).ValueGeneratedNever();

                entity.HasOne(d => d.IDCategoriaNav).WithMany(p => p.Articulos);
                entity.HasOne(d => d.IDPersonificacionNav).WithMany(p => p.Articulos);
            });
            //
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IDClientes);

                entity.Property(e => e.IDClientes).ValueGeneratedNever();

                entity.HasOne(d => d.IDUsuarioNav).WithMany(p => p.Clientes);
            });
            //
            modelBuilder.Entity<DetallePedidos>(entity =>
            {
                entity.HasKey(e => e.IDDetallePedido);

                entity.Property(e => e.IDDetallePedido).ValueGeneratedNever();

                entity.HasOne(d => d.IDPedidoNav).WithMany(p => p.DetallePedidos);
            });
            //
            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.HasKey(e => e.IDPedidos);

                entity.Property(e => e.IDPedidos).ValueGeneratedNever();

                entity.HasOne(d => d.IDClienteNav).WithMany(p => p.Pedidos);
            });
            //
            modelBuilder.Entity<Personificacion>(entity => { entity.HasKey(e => e.IDPersonificacion);});
            //
            modelBuilder.Entity<Categoria>(entity => { entity.HasKey(e => e.IDCategoria); });
            //
            modelBuilder.Entity<Roles>(entity => { entity.HasKey(e => e.IDRolUsuario); });
            //
            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IDUsuario);

                entity.Property(e => e.IDUsuario).ValueGeneratedNever();

                entity.HasOne(d => d.IDRolUsuarioNav).WithMany(p => p.Usuarios);
            });
        }

    }
}
