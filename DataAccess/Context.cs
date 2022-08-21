using DataAccess.Entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Context : DbContext
    {
        public Context()
        {
        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }



        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ExamRoom> ExamRooms { get; set; }
        public virtual DbSet<HistoryRegisterTerm> HistoryRegisterTerms { get; set; }
        public virtual DbSet<ExamSubject> ExamSubjects { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Blog>(entity =>
            //{
            //    entity.ToTable("blogs");

            //    entity.Property(e => e.BlogId).HasColumnType("int(11)");
            //});

            //modelBuilder.Entity<Post>(entity =>
            //{
            //    entity.ToTable("posts");

            //    entity.HasIndex(e => e.BlogId)
            //        .HasName("FK_Post_Blog_BlogId_idx");

            //    entity.HasOne(d => d.Blog)
            //        .WithMany(p => p.Posts)
            //        .HasForeignKey(d => d.BlogId)
            //        .HasConstraintName("FK_Post_Blog_BlogId");
            //});
        }
    }
}
