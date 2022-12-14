using System;
using System.Collections.Generic;
using FinalDesafio.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalDesafio.Data;

public partial class AtosEntity8Context : DbContext
{
    public AtosEntity8Context()
    {
    }

    public AtosEntity8Context(DbContextOptions<AtosEntity8Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Remedio> Remedios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;initial Catalog=AtosEntity8;User ID=AtosEntity8;password=Atos_Entity_8;language=Portuguese;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Horarios__3213E83F1F19E638");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Horario1).HasColumnName("horario");
            entity.Property(e => e.NomePaciente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nomePaciente");
            entity.Property(e => e.NomeRemedio)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nomeRemedio");
            entity.Property(e => e.Tempo).HasColumnName("tempo");

            entity.HasOne(d => d.NomePacienteNavigation).WithMany(p => p.Horarios)
                .HasPrincipalKey(p => p.Nome)
                .HasForeignKey(d => d.NomePaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Horarios__nomePa__34C8D9D1");

            entity.HasOne(d => d.NomeRemedioNavigation).WithMany(p => p.Horarios)
                .HasPrincipalKey(p => p.Nome)
                .HasForeignKey(d => d.NomeRemedio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Horarios__nomeRe__33D4B598");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paciente__3213E83FEF7EADCE");

            entity.HasIndex(e => e.Nome, "UQ__Paciente__6F71C0DC20A74E99").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Remedio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Remedios__3213E83FF3A70405");

            entity.HasIndex(e => e.Nome, "UQ__Remedios__6F71C0DC1F89612F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
