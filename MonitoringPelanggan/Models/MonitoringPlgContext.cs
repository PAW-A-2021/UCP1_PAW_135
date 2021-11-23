using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MonitoringPelanggan.Models
{
    public partial class MonitoringPlgContext : DbContext
    {
        public MonitoringPlgContext()
        {
        }

        public MonitoringPlgContext(DbContextOptions<MonitoringPlgContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pemohonan> Pemohonans { get; set; }
        public virtual DbSet<Petuga> Petugas { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Pemohonan>(entity =>
            {
                entity.ToTable("Pemohonan");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Alamat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Kelayakan)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPenuh)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("No_Hp");

                entity.Property(e => e.NoKk).HasColumnName("NoKK");

                entity.Property(e => e.Proses)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPetugasNavigation)
                    .WithMany(p => p.Pemohonans)
                    .HasForeignKey(d => d.IdPetugas)
                    .HasConstraintName("FK_Pemohonan_Petugas");
            });

            modelBuilder.Entity<Petuga>(entity =>
            {
                entity.HasKey(e => e.IdPetugas);

                entity.Property(e => e.IdPetugas).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("NoHP");

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("NoHP");

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
