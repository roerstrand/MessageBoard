using MessageBoard.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.DLL.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure Identity's ApplicationUser maps to the AspNetUsers table
            // but exclude it from migrations here if another context manages identity migrations.
           
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "AspNetUsers", t => t.ExcludeFromMigrations());
            });

            // Configure relationship between Message and ApplicationUser
            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.UserId);

            // Add an index on UserId to speed up queries that filter by user
            modelBuilder.Entity<Message>()
                .HasIndex(m => m.UserId);
        }

    }
}

