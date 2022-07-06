using Gighub.Models;

namespace Gighub.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollwing(string userId, string artistId);
    }
}