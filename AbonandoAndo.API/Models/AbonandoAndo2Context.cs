using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AbonandoAndo.API.Models
{
    public partial class AbonandoAndo2Context : DbContext
    {
        public AbonandoAndo2Context()
        {
        }

        public AbonandoAndo2Context(DbContextOptions<AbonandoAndo2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Comprobante> Comprobantes { get; set; } = null!;
        public virtual DbSet<Concepto> Conceptos { get; set; } = null!;
        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Operacion> Operacions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PC-ESCRITORIO\\MSSQLSERVER1;Database=AbonandoAndo2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("CLIENTE");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOS");

                entity.Property(e => e.Cuil).HasColumnName("CUIL");

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DOMICILIO");

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
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

            modelBuilder.Entity<Comprobante>(entity =>
            {
                entity.HasKey(e => e.IdComprobante);

                entity.ToTable("COMPROBANTE");

                entity.Property(e => e.IdComprobante).HasColumnName("ID_COMPROBANTE");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.IdConcepto).HasColumnName("ID_CONCEPTO");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");

                entity.Property(e => e.IdOperacion).HasColumnName("ID_OPERACION");

                //entity.HasOne(d => d.IdClienteNavigation)
                    //.WithMany(p => p.Comprobantes)
                    //.HasForeignKey(d => d.IdCliente)
                    //.HasConstraintName("FK_ID_CLIENTE");

                //entity.HasOne(d => d.IdConceptoNavigation)
                //    .WithMany(p => p.Comprobantes)
                //    .HasForeignKey(d => d.IdConcepto)
                //    .HasConstraintName("FK_ID_CONCEPTO");

                //entity.HasOne(d => d.IdOperacionNavigation)
                //    .WithMany(p => p.Comprobantes)
                //    .HasForeignKey(d => d.IdOperacion)
                //    .HasConstraintName("FK_ID_OPERACION");
            });

            modelBuilder.Entity<Concepto>(entity =>
            {
                entity.HasKey(e => e.IdConcepto);

                entity.ToTable("CONCEPTO");

                entity.Property(e => e.IdConcepto).HasColumnName("ID_CONCEPTO");

                entity.Property(e => e.Concepto1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONCEPTO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Importe)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("IMPORTE");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.ToTable("EMPRESA");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");

                entity.Property(e => e.Actividad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVIDAD");

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DOMICILIO");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RAZON_SOCIAL");
            });

            modelBuilder.Entity<Operacion>(entity =>
            {
                entity.HasKey(e => e.IdOperacion);

                entity.ToTable("OPERACION");

                entity.Property(e => e.IdOperacion).HasColumnName("ID_OPERACION");

                entity.Property(e => e.Tipo).HasColumnName("TIPO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
