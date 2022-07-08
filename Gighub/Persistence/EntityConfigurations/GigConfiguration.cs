using System.Data.Entity.ModelConfiguration;
using Gighub.Core.Models;

namespace Gighub.Persistence.EntityConfigurations
{
    public class GigConfiguration : EntityTypeConfiguration<Gig>
    {
        public GigConfiguration()
        {
            Property(g => g.ArtistId)
                .IsRequired();

            Property(g => g.GenreId)
                .IsRequired();

            Property(g => g.Venue)
                .IsRequired()
                .HasMaxLength(255);

            HasMany(g => g.Attendances) 
                .WithRequired(g => g.Gig)
                .WillCascadeOnDelete(false);

        }

    }
}