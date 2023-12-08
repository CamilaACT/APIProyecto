using APIProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProyecto.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(

            DbContextOptions<ApplicationDBContext> options) : base(options) { }
        //CREA LAS TABLAS ADMINISTRACION
        public DbSet<TipoProducto> sgc_TipoProducto { get; set; }
        public DbSet<TallaProducto> sgc_TallaProducto { get; set; }
        public DbSet<ColorProducto> sgc_ColorProducto { get; set; }
        public DbSet<Cliente> sgc_Cliente { get; set; }
        
        public DbSet<ProductoColorTalla> sgc_ProductoColorTalla {  get; set; }
        public DbSet<Producto> sgc_ProductoTab { get; set; }
        public DbSet<Usuario> sgc_Usuarios { get; set; }

        //TABLAS PARA COMPRAS
        public DbSet<IntencionCompra> sgc_IntencionCompra { get; set; }
        public DbSet<IntencionDescripcion> sgc_IntencionDescripcion { get; set; }
        public DbSet<Factura> sgc_Factura { get; set; }
        public DbSet<Descripcion> sgc_Descripcion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
          

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    IdCliente= 1,
                    Nombre = "CLIENTE 1",
                    Apellido= "APELLIDO CLEINTE 1",
                    Cedula="1711512663",
                    Direccion="DIRECCION CLIETE",
                    NumeroTarjeta=123234345,
                    Contrasenia="123",
                    Login="cliente1"

                });

            /*modelBuilder.Entity<TipoProducto>()
                 .HasMany(p => p.Productos)
                 .WithOne(t => t.TipoProducto)
                 .HasForeignKey(t => t.TipoProductoIdTipoProducto);*/

            modelBuilder.Entity<Producto>()
            .HasOne(p => p.TipoProducto)
            .WithMany()  // Puedes configurar WithMany si hay una relación de uno a muchos
            .HasForeignKey(p => p.TipoProductoIdTipoProducto);

            modelBuilder.Entity<ProductoColorTalla>()
        .HasOne(pct => pct.Producto)
        .WithMany()
        .HasForeignKey(pct => pct.ProductoIdProduto);

            modelBuilder.Entity<ProductoColorTalla>()
                .HasOne(pct => pct.TallaProducto)
                .WithMany()
                .HasForeignKey(pct => pct.TallaProductoIdTallaProducto);

            modelBuilder.Entity<ProductoColorTalla>()
                .HasOne(pct => pct.ColorProducto)
                .WithMany()
                .HasForeignKey(pct => pct.ColorProductoIdColorProducto);


            //relaciones Intencion Compra
            modelBuilder.Entity<Factura>()
               .HasOne(c => c.Cliente)
               .WithMany()
               .HasForeignKey(c => c.ClienteIdCliente);

            modelBuilder.Entity<IntencionCompra>()
               .HasOne(c => c.Cliente)
               .WithMany()
               .HasForeignKey(c => c.ClienteIdCliente);

            //relaciones Intencion Descripcion
            modelBuilder.Entity<IntencionDescripcion>()
               .HasOne(c => c.ProductoColorTalla)
               .WithMany()
               .HasForeignKey(c => c.ProductoColorTallaIdProductoColorTalla);

            modelBuilder.Entity<IntencionDescripcion>()
               .HasOne(ic => ic.IntencionCompra)
               .WithMany()
               .HasForeignKey(c => c.IntencionCompraIdIntencionCompra);

            modelBuilder.Entity<Usuario>().HasData(
                  new Usuario
                  {
                      IdUsuario= 1,
                      Nombre = "USUARIO 1",
                      Apellido= "APELLIDO USUARIO 1",
                      Cedula="1711512663",
                      Login="USUARIOADMIN",
                      Contrasenia="CONTRASENIAADMIN",
                      NumeroSeguridad=1,
                  });


            /* modelBuilder.Entity<ColorProducto>()
                 .HasMany(p => p.ProductosColoresTallas)
                 .WithOne(t => t.ColorProducto)
                 .HasForeignKey(t => t.ColorProductoIdColorProducto);*/

            /*modelBuilder.Entity<TallaProducto>()
                .HasMany(p => p.ProductosColoresTallas)
                .WithOne(t => t.TallaProducto)
                .HasForeignKey(t => t.TallaProductoIdTallaProducto);*/

        }



    }
}
