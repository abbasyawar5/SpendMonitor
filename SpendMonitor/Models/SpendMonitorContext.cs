﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SpendMonitor.Models
{
    public partial class SpendMonitorContext : DbContext
    {
        public SpendMonitorContext()
        {
        }


        //The constructor below  will allow configuration to be passed into the context by dependency injection.
        public SpendMonitorContext(DbContextOptions<SpendMonitorContext> options)
            : base(options)
        {
        }

        // Commenting out below as connection string has been added to appsettings.json file
        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Server=HP-SYED-YAWAR\\SQLEXPRESS;Database=SpendMonitor;Trusted_Connection=True;");
        //            }
        //        }


        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblExpenditure> TblExpenditures { get; set; }
        public virtual DbSet<TblIncome> TblIncomes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_tblCategory");

                entity.ToTable("tblCategories");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryDescription).HasColumnType("text");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblExpenditure>(entity =>
            {
                entity.HasKey(e => e.Expid);

                entity.ToTable("tblExpenditure");

                entity.Property(e => e.Expid).ValueGeneratedNever();

                entity.Property(e => e.ExpAmount).HasColumnType("money");

                entity.Property(e => e.ExpDate).HasColumnType("date");

                entity.Property(e => e.ExpShop).HasColumnType("text");

                entity.HasOne(d => d.ExpCategoryNavigation)
                    .WithMany(p => p.TblExpenditures)
                    .HasForeignKey(d => d.ExpCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblExpenditure_tblCategories");
            });

            modelBuilder.Entity<TblIncome>(entity =>
            {
                entity.HasKey(e => e.IncomeId);

                entity.ToTable("tblIncome");

                entity.Property(e => e.IncomeId).ValueGeneratedNever();

                entity.Property(e => e.ExpSource).HasColumnType("text");

                entity.Property(e => e.IncomeAmount).HasColumnType("money");

                entity.Property(e => e.IncomeDate).HasColumnType("date");

                entity.HasOne(d => d.IncomeCategoryNavigation)
                    .WithMany(p => p.TblIncomes)
                    .HasForeignKey(d => d.IncomeCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIncome_tblCategories");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
