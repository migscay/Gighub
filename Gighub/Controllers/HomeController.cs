using System;
using Gighub.Models;
using System.Data.Entity;
using System.Web.Mvc;
using System.Linq;
using Gighub.Repositories;
using Gighub.ViewModels;
using Microsoft.AspNet.Identity;

namespace Gighub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly GigRepository _gigRepository;
        private readonly AttendanceRepository _attendanceRepository;

        public HomeController()
        {
            _context = new ApplicationDbContext();
            _gigRepository = new GigRepository(_context);
            _attendanceRepository = new AttendanceRepository(_context);
        }

        public ActionResult Index(string query = null)
        {
            var upcomingGigs = _gigRepository.GetFutureGigs(query);

            var userId = User.Identity.GetUserId();
            var attendances = _attendanceRepository.GetFutureAttendances(userId)
                .ToLookup(a => a.GigId);

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs",
                SearchTerm = query,
                Attendances = attendances
            };

            return View("Gigs", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}