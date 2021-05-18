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

        public virtual DbSet<Categories> TblCategories { get; set; }
        public virtual DbSet<Expenditure> TblExpenditures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("tblCategories");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryDescription).HasColumnType("text");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Expenditure>(entity =>
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
