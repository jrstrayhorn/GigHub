using GigHub.Core.Persistence;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    [Authorize]
    public class FolloweesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FolloweesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Followees
        public ActionResult Index()
        {
            var followees = _unitOfWork
                .Followings
                .GetFollowingsByFollowerId(
                User.Identity.GetUserId()
                );

            return View(followees);
        }
    }
}