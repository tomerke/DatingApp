using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AdminController: BaseApiController
    {
        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("users-with-roles")]
        public ActionResult GetUsersWithRoles()
        {
            return Ok("Only Admins can see this");
        }


        [Authorize(Policy = "ModeratePhotos")]
        [HttpGet("photos-to-moderate")]
        public ActionResult GetUsersWithRoles()
        {
            return Ok("Only Admins can see this");
        }
    }
}