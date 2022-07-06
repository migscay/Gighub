﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Gighub.Core.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; private set; }

        public string OriginalVenue { get; private set; }

        [Required]
        public Gig Gig { get; private set; }

        protected Notification()
        {
        }
        private Notification(Gig gig, NotificationType notificationType)
        {
            //now check for null
            if (gig == null)
                throw new ArgumentNullException("gig");

            DateTime = DateTime.Now;
            Gig = gig;
            Type = notificationType;
        }

        public static Notification GigCreated(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCreated);
        }

        public static Notification GigUpdated(Gig newGig, DateTime originalDateTime, string originalVenue)
        {
            var notification = new Notification(newGig, NotificationType.GigUpdated);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = originalVenue;
            
            return notification;
        }

        public static Notification GigCancelled(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCanceled);
        }
    }
}