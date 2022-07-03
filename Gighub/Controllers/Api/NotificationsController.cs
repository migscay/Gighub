﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Gighub.Dtos;
using Gighub.Models;
using Microsoft.AspNet.Identity;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();

            //Unable to install AutoMapper because it's not compatible
            //with NETFramework,Version=v4.7.2
            return notifications.Select(n => new NotificationDto()
            {
                DateTime = n.DateTime,
                Gig = new GigDto()
                {
                    Artist = new UserDto()
                    {
                        Id = n.Gig.ArtistId,
                        Name = n.Gig.Artist.Name
                    },
                    DateTime = n.Gig.DateTime,
                    Id = n.Gig.Id,
                    IsCancelled = n.Gig.IsCancelled,
                    Venue = n.Gig.Venue
                },
                OriginalDateTime = n.OriginalDateTime,
                OriginalVenue = n.OriginalVenue,
                Type = n.Type
            });
        }

    }
}