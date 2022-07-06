using Gighub.Core.Models;

namespace Gighub.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollwing(string userId, string artistId);
    }
}