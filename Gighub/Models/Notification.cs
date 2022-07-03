using System;
using System.ComponentModel.DataAnnotations;

namespace Gighub.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; set; }

        public string OriginalVenue { get; set; }

        [Required]
        public Gig Gig { get; private set; }

        protected Notification()
        {
        }
        public Notification(Gig gig, NotificationType notificationType)
        {
            //now check for null
            if (gig == null)
                throw new ArgumentNullException("gig");

            DateTime = DateTime.Now;
            Gig = gig;
            Type = notificationType;
        }
    }
}