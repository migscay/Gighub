﻿using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Web.Http;
using Gighub.Core;
using Gighub.Core.Models;
using Gighub.Persistence;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();

            var gig = _unitOfWork.Gigs.GetGigWithAttendees(id);

            if (gig.IsCanceled)
                return NotFound();

            gig.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}