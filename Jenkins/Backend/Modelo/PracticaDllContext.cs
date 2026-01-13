using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

public partial class PracticaDllContext : DbContext
{
    public PracticaDllContext()
    {
    }

    public PracticaDllContext(DbContextOptions<PracticaDllContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bebidum> Bebida { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DisponibilidadMesa> DisponibilidadMesas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoBebidum> PedidoBebida { get; set; }

    public virtual DbSet<PedidoPlato> PedidoPlatos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Plato> Platos { get; set; }

    public virtual DbSet<PlatoProducto> PlatoProductos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;database=practica_dll;user=root;password=mysql");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bebidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Dni).HasName("PRIMARY");
        });

        modelBuilder.Entity<DisponibilidadMesa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.IdMesaNavigation).WithMany(p => p.DisponibilidadMesas)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("disponibilidad_mesa_ibfk_1");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.FechaPago).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.IdPedidoNavigation).WithOne(p => p.Factura).HasConstraintName("factura_ibfk_1");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.IdMesa).HasName("PRIMARY");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Fecha).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.DniClienteNavigation).WithMany(p => p.Pedidos)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pedidos_ibfk_1");
        });

        modelBuilder.Entity<PedidoBebidum>(entity =>
        {
            entity.HasKey(e => new { e.IdPedido, e.IdBebida }).HasName("PRIMARY");

            entity.Property(e => e.Cantidad).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.IdBebidaNavigation).WithMany(p => p.PedidoBebida).HasConstraintName("pedido_bebida_ibfk_2");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidoBebida).HasConstraintName("pedido_bebida_ibfk_1");
        });

        modelBuilder.Entity<PedidoPlato>(entity =>
        {
            entity.HasKey(e => new { e.IdPedido, e.IdPlato }).HasName("PRIMARY");

            entity.Property(e => e.Cantidad).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidoPlatos).HasConstraintName("pedido_plato_ibfk_1");

            entity.HasOne(d => d.IdPlatoNavigation).WithMany(p => p.PedidoPlatos).HasConstraintName("pedido_plato_ibfk_2");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasMany(d => d.IdPlatos).WithMany(p => p.IdPersonals)
                .UsingEntity<Dictionary<string, object>>(
                    "Prepara",
                    r => r.HasOne<Plato>().WithMany()
                        .HasForeignKey("IdPlato")
                        .HasConstraintName("prepara_ibfk_2"),
                    l => l.HasOne<Personal>().WithMany()
                        .HasForeignKey("IdPersonal")
                        .HasConstraintName("prepara_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdPersonal", "IdPlato").HasName("PRIMARY");
                        j.ToTable("prepara");
                        j.HasIndex(new[] { "IdPlato" }, "ID_Plato_idx");
                        j.IndexerProperty<int>("IdPersonal").HasColumnName("ID_Personal");
                        j.IndexerProperty<int>("IdPlato").HasColumnName("ID_Plato");
                    });
        });

        modelBuilder.Entity<Plato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<PlatoProducto>(entity =>
        {
            entity.HasKey(e => new { e.IdPlato, e.IdProducto }).HasName("PRIMARY");

            entity.HasOne(d => d.IdPlatoNavigation).WithMany(p => p.PlatoProductos).HasConstraintName("plato_producto_ibfk_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.PlatoProductos).HasConstraintName("plato_producto_ibfk_2");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasMany(d => d.IdProveedors).WithMany(p => p.IdProductos)
                .UsingEntity<Dictionary<string, object>>(
                    "Provee",
                    r => r.HasOne<Proveedor>().WithMany()
                        .HasForeignKey("IdProveedor")
                        .HasConstraintName("provee_ibfk_2"),
                    l => l.HasOne<Producto>().WithMany()
                        .HasForeignKey("IdProducto")
                        .HasConstraintName("provee_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdProducto", "IdProveedor").HasName("PRIMARY");
                        j.ToTable("provee");
                        j.HasIndex(new[] { "IdProveedor" }, "ID_Proveedor");
                        j.IndexerProperty<int>("IdProducto").HasColumnName("ID_Producto");
                        j.IndexerProperty<int>("IdProveedor").HasColumnName("ID_Proveedor");
                    });
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PRIMARY");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.DniClienteNavigation).WithMany(p => p.Reservas)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("reservas_ibfk_1");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.Reservas)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("reservas_ibfk_2");

            entity.HasMany(d => d.IdMesas).WithMany(p => p.IdReservas)
                .UsingEntity<Dictionary<string, object>>(
                    "ReservaMesa",
                    r => r.HasOne<Mesa>().WithMany()
                        .HasForeignKey("IdMesa")
                        .HasConstraintName("reserva_mesa_ibfk_2"),
                    l => l.HasOne<Reserva>().WithMany()
                        .HasForeignKey("IdReserva")
                        .HasConstraintName("reserva_mesa_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdReserva", "IdMesa").HasName("PRIMARY");
                        j.ToTable("reserva_mesa");
                        j.HasIndex(new[] { "IdMesa" }, "ID_Mesa");
                        j.IndexerProperty<int>("IdReserva").HasColumnName("ID_Reserva");
                        j.IndexerProperty<int>("IdMesa").HasColumnName("ID_Mesa");
                    });
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasMany(d => d.Permisos).WithMany(p => p.Rols)
                .UsingEntity<Dictionary<string, object>>(
                    "RolPermiso",
                    r => r.HasOne<Permiso>().WithMany()
                        .HasForeignKey("PermisoId")
                        .HasConstraintName("rol_permiso_ibfk_2"),
                    l => l.HasOne<Rol>().WithMany()
                        .HasForeignKey("RolId")
                        .HasConstraintName("rol_permiso_ibfk_1"),
                    j =>
                    {
                        j.HasKey("RolId", "PermisoId").HasName("PRIMARY");
                        j.ToTable("rol_permiso");
                        j.HasIndex(new[] { "PermisoId" }, "permiso_id");
                        j.IndexerProperty<int>("RolId").HasColumnName("rol_id");
                        j.IndexerProperty<int>("PermisoId").HasColumnName("permiso_id");
                    });
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.DniClienteNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("usuario_ibfk_2");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("usuario_ibfk_1");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("usuario_ibfk_3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
