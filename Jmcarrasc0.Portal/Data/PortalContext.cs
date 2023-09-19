using System;
using System.Collections.Generic;
using Jmcarrasc0.Portal.Models;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Data;

public partial class PortalContext : DbContext
{
    public PortalContext(DbContextOptions<PortalContext> options)
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

    public virtual DbSet<UsuarioPassCounts> UsuarioPassCounts { get; set; }

    public virtual DbSet<UsuarioPassResets> UsuarioPassResets { get; set; }

    public virtual DbSet<UsuarioRoles> UsuarioRoles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Archivos>(entity =>
        {
            entity.HasKey(e => e.IDArchivo).HasName("PK__Archivos__F289B5E1931806FE");

            entity.Property(e => e.IDArchivo).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Estatus>(entity =>
        {
            entity.HasKey(e => e.IDEstatus).HasName("PK__Estatus__042C4B513C89F6EB");

            entity.Property(e => e.IDEstatus).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.IDPais).HasName("PK__Pais__8A5C2D2F9A965066");

            entity.Property(e => e.IDPais).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Prioridades>(entity =>
        {
            entity.HasKey(e => e.IDPrioridad).HasName("PK__Priorida__116AAFBEB4628B69");

            entity.Property(e => e.IDPrioridad).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.IDRol).HasName("PK__Roles__A681ACB6B583BA86");

            entity.Property(e => e.IDRol).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<UsuarioEstatus>(entity =>
        {
            entity.HasKey(e => e.IDUsuarioEstatus).HasName("PK__UsuarioE__C19EBAFBD308005D");

            entity.Property(e => e.IDUsuarioEstatus).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IDEstatusNavigation).WithMany(p => p.UsuarioEstatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioEs__IDEst__619B8048");

            entity.HasOne(d => d.IDUsuarioNavigation).WithMany(p => p.UsuarioEstatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioEs__IDUsu__628FA481");
        });

        modelBuilder.Entity<UsuarioImagenes>(entity =>
        {
            entity.HasKey(e => e.IDUsuarioImagen).HasName("PK__UsuarioI__A54D3B1BC086D8D0");

            entity.Property(e => e.IDUsuarioImagen).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UsuarioImagenesCreatedByNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioIm__Creat__6383C8BA");

            entity.HasOne(d => d.IDArchivoNavigation).WithMany(p => p.UsuarioImagenes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioIm__IDArc__6477ECF3");

            entity.HasOne(d => d.IDUsuarioNavigation).WithMany(p => p.UsuarioImagenesIDUsuarioNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioIm__IDUsu__656C112C");
        });

        modelBuilder.Entity<UsuarioPass>(entity =>
        {
            entity.HasKey(e => e.IDUsuarioPass).HasName("PK__UsuarioP__4523E4618CA2EF5C");

            entity.Property(e => e.IDUsuarioPass).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IDUsuarioNavigation).WithMany(p => p.UsuarioPass)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioPa__IDUsu__66603565");
        });

        modelBuilder.Entity<UsuarioPassCounts>(entity =>
        {
            entity.HasKey(e => e.IDUsuarioPassCount).HasName("PK__UsuarioP__6A204856E9C32B7E");

            entity.Property(e => e.IDUsuarioPassCount).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<UsuarioPassResets>(entity =>
        {
            entity.HasKey(e => e.IDUsuarioPassReset).HasName("PK__UsuarioP__B57240880F529362");

            entity.Property(e => e.IDUsuarioPassReset).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<UsuarioRoles>(entity =>
        {
            entity.HasKey(e => e.IDUsuarioRol).HasName("PK__UsuarioR__3A284C80F0092F36");

            entity.Property(e => e.IDUsuarioRol).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IDRolNavigation).WithMany(p => p.UsuarioRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioRo__IDRol__6754599E");

            entity.HasOne(d => d.IDUsuarioNavigation).WithMany(p => p.UsuarioRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioRo__IDUsu__68487DD7");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IDUsuario).HasName("PK__Usuarios__5231116976B7C76B");

            entity.Property(e => e.IDUsuario).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
