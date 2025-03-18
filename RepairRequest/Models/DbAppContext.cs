using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RepairRequest.Models
{
    public partial class DbAppContext : DbContext
    {
        public DbAppContext()
        {
        }

        public DbAppContext(DbContextOptions<DbAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ProblemType> ProblemTypes { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<SparePart> SpareParts { get; set; } = null!;
        public virtual DbSet<SparePartRequest> SparePartRequests { get; set; } = null!;
        public virtual DbSet<SparePartType> SparePartTypes { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=repair_request;Username=postgres;Password=918273645zx");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(100)
                    .HasColumnName("client_name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<ProblemType>(entity =>
            {
                entity.ToTable("problem_type");

                entity.Property(e => e.ProblemTypeId).HasColumnName("problem_type_id");

                entity.Property(e => e.ProblemTypeName)
                    .HasMaxLength(50)
                    .HasColumnName("problem_type_name");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("request");

                entity.Property(e => e.RequestId).HasColumnName("request_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.DateAdded).HasColumnName("date_added");

                entity.Property(e => e.DateClosed).HasColumnName("date_closed");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Equipment)
                    .HasMaxLength(100)
                    .HasColumnName("equipment");

                entity.Property(e => e.ProblemTypeId).HasColumnName("problem_type_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("request_client_id_fkey");

                entity.HasOne(d => d.ProblemType)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ProblemTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("request_problem_type_id_fkey");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("request_status_id_fkey");
            });

            modelBuilder.Entity<SparePart>(entity =>
            {
                entity.ToTable("spare_part");

                entity.Property(e => e.SparePartId).HasColumnName("spare_part_id");

                entity.Property(e => e.SparePartCost)
                    .HasPrecision(10, 2)
                    .HasColumnName("spare_part_cost");

                entity.Property(e => e.SparePartName)
                    .HasMaxLength(100)
                    .HasColumnName("spare_part_name");

                entity.Property(e => e.SparePartTypeId).HasColumnName("spare_part_type_id");

                entity.HasOne(d => d.SparePartType)
                    .WithMany(p => p.SpareParts)
                    .HasForeignKey(d => d.SparePartTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("spare_part_spare_part_type_id_fkey");
            });

            modelBuilder.Entity<SparePartRequest>(entity =>
            {
                entity.ToTable("spare_part_request");

                entity.Property(e => e.SparePartRequestId).HasColumnName("spare_part_request_id");

                entity.Property(e => e.Quantity)
                    .HasPrecision(10, 3)
                    .HasColumnName("quantity");

                entity.Property(e => e.RequestId).HasColumnName("request_id");

                entity.Property(e => e.SparePartId).HasColumnName("spare_part_id");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.SparePartRequests)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("spare_part_request_request_id_fkey");

                entity.HasOne(d => d.SparePart)
                    .WithMany(p => p.SparePartRequests)
                    .HasForeignKey(d => d.SparePartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("spare_part_request_spare_part_id_fkey");
            });

            modelBuilder.Entity<SparePartType>(entity =>
            {
                entity.ToTable("spare_part_type");

                entity.Property(e => e.SparePartTypeId).HasColumnName("spare_part_type_id");

                entity.Property(e => e.SparePartTypeName)
                    .HasMaxLength(50)
                    .HasColumnName("spare_part_type_name");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .HasColumnName("status_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
