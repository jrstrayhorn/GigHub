using GigHub.Core.Persistence;
using GigHub.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string query = null)
        {
            var upcomingGigs = (!String.IsNullOrWhiteSpace(query)) ?
                _unitOfWork.Gigs.GetUpcomingGigsBySearch(query) :
                _unitOfWork.Gigs.GetUpcomingGigs();

            string userId = User.Identity.GetUserId();
            var attendances = _unitOfWork.Attendances.GetFutureAttendances(userId)
                    .ToLookup(a => a.GigId);

            var viewModel = new GigsViewModel
            {
                Heading = "Upcoming Gigs",
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
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