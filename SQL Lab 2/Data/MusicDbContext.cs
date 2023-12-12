using Microsoft.EntityFrameworkCore;
using System.Text;

namespace SQL_Lab_2.Data;

public partial class MusicDbContext : DbContext
{
    public MusicDbContext()
    {
    }

    public MusicDbContext(DbContextOptions<MusicDbContext> options)
        : base(options)
    {
    }

    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MediaType> MediaTypes { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    /*public DbSet<PlaylistTrack> PlaylistTracks { get; set; }*/
    public DbSet<Track> Tracks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AlexanderEveryloop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.AlbumId);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(160);
            entity.HasOne(e => e.Artist).WithMany().HasForeignKey(e => e.ArtistId);
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.ArtistId);
            entity.Property(e => e.Name);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId);
            entity.Property(e => e.Name);
        });

        modelBuilder.Entity<MediaType>(entity =>
        {
            entity.HasKey(e => e.MediaTypeId);
            entity.Property(e => e.Name);
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.PlaylistId);
            entity.Property(e => e.Name);
            entity.HasMany(e => e.Tracks).WithMany();
        });

        /*modelBuilder.Entity<PlaylistTrack>(entity =>
        {
            entity.HasKey(e => new { e.PlaylistId, e.TrackId });
            entity.HasOne(p => p.Playlist).WithMany(pt => pt.PlaylistTracks).HasForeignKey(p => p.PlaylistId);
            entity.HasOne(p => p.Track).WithMany().HasForeignKey(p => p.TrackId);
        });*/

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.TrackID);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.UnitPrice).IsRequired();
            entity.HasOne(e => e.Album).WithMany().HasForeignKey(e => e.AlbumId);
            entity.HasOne(e => e.MediaType).WithMany().HasForeignKey(e => e.MediaTypeId);
            entity.HasOne(e => e.Genre).WithMany().HasForeignKey(e => e.GenreId);
        });
    }
}
    