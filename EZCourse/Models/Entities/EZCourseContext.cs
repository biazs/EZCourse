using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EZCourse.Models.Entities
{
    public partial class EZCourseContext : DbContext
    {
        public EZCourseContext(DbContextOptions<EZCourseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCredential> UserCredential { get; set; }
        public virtual DbSet<UserPermission> UserPermission { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Time).HasColumnType("date");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.FirstName).HasColumnType("text");

                entity.Property(e => e.LastName).HasColumnType("text");
            });

            modelBuilder.Entity<UserCredential>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.HashedPassword).HasMaxLength(10);

                entity.Property(e => e.PasswordSalt).HasMaxLength(10);
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();
            });
        }
    }
}
