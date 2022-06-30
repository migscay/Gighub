using System.Collections.Generic;
using Gighub.Models;

namespace Gighub.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        //change from the default IQueryable to IEnumerable, reason we just to 
        //iterate over the list in the view, no need to extend

        public bool ShowActions { get; set; }
    }
}