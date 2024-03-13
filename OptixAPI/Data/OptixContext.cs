using Microsoft.EntityFrameworkCore;

namespace OptixAPI.Data;

public partial class OptixContext : DbContext
{
    public OptixContext()
    {
    }

    public OptixContext(DbContextOptions<OptixContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mymoviedb> Mymoviedbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mymoviedb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_mymoviedb_ID");

            entity.ToTable("mymoviedb");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Genre).IsUnicode(false);
            entity.Property(e => e.OriginalLanguage)
                .IsUnicode(false)
                .HasColumnName("Original_Language");
            entity.Property(e => e.Overview).IsUnicode(false);
            entity.Property(e => e.PosterUrl)
                .IsUnicode(false)
                .HasColumnName("Poster_Url");
            entity.Property(e => e.ReleaseDate).HasColumnName("Release_Date");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.VoteAverage).HasColumnName("Vote_Average");
            entity.Property(e => e.VoteCount).HasColumnName("Vote_Count");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
