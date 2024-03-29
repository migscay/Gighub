﻿using System.Web.Http;
using Gighub.Core;
using Gighub.Core.Dtos;
using Gighub.Core.Models;
using Gighub.Persistence;
using Microsoft.AspNet.Identity;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            var following = _unitOfWork.Followings.GetFollowing(userId, dto.FolloweeId);
            if (following != null)
                return BadRequest("Following already exists.");

            following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId

            };

            _unitOfWork.Followings.Add(following);
            _unitOfWork.Complete();
            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult Unfollow(string id)
        {
            var userId = User.Identity.GetUserId();
            
            var following = _unitOfWork.Followings.GetFollowing(userId, id);

            if (following == null)
                return NotFound();

            _unitOfWork.Followings.Remove(following);
            _unitOfWork.Complete();

            return Ok(id);
        }

    }

}