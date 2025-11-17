using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentManagement_MVC.Models.StuddentManagement_database;

namespace StudentManagement_MVC.Data;

public partial class StudenManagementContext : DbContext
{
    public StudenManagementContext()
    {
    }

    public StudenManagementContext(DbContextOptions<StudenManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacherlog> Teacherlogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-G1I4OFP\\SQLEXPRESS;Initial Catalog=StudentManagerment;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_IDscore");

            entity.ToTable("Score", tb => tb.HasTrigger("UT_CalScoreEach"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvgScore).HasColumnName("avgScore");
            entity.Property(e => e.Score15).HasColumnName("score15");
            entity.Property(e => e.Score60).HasColumnName("score60");
            entity.Property(e => e.StuId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("stuID");
            entity.Property(e => e.Stuname)
                .HasMaxLength(50)
                .HasColumnName("stuname");
            entity.Property(e => e.SubId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("subID");

            entity.HasOne(d => d.Stu).WithMany(p => p.Scores)
                .HasForeignKey(d => d.StuId)
                .HasConstraintName("FK_stuID");

            entity.HasOne(d => d.Sub).WithMany(p => p.Scores)
                .HasForeignKey(d => d.SubId)
                .HasConstraintName("FK_subID_Score");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StuId).HasName("PK_stuID");

            entity.ToTable("student", tb => tb.HasTrigger("UT_insertStudentName_and_StuID"));

            entity.Property(e => e.StuId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("stuID");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasColumnName("address");
            entity.Property(e => e.Class)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("class");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("fullname");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.ParentPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sex");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubId).HasName("PK_subID_subject");

            entity.ToTable("subject");

            entity.Property(e => e.SubId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("subID");
            entity.Property(e => e.Subname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("subname");
        });

        modelBuilder.Entity<Teacherlog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_teacherID");

            entity.ToTable("teacherlog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Pass)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pass");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.Uname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("uname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
