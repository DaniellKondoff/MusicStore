using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStoreWeb.Data.Models;

namespace MusicStoreWeb.Data.ModelConfiguration
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder
                .HasIndex(a => a.Name)
                .IsUnique();

            builder
                .HasMany(a => a.Songs)
                .WithOne(s => s.Artist)
                .HasForeignKey(s => s.ArtistId);

            builder
                .HasMany(a => a.Albums)
                .WithOne(al => al.Artist)
                .HasForeignKey(al => al.ArtistId);
        }
    }
}
