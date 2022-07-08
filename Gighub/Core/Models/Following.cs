using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gighub.Core.Models
{
    public class Following
    {
        public string FollowerId { get; set; }

        public string FolloweeId { get; set; }

        public ApplicationUser Follower { get; set; }

        public ApplicationUser Followee { get; set; }


    }
}