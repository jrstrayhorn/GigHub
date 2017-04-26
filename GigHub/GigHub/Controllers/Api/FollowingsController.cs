using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Core.Persistence;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (userId == dto.ArtistId)
            {
                return BadRequest("You can't follow yourself.");
            }

            if (_unitOfWork.Followings.GetFollowing(userId, dto.ArtistId) != null)
            {
                return BadRequest("You've already followed this artist.");
            }

            var following = new Following
            {
                FollowerId = User.Identity.GetUserId(),
                ArtistId = dto.ArtistId
            };

            _unitOfWork.Followings.Add(following);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult UnFollow(string id)
        {
            var following = _unitOfWork
                .Followings
                .GetFollowing(User.Identity.GetUserId(), id);

            if (following == null)
                return NotFound();

            _unitOfWork.Followings.Remove(following);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
