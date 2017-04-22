using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (userId == dto.ArtistId)
            {
                return BadRequest("You can't follow yourself.");
            }

            if (_context.Followings.Any(f => f.FollowerId == userId && f.ArtistId == dto.ArtistId))
            {
                return BadRequest("You've already followed this artist.");
            }

            var following = new Following
            {
                FollowerId = User.Identity.GetUserId(),
                ArtistId = dto.ArtistId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
