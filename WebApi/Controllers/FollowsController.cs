using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowersController : ControllerBase
    {
        IFollowerService _followerService;
        public FollowersController(IFollowerService followerService) 
        {
            _followerService = followerService;
        }

        [HttpPost("Add")]
        public IActionResult Post(Follower follower)
        {
            var result = _followerService.Add(follower);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Follower follower)
        {
            var result = _followerService.Delete(follower);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
