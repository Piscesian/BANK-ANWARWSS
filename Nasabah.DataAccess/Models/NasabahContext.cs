using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Nasabah.DataAccess.Models
{
    public partial class NasabahContext : DbContext
    {
        public NasabahContext()
        {
        }

        public NasabahContext(DbContextOptions<NasabahContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MstDatum> MstData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-02S8TPOT;Database=Nasabah;user=velvet;password=123581321o;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MstDatum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NoHP");

                entity.Property(e => e.NoKtp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NoKTP");

                entity.Property(e => e.TanggalLahir).HasColumnType("datetime");

                entity.Property(e => e.TempatLahir)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
