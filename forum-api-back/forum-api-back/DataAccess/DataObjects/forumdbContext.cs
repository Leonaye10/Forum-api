using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace forum_api_back.DataAccess.DataObjects
{
    public partial class forumdbContext : DbContext
    {
        public forumdbContext()
        {
        }

        public forumdbContext(DbContextOptions<forumdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=forum-db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Idcomment)
                    .HasName("PRIMARY");

                entity.ToTable("comment");

                entity.HasIndex(e => e.TopicId, "topicId_idx");

                entity.Property(e => e.Idcomment).HasColumnName("idcomment");

                entity.Property(e => e.Contenu)
                    .HasColumnType("mediumtext")
                    .HasColumnName("contenu");

                entity.Property(e => e.DateCreation).HasColumnName("dateCreation");

                entity.Property(e => e.DateModification).HasColumnName("dateModification");

                entity.Property(e => e.NomUtilisateur)
                    .HasMaxLength(155)
                    .HasColumnName("nomUtilisateur");

                entity.Property(e => e.TopicId).HasColumnName("topicId");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_topicId");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasKey(e => e.Idtopic)
                    .HasName("PRIMARY");

                entity.ToTable("topic");

                entity.Property(e => e.Idtopic).HasColumnName("idtopic");

                entity.Property(e => e.DateCreation).HasColumnName("dateCreation");

                entity.Property(e => e.DateModification).HasColumnName("dateModification");

                entity.Property(e => e.NomUtilisateur)
                    .HasMaxLength(155)
                    .HasColumnName("nomUtilisateur");

                entity.Property(e => e.Titre)
                    .HasMaxLength(155)
                    .HasColumnName("titre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
