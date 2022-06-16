using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace PersonalCloud.Server.Models
{
    public partial class PersonalCloudDb : DbContext
    {

        public PersonalCloudDb(DbContextOptions<PersonalCloudDb> options)
            : base(options)
        {
        }

        public PersonalCloudDb()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                var connectStr = Startup.StaticConfiguration.GetConnectionString("WebApiDatabase");
                optionsBuilder.UseMySql(connectStr, ServerVersion.AutoDetect(connectStr));
            }
            
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserFile> UserFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8_general_cs");

            modelBuilder.Entity<UserFile>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PRIMARY");

                entity.Property(e => e.DateAdded).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.UserFiles)
                    .HasForeignKey(d => d.CreatorId)
                    .HasConstraintName("user_files_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
