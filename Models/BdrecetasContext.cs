using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionRecetas.Models;

public partial class BdrecetasContext : DbContext
{
    public BdrecetasContext()
    {
    }

    public BdrecetasContext(DbContextOptions<BdrecetasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingrediente> Ingredientes { get; set; }

    public virtual DbSet<Receta> Recetas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=SELIN-LGONZALEZ;database=BDRecetas;User Id=larryGonzalez;Password=ci11159753; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.HasKey(e => e.IdIngrediente).HasName("PK__Ingredie__3DA4DD60C8D1AE26");

            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Unidad)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRecetasNavigation).WithMany(p => p.Ingredientes)
                .HasForeignKey(d => d.IdRecetas)
                .HasConstraintName("FK_IdRecetario");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => e.IdRecetas).HasName("PK__Recetas__042B26DF7F35251B");

            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Imagen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Origen)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Preparacion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
