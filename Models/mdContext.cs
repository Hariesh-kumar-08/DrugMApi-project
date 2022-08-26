using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DrugMApi.Models
{
    public partial class mdContext : DbContext
    {
        public mdContext()
        {
        }

        public mdContext(DbContextOptions<mdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Buyer> Buyers { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderDetail1> OrderDetails1 { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=md;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admins");

                entity.Property(e => e.AdminName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AdminPassword)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasKey(e => e.PurchaseId)
                    .HasName("PK__Buyers__6B0A6BBECADE966B");

                entity.Property(e => e.DateofPurchase).HasColumnType("datetime");

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Buyers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Buyers__UserId__3E52440B");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderDet__C3905BCFD1724A89");

                entity.ToTable("OrderDetail");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderDeta__Produ__4316F928");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.PurchaseId)
                    .HasConstraintName("FK__OrderDeta__Purch__44FF419A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__OrderDeta__UserI__440B1D61");
            });

            modelBuilder.Entity<OrderDetail1>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderDet__C3905BCF5754AA1D");

                entity.ToTable("OrderDetails");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetail1s)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderDeta__Produ__286302EC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderDetail1s)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__OrderDeta__UserI__29572725");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ExpDate)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MfdDate)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Loc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("loc");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
