﻿using System.Collections.Generic;
using Gighub.Core.Models;

namespace Gighub.Core.Repositories
{
    public interface IGigRepository
    {
        Gig GetGig(int gigId);
        IEnumerable<Gig> GetUpcomingGigsByArtist(string artistId);
        IEnumerable<Gig> GetUpcomingGigs(string query = null);
        Gig GetGigWithAttendees(int gigId);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        void Add(Gig gig);
    }
}