using System.Collections.Generic;
using System.Linq;
using Gighub.Core.Models;
using Gighub.Core.Repositories;

namespace Gighub.Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IApplicationDbContext _context;

        public GenreRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}