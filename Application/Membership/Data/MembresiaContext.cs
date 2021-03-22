using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Membership.Models;

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
        public virtual DbSet<Persons> Persons { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:eltonbicalho.database.windows.net,1433;Initial Catalog=Membresia;Persist Security Info=False;User ID=elton;Password=!QAZ2wsx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
        */
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

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("PK__Persons__A5D4E15B62C4BA3F");
                entity.Property(e => e.FirstName).IsUnicode(false);
                entity.Property(e => e.LastName).IsUnicode(false);
                entity.Property(e => e.Email).IsUnicode(false);
                entity.Property(e => e.CellPhone).IsUnicode(false);
                entity.Property(e => e.Gender).IsUnicode(false);
                entity.Property(e => e.AspNetUserID).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
