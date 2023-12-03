﻿// <auto-generated />
using APIProyecto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIProyecto.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIProyecto.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroSeguridad")
                        .HasColumnType("int");

                    b.Property<int>("NumeroTarjeta")
                        .HasColumnType("int");

                    b.HasKey("IdCliente");

                    b.ToTable("sgc_Cliente");

                    b.HasData(
                        new
                        {
                            IdCliente = 1,
                            Apellido = "APELLIDO CLEINTE 1",
                            Cedula = "1711512663",
                            Direccion = "DIRECCION CLIETE",
                            Nombre = "CLIENTE 1",
                            NumeroSeguridad = 153,
                            NumeroTarjeta = 123234345
                        });
                });

            modelBuilder.Entity("APIProyecto.Models.ColorProducto", b =>
                {
                    b.Property<int>("IdColorProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdColorProducto"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdColorProducto");

                    b.ToTable("sgc_ColorProducto");
                });

            modelBuilder.Entity("APIProyecto.Models.Producto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduto"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoProductoIdTipoProducto")
                        .HasColumnType("int");

                    b.HasKey("IdProduto");

                    b.HasIndex("TipoProductoIdTipoProducto");

                    b.ToTable("sgc_ProductoTab");
                });

            modelBuilder.Entity("APIProyecto.Models.ProductoColorTalla", b =>
                {
                    b.Property<int>("IdProductoColorTalla")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProductoColorTalla"));

                    b.Property<int>("ColorProductoIdColorProducto")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("ProductoIdProduto")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("StockMax")
                        .HasColumnType("int");

                    b.Property<int>("StockMin")
                        .HasColumnType("int");

                    b.Property<int>("TallaProductoIdTallaProducto")
                        .HasColumnType("int");

                    b.HasKey("IdProductoColorTalla");

                    b.HasIndex("ColorProductoIdColorProducto");

                    b.HasIndex("ProductoIdProduto");

                    b.HasIndex("TallaProductoIdTallaProducto");

                    b.ToTable("sgc_ProductoColorTalla");
                });

            modelBuilder.Entity("APIProyecto.Models.TallaProducto", b =>
                {
                    b.Property<int>("IdTallaProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTallaProducto"));

                    b.Property<string>("Talla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTallaProducto");

                    b.ToTable("sgc_TallaProducto");
                });

            modelBuilder.Entity("APIProyecto.Models.TipoProducto", b =>
                {
                    b.Property<int>("IdTipoProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoProducto"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoProducto");

                    b.ToTable("sgc_TipoProducto");
                });

            modelBuilder.Entity("APIProyecto.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroSeguridad")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.ToTable("sgc_Usuarios");

                    b.HasData(
                        new
                        {
                            IdUsuario = 1,
                            Apellido = "APELLIDO USUARIO 1",
                            Cedula = "1711512663",
                            Contrasenia = "CONTRASENIAADMIN",
                            Login = "USUARIOADMIN",
                            Nombre = "USUARIO 1",
                            NumeroSeguridad = 1
                        });
                });

            modelBuilder.Entity("APIProyecto.Models.Producto", b =>
                {
                    b.HasOne("APIProyecto.Models.TipoProducto", "TipoProducto")
                        .WithMany()
                        .HasForeignKey("TipoProductoIdTipoProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoProducto");
                });

            modelBuilder.Entity("APIProyecto.Models.ProductoColorTalla", b =>
                {
                    b.HasOne("APIProyecto.Models.ColorProducto", "ColorProducto")
                        .WithMany()
                        .HasForeignKey("ColorProductoIdColorProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIProyecto.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoIdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIProyecto.Models.TallaProducto", "TallaProducto")
                        .WithMany()
                        .HasForeignKey("TallaProductoIdTallaProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ColorProducto");

                    b.Navigation("Producto");

                    b.Navigation("TallaProducto");
                });
#pragma warning restore 612, 618
        }
    }
}
