using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    [Authorize]
    public class FolloweesController : Controller
    {
        private ApplicationDbContext _context;

        public FolloweesController()
        {
            _context = ApplicationDbContext.Create();
        }

        // GET: Followees
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var followees = _context.Followings
                .Where(f => f.FollowerId == userId)
                .Include(f => f.Artist)
                .ToList();

            return View(followees);
        }
    }
}