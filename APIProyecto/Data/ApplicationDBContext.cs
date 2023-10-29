using APIProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProyecto.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(

            DbContextOptions<ApplicationDBContext> options) : base(options) { }
        //CREA LAS TABLAS
        public DbSet<TipoProducto> sgc_TipoProducto { get; set; }
        public DbSet<TallaProducto> sgc_TallaProducto { get; set; }
        public DbSet<ColorProducto> sgc_ColorProducto { get; set; }
        public DbSet<Cliente> sgc_Cliente { get; set; }
        
        public DbSet<ProductoColorTalla> sgc_ProductoColorTalla {  get; set; }
        public DbSet<Producto> sgc_ProductoTab { get; set; }
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
                    NumeroSeguridad=153,
                    NumeroTarjeta=123234345,
                });

            /*modelBuilder.Entity<TipoProducto>()
                 .HasMany(p => p.Productos)
                 .WithOne(t => t.TipoProducto)
                 .HasForeignKey(t => t.TipoProductoIdTipoProducto);*/

            modelBuilder.Entity<Producto>()
            .HasOne(p => p.TipoProducto)
            .WithMany()  // Puedes configurar WithMany si hay una relación de uno a muchos
            .HasForeignKey(p => p.TipoProductoIdTipoProducto);

            modelBuilder.Entity<Producto>()
                 .HasMany(p => p.ProductosColoresTallas)
                 .WithOne(t => t.Producto)
                 .HasForeignKey(t => t.ProductoIdProduto);

            modelBuilder.Entity<ColorProducto>()
                .HasMany(p => p.ProductosColoresTallas)
                .WithOne(t => t.ColorProducto)
                .HasForeignKey(t => t.ColorProductoIdColorProducto);

            modelBuilder.Entity<TallaProducto>()
                .HasMany(p => p.ProductosColoresTallas)
                .WithOne(t => t.TallaProducto)
                .HasForeignKey(t => t.TallaProductoIdTallaProducto);




        }



    }
}
