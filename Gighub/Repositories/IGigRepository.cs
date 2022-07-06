using System.Collections.Generic;
using Gighub.Models;

namespace Gighub.Repositories
{
    public interface IGigRepository
    {
        Gig GetGig(int gigId);
        IEnumerable<Gig> GetGigsByArtist(string artistId);
        IEnumerable<Gig> GetFutureGigs(string query = null);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        void Add(Gig gig);
    }
}