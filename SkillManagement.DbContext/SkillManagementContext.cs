using System.Collections.Generic;
using System.Reflection.Emit;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SkillManagement.Data.Models;

namespace SkillManagement.EF.Context
{
    public partial class SkillManagementContext : DbContext
    {
        public SkillManagementContext()
        {
        }

        public SkillManagementContext(DbContextOptions<SkillManagementContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Practices> Practices { get; set; } = null!;

        public virtual DbSet<Categories> Categories { get; set; } = null!;

        public virtual DbSet<TechnologyStack> TechnologyStack { get; set; } = null!;

        public virtual DbSet<ProficiencyLevel> ProficiencyLevel { get; set; } = null!;

        public virtual DbSet<SkillsMatrixResults> SkillsMatrixResults{ get; set; } = null!;

        public virtual DbSet<TechnologySkillsMatrix> TechnologySkillsMatrix { get; set; } = null!;

        //  public virtual DbSet<SkillsMatrixResults> SkillsMatrixResults { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-1NKM2FU;Initial Catalog=GeeksStore;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillsMatrixResults>(entity =>
            {
                entity.ToTable("SkillsMatrixResults");
        
                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.PracticeId);
                entity.Property(e => e.PracticesName);
                entity.Property(e => e.CategoryId);
                entity.Property(e => e.CategoryName);
                entity.Property(e => e.TechnologyId);
                entity.Property(e => e.TechnologyName);
                entity.Property(e => e.SelectedProficiencyLevel);
                entity.Property(e => e.Selected);
                entity.HasKey(e=> e.TechnologyId);
            });

            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<TechnologySkillsMatrix>(entity =>
            {
                entity.ToTable("TechnologySkillsMatrix");

           
                entity.Property(e => e.TechnologyId);
                entity.Property(e => e.EmployeeName);
                entity.Property(e => e.ProficiencyLevelId);
                entity.HasKey(e => e.Id);
            });

            OnModelCreatingPartial(modelBuilder);


        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}