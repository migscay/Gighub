﻿using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using Gighub.Core;
using Gighub.Core.Models;
using Gighub.Persistence;

namespace GigHub.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FolloweesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var artists = _unitOfWork.Users.GetArtistsFollowedBy(userId);

            return View(artists);
        }
    }
}