using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ZettelkastenWebApplication;

public partial class DbzettelkastenContext : DbContext
{
    public DbzettelkastenContext()
    {
    }

    public DbzettelkastenContext(DbContextOptions<DbzettelkastenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Source> Sources { get; set; }

    public virtual DbSet<SourcesAuthor> SourcesAuthors { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= DESKTOP-134RQU4\\SQLEXPRESS; Database=DBZettelkasten; Trusted_Connection=True; Trust Server Certificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.AuthorId).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.AuthorNavigation).WithOne(p => p.Author)
                .HasForeignKey<Author>(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Authors_Sources1");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.Property(e => e.NoteId).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Text).HasColumnType("ntext");

            entity.HasOne(d => d.NoteNavigation).WithOne(p => p.Note)
                .HasForeignKey<Note>(d => d.NoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notes_Sources");
        });

        modelBuilder.Entity<Source>(entity =>
        {
            entity.Property(e => e.SourceId).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.SourceNavigation).WithOne(p => p.Source)
                .HasForeignKey<Source>(d => d.SourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sources_SourcesAuthors");

            entity.HasOne(d => d.Source1).WithOne(p => p.Source)
                .HasForeignKey<Source>(d => d.SourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sources_Types");
        });

        modelBuilder.Entity<SourcesAuthor>(entity =>
        {
            entity.HasKey(e => e.SourceAuthorId);

            entity.Property(e => e.SourceAuthorId).ValueGeneratedOnAdd();
            entity.Property(e => e.Info).HasColumnType("ntext");

            entity.HasOne(d => d.SourceAuthor).WithOne(p => p.SourcesAuthor)
                .HasForeignKey<SourcesAuthor>(d => d.SourceAuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SourcesAuthors_Authors");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.Property(e => e.TagId).ValueGeneratedOnAdd();
            entity.Property(e => e.Text).HasColumnType("ntext");

            entity.HasOne(d => d.TagNavigation).WithOne(p => p.Tag)
                .HasForeignKey<Tag>(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tags_Notes");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.Property(e => e.Articles).HasColumnType("ntext");
            entity.Property(e => e.Books).HasColumnType("ntext");
            entity.Property(e => e.Infographics).HasColumnType("ntext");
            entity.Property(e => e.Magazines).HasColumnType("ntext");
            entity.Property(e => e.Textbooks).HasColumnType("ntext");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
