using System.Data.Entity.ModelConfiguration;
using Gighub.Core.Models;

namespace Gighub.Persistence.EntityConfigurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);
        }

    }
}