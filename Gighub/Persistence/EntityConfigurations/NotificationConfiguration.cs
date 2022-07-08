using System.Data.Entity.ModelConfiguration;
using Gighub.Core.Models;

namespace Gighub.Persistence.EntityConfigurations
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            HasRequired(n => n.Gig);
        }
    }
}