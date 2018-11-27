using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyApplicaition.Models
{
    public partial class santoshContext : DbContext
    {
        public santoshContext()
        {
        }

        public santoshContext(DbContextOptions<santoshContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-VCURL36\\SANTOSHSQL;Database=santosh;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.EId);

                entity.ToTable("emp");

                entity.Property(e => e.EId).HasColumnName("e_id");

                entity.Property(e => e.EAge).HasColumnName("e_Age");

                entity.Property(e => e.ECreatedby)
                    .HasColumnName("e_createdby")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ECreatedts)
                    .HasColumnName("e_createdts")
                    .HasColumnType("date");

                entity.Property(e => e.EDateofjoining)
                    .HasColumnName("e_dateofjoining")
                    .HasColumnType("date");

                entity.Property(e => e.EEmailid)
                    .HasColumnName("e_emailid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ELastupdatedby)
                    .HasColumnName("e_lastupdatedby")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ELastupdatedts)
                    .HasColumnName("e_lastupdatedts")
                    .HasColumnType("date");

                entity.Property(e => e.EName)
                    .HasColumnName("e_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EPassword)
                    .HasColumnName("e_password")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ESalary).HasColumnName("e_Salary");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.Tid);

                entity.ToTable("tasks");

                entity.Property(e => e.Tid).HasColumnName("tid");

                entity.Property(e => e.Createdts)
                    .HasColumnName("createdts")
                    .HasColumnType("datetime");

                entity.Property(e => e.Eid).HasColumnName("eid");

                entity.Property(e => e.Lastupdatedby)
                    .HasColumnName("lastupdatedby")
                    .HasMaxLength(10);

                entity.Property(e => e.Tname)
                    .HasColumnName("tname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.E)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.Eid)
                    .HasConstraintName("FK_tasks_emp");
            });
        }
    }
}
