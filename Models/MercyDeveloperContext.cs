using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ev1_u1.Models;

public partial class MercyDeveloperContext : DbContext
{
    public MercyDeveloperContext()
    {
    }

    public MercyDeveloperContext(DbContextOptions<MercyDeveloperContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<ServiciosCliente> ServiciosClientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) { }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion)
                .HasMaxLength(45)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Rut)
                .HasMaxLength(45)
                .HasColumnName("rut");
            entity.Property(e => e.ServicioATomar)
                .HasMaxLength(45)
                .HasColumnName("servicio_a_tomar");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PRIMARY");

            entity.ToTable("servicios");

            entity.Property(e => e.IdServicio)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_servicio");
            entity.Property(e => e.Comentarios)
                .HasMaxLength(45)
                .HasColumnName("comentarios");
            entity.Property(e => e.Disponibilidad)
                .HasMaxLength(45)
                .HasColumnName("disponibilidad");
            entity.Property(e => e.Estado)
                .HasMaxLength(45)
                .HasColumnName("estado");
            entity.Property(e => e.Precios)
                .HasMaxLength(45)
                .HasColumnName("precios");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<ServiciosCliente>(entity =>
        {
            entity.HasKey(e => new { e.ServiciosIdServicio, e.ClientesIdCliente })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("servicios_clientes");

            entity.HasIndex(e => e.ClientesIdCliente, "fk_servicios_has_clientes_clientes1_idx");

            entity.HasIndex(e => e.ServiciosIdServicio, "fk_servicios_has_clientes_servicios_idx");

            entity.Property(e => e.ServiciosIdServicio)
                .HasColumnType("int(11)")
                .HasColumnName("servicios_id_servicio");
            entity.Property(e => e.ClientesIdCliente)
                .HasColumnType("int(11)")
                .HasColumnName("clientes_id_cliente");
            entity.Property(e => e.Inicio)
                .HasMaxLength(45)
                .HasColumnName("inicio");
            entity.Property(e => e.NProceso)
                .HasMaxLength(45)
                .HasColumnName("n_proceso");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(45)
                .HasColumnName("observaciones");
            entity.Property(e => e.Tecnico)
                .HasMaxLength(45)
                .HasColumnName("tecnico");
            entity.Property(e => e.Termino)
                .HasMaxLength(45)
                .HasColumnName("termino");

            entity.HasOne(d => d.ClientesIdClienteNavigation).WithMany(p => p.ServiciosClientes)
                .HasForeignKey(d => d.ClientesIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_servicios_has_clientes_clientes1");

            entity.HasOne(d => d.ServiciosIdServicioNavigation).WithMany(p => p.ServiciosClientes)
                .HasForeignKey(d => d.ServiciosIdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_servicios_has_clientes_servicios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
