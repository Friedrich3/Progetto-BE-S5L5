using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Progetto_BE_S5L5.Models;

namespace Progetto_BE_S5L5.Data;

public partial class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anagrafica> Anagraficas { get; set; }

    public virtual DbSet<Verbale> Verbales { get; set; }

    public virtual DbSet<Violazione> Violaziones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Federico-PC\\SQLEXPRESS;Database=DbMulte;User Id=sa;Password=sa;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anagrafica>(entity =>
        {
            entity.HasKey(e => e.Idanagrafica).HasName("PK__Anagrafi__7AB1023C929CB4F0");

            entity.Property(e => e.Idanagrafica).ValueGeneratedNever();
        });

        modelBuilder.Entity<Verbale>(entity =>
        {
            entity.HasKey(e => e.IdVerbale).HasName("PK__Verbale__A0FAF4534A6E58E3");

            entity.Property(e => e.IdVerbale).ValueGeneratedNever();

            entity.HasOne(d => d.IdanagraficaNavigation).WithMany(p => p.Verbales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Anagrafica_Verbale");

            entity.HasOne(d => d.IdviolazioneNavigation).WithMany(p => p.Verbales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Violazione_Verbale");
        });

        modelBuilder.Entity<Violazione>(entity =>
        {
            entity.HasKey(e => e.Idviolazione).HasName("PK__Violazio__AF77BD923F484CD4");

            entity.Property(e => e.Idviolazione).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
