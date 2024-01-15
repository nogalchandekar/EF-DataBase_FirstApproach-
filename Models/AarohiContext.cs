using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataBaseFirstEFCore.Models
{
    public partial class AarohiContext : DbContext
    {
        public AarohiContext()
        {
        }

        public AarohiContext(DbContextOptions<AarohiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Registration1> Registration1s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration1>(entity =>
            {
                entity.ToTable("Registration1");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContactNumber).HasMaxLength(15);

                entity.Property(e => e.Dept).HasMaxLength(50);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .HasColumnName("EmailID");

                entity.Property(e => e.Fee).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Qualification).HasMaxLength(30);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
