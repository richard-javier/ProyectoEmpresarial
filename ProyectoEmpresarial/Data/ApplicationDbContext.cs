using Microsoft.EntityFrameworkCore;
using ProyectoEmpresarial.Modelos.Clientes;
using ProyectoEmpresarial.Modelos.Compras;
using ProyectoEmpresarial.Modelos.Inventario;
using ProyectoEmpresarial.Modelos.Seguridad;
using ProyectoEmpresarial.Modelos.Ventas;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProyectoEmpresarial.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Iventario;Integrated Security=True;TrustServerCertificate=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<SolicitudCompra> SolicitudesCompra { get; set; }
        public DbSet<OrdenCompra> OrdenesCompra { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetallesFactura { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar User
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
            
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            // Configurar Role
            modelBuilder.Entity<Role>()
                .HasKey(r => r.RoleId);

            modelBuilder.Entity<Role>()
                .HasIndex(r => r.RoleName)
                .IsUnique();

            // Configurar UserRole para relaciones muchos a muchos
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // Configurar Cliente
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.ClienteId);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Contactos)
                .WithOne(c => c.Cliente)
                .HasForeignKey(c => c.ClienteId);

            // Configurar Contacto
            modelBuilder.Entity<Contacto>()
                .HasKey(c => c.ContactoId);

            modelBuilder.Entity<Contacto>()
                .HasIndex(c => c.Email)
                .IsUnique();
            // Configurar SolicitudCompra
            modelBuilder.Entity<SolicitudCompra>()
                .HasKey(sc => sc.SolicitudCompraId);

            modelBuilder.Entity<SolicitudCompra>()
                .HasMany(sc => sc.OrdenesCompra)
                .WithOne(oc => oc.SolicitudCompra)
                .HasForeignKey(oc => oc.SolicitudCompraId);

            // Configurar OrdenCompra
            modelBuilder.Entity<OrdenCompra>()
                .HasKey(oc => oc.OrdenCompraId);

            // Configurar Producto
            modelBuilder.Entity<Producto>()
                .HasKey(p => p.ProductoId);

            // Configurar Factura
            modelBuilder.Entity<Factura>()
                .HasKey(f => f.FacturaId);

            modelBuilder.Entity<Factura>()
                .HasMany(f => f.Detalles)
                .WithOne(df => df.Factura)
                .HasForeignKey(df => df.FacturaId);

            // Configurar DetalleFactura
            modelBuilder.Entity<DetalleFactura>()
                .HasKey(df => df.DetalleFacturaId);

            modelBuilder.Entity<DetalleFactura>()
                .HasOne(df => df.Factura)
                .WithMany(f => f.Detalles)
                .HasForeignKey(df => df.FacturaId);

            modelBuilder.Entity<DetalleFactura>()
                .HasOne(df => df.Producto)
                .WithMany()
                .HasForeignKey(df => df.ProductoId);
            // Configurar Inventario
            modelBuilder.Entity<Inventario>()
                .HasKey(i => i.InventarioId);

            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.Proveedor)
                .WithMany(p => p.Inventarios)
                .HasForeignKey(i => i.ProveedorId);

            // Configurar Proveedor
            modelBuilder.Entity<Proveedor>()
                .HasKey(p => p.ProveedorId);

            modelBuilder.Entity<Proveedor>()
                .HasMany(p => p.Inventarios)
                .WithOne(i => i.Proveedor)
                .HasForeignKey(i => i.ProveedorId);

        }
    }

}
