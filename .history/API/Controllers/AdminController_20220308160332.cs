using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AdminController: BaseApiController
    {
        [Authorize(Policy = "RequireAdmin")]
        [HttpGet("users-with-roles")]
        public ActionResult GetUsersWithRoles()
        {
            return Ok("Only Admins can see this");
        }
    }
}