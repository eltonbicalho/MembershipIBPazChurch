using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Membership.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Membership.Data
{
    public partial class MembresiaContext : DbContext
    {
        public MembresiaContext()
        {
        }

        public MembresiaContext(DbContextOptions<MembresiaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Igrejas> Igrejas { get; set; }
        public virtual DbSet<PreMembros> PreMembros { get; set; }
        public virtual DbSet<Subscribers> Subscribers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=Membresia;Persist Security Info=True;User ID=sa;Password=!QAZ2wsx;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Igrejas>(entity =>
            {
                entity.HasKey(e => e.IdIgreja)
                    .HasName("PK__Igrejas__DCB11E0892056D8E");

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<PreMembros>(entity =>
            {
                entity.HasKey(e => e.IdPreMembro)
                    .HasName("PK__PreMembr__2EF8C84636DA5CAD");

                entity.Property(e => e.DataUpdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Observacoes).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Telefone).IsUnicode(false);

                entity.HasOne(d => d.IdIgrejaNavigation)
                    .WithMany(p => p.PreMembros)
                    .HasForeignKey(d => d.IdIgreja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PreMembro__IdIgr__2A4B4B5E");
            });

            modelBuilder.Entity<Subscribers>(entity =>
            {
                entity.HasKey(e => e.IdSubscriber)
                    .HasName("PK__Subscrib__B0B5A88E4784281C");

                entity.Property(e => e.DataUpdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Telefone).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
