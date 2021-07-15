using System;
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

        public SpendMonitorContext(DbContextOptions<SpendMonitorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccount> TblAccounts { get; set; }
        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblExpenditure> TblExpenditures { get; set; }
        public virtual DbSet<TblExpenditureCopy> TblExpenditureCopies { get; set; }
        public virtual DbSet<TblIncome> TblIncomes { get; set; }
        public virtual DbSet<TblSubcategory> TblSubcategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=HP-SYED-YAWAR\\SQLEXPRESS;Database=SpendMonitor;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("tblAccount");

                entity.Property(e => e.AccountBalance).HasColumnType("money");

                entity.Property(e => e.AccountBankName)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_tblCategory");

                entity.ToTable("tblCategories");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryDescription).HasColumnType("text");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblExpenditure>(entity =>
            {
                entity.HasKey(e => e.Expid);

                entity.ToTable("tblExpenditure");

                entity.Property(e => e.ExpAmount).HasColumnType("money");

                entity.Property(e => e.ExpDate).HasColumnType("date");

                entity.Property(e => e.ExpShop)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.ExpAccountNavigation)
                    .WithMany(p => p.TblExpenditures)
                    .HasForeignKey(d => d.ExpAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblExpenditure_tblAccount");

                entity.HasOne(d => d.ExpCategoryNavigation)
                    .WithMany(p => p.TblExpenditures)
                    .HasForeignKey(d => d.ExpCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblExpenditure_tblCategories");

                entity.HasOne(d => d.ExpSubcategoryNavigation)
                    .WithMany(p => p.TblExpenditures)
                    .HasForeignKey(d => d.ExpSubcategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblExpenditure_tblSubcategories");
            });

            modelBuilder.Entity<TblExpenditureCopy>(entity =>
            {
                entity.HasKey(e => e.Expid);

                entity.ToTable("tblExpenditureCOPY");

                entity.Property(e => e.ExpAmount).HasColumnType("money");

                entity.Property(e => e.ExpDate).HasColumnType("date");

                entity.Property(e => e.ExpShop).HasColumnType("text");
            });

            modelBuilder.Entity<TblIncome>(entity =>
            {
                entity.HasKey(e => e.IncomeId);

                entity.ToTable("tblIncome");

                entity.Property(e => e.IncomeAmount).HasColumnType("money");

                entity.Property(e => e.IncomeDate).HasColumnType("date");

                entity.Property(e => e.IncomeSource).HasColumnType("text");

                entity.HasOne(d => d.IncomeAccountNavigation)
                    .WithMany(p => p.TblIncomes)
                    .HasForeignKey(d => d.IncomeAccount)
                    .HasConstraintName("FK_tblIncome_tblAccount");

                entity.HasOne(d => d.IncomeCategoryNavigation)
                    .WithMany(p => p.TblIncomes)
                    .HasForeignKey(d => d.IncomeCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIncome_tblCategories");
            });

            modelBuilder.Entity<TblSubcategory>(entity =>
            {
                entity.HasKey(e => e.SubCategoryId);

                entity.ToTable("tblSubcategories");

                entity.Property(e => e.SubCategoryDescription).HasColumnType("text");

                entity.Property(e => e.SubCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.SubCategoryParentCategoryNavigation)
                    .WithMany(p => p.TblSubcategories)
                    .HasForeignKey(d => d.SubCategoryParentCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSubcategories_tblCategories");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
