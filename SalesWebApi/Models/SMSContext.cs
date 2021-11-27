using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalesWebApi.Models
{
    public partial class SMSContext : DbContext
    {
        public SMSContext()
        {
        }

        public SMSContext(DbContextOptions<SMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeRegistration> EmployeeRegistration { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<VisitTable> VisitTable { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=MOHAMMEDANEES\\SQLEXPRESS; Initial Catalog=SMS; Integrated security=True");
            }
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRegistration>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__1299A861A8FB8F0F");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.L)
                    .WithMany(p => p.EmployeeRegistration)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK__EmployeeRe__l_id__38996AB5");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Login__A7C7B6F81CE5641E");

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VisitTable>(entity =>
            {
                entity.HasKey(e => e.VisitId)
                    .HasName("PK__VisitTab__375A75E1FDF9F02A");

                entity.Property(e => e.VisitId).HasColumnName("visit_id");

                entity.Property(e => e.ContactNo).HasColumnName("contact_no");

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("contact_person")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasColumnName("cust_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.InterestProduct)
                    .HasColumnName("interest_product")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.IsDisabled).HasColumnName("is_disabled");

                entity.Property(e => e.VisitDatetime)
                    .HasColumnName("visit_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisitSubject)
                    .HasColumnName("visit_subject")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.VisitTable)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__VisitTabl__emp_i__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
