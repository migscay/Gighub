using System.Linq;
using System.Web.Http;
using Gighub.Dtos;
using Gighub.Models;
using Microsoft.AspNet.Identity;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        //public IHttpActionResult Follow([FromBody]string followeeId)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == dto.FolloweeId))
            //if (_context.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == followeeId))
                return BadRequest("Already following Artist.");

            var following = new Following
            {
                FollowerId = userId,
                //FolloweeId = followeeId
                FolloweeId = dto.FolloweeId,
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();

        }
    }

}