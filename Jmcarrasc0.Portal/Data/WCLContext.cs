using System;
using System.Collections.Generic;
using Jmcarrasc0.Portal.Models;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Data;

public partial class WCLContext : DbContext
{
    public WCLContext(DbContextOptions<WCLContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Archivos> Archivos { get; set; }

    public virtual DbSet<Estatus> Estatus { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<Prioridades> Prioridades { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<UsuarioEstatus> UsuarioEstatus { get; set; }

    public virtual DbSet<UsuarioImagenes> UsuarioImagenes { get; set; }

    public virtual DbSet<UsuarioPass> UsuarioPass { get; set; }

    public virtual DbSet<UsuarioRoles> UsuarioRoles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Dev");

        modelBuilder.Entity<Archivos>(entity =>
        {
            entity.HasKey(e => e.IDArchivo).HasName("PK__Archivos__F289B5E1636A71D7");

            entity.Property(e => e.IDArchivo).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Estatus>(entity =>
        {
            entity.HasKey(e => e.IDEstatus).HasName("PK__Estatus__042C4B510897CE8C");

            entity.Property(e => e.IDEstatus).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.IDPais).HasName("PK__Pais__8A5C2D2F424C2B14");

            entity.Property(e => e.IDPais).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Prioridades>(entity =>
        {
            entity.HasKey(e => e.IDPrioridad).HasName("PK__Priorida__116AAFBEFC2047EA");

            entity.Property(e => e.IDPrioridad).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.IDRol).HasName("PK__Roles__A681ACB61C713AA5");

            entity.Property(e => e.IDRol).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<UsuarioEstatus>(entity =>
        {
            entity.HasKey(e => e.IDUsuarioEstatus).HasName("PK__UsuarioE__C19EBAFBA60A5B83");

            entity.Property(e => e.IDUsuarioEstatus).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IDEstatusNavigation).WithMany(p => p.UsuarioEstatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioEs__IDEst__4316F928");

            entity.HasOne(d => d.IDUsuarioNavigation).WithMany(p => p.UsuarioEstatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioEs__IDUsu__4222D4EF");
        });

        modelBuilder.Entity<UsuarioImagenes>(entity =>
        {
            entity.HasKey(e => e.IDUsuarioImagen).HasName("PK__UsuarioI__A54D3B1BF47CD876");

            entity.Property(e => e.IDUsuarioImagen).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UsuarioImagenesCreatedByNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioIm__Creat__4F7CD00D");

            entity.HasOne(d => d.IDArchivoNavigation).WithMany(p => p.UsuarioImagenes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioIm__IDArc__4D94879B");

            entity.HasOne(d => d.IDUsuarioNavigation).WithMany(p => p.UsuarioImagenesIDUsuarioNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioIm__IDUsu__4CA06362");
        });

        modelBuilder.Entity<UsuarioPass>(entity =>
        {
            entity.HasKey(e => e.IDUsuarioPass).HasName("PK__UsuarioP__4523E4613736CC10");

            entity.Property(e => e.IDUsuarioPass).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IDUsuarioNavigation).WithMany(p => p.UsuarioPass)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioPa__IDUsu__47DBAE45");
        });

        modelBuilder.Entity<UsuarioRoles>(entity =>
        {
            entity.HasKey(e => e.IDUsuarioRol).HasName("PK__UsuarioR__3A284C80A2177AB5");

            entity.Property(e => e.IDUsuarioRol).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IDRolNavigation).WithMany(p => p.UsuarioRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioRo__IDRol__3D5E1FD2");

            entity.HasOne(d => d.IDUsuarioNavigation).WithMany(p => p.UsuarioRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioRo__IDUsu__3C69FB99");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IDUsuario).HasName("PK__Usuarios__5231116944718508");

            entity.Property(e => e.IDUsuario).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
