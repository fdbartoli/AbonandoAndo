using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AbonandoAndo.api.Models;

public partial class AbonandoAndoContext : DbContext
{
    public AbonandoAndoContext()
    {
    }

    public AbonandoAndoContext(DbContextOptions<AbonandoAndoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuentum> Cuenta { get; set; }

    public virtual DbSet<Egreso> Egresos { get; set; }

    public virtual DbSet<Ingreso> Ingresos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-97UQTL2;Database=AbonandoAndo;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("CLIENTE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Cuil)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CUIL");
            entity.Property(e => e.Domicilio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DOMICILIO");
            entity.Property(e => e.Mail)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MAIL");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Cuentum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CUENTA");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Cuil)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CUIL");
            entity.Property(e => e.Debe)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DEBE");
            entity.Property(e => e.Haber)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("HABER");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SALDO");
        });

        modelBuilder.Entity<Egreso>(entity =>
        {
            entity.ToTable("EGRESO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Detalle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DETALLE");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MONTO");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Egresos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_EGRESO_CLIENTE");
        });

        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.ToTable("INGRESO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Detalle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DETALLE");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MONTO");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_INGRESO_CLIENTE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
