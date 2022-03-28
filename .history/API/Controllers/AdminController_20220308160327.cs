using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AdminController: BaseApiController
    {
        [Authorize(Policy = "Required")]
        [HttpGet("users-with-roles")]
        public ActionResult GetUsersWithRoles()
        {
            return Ok("Only Admins can see this");
        }
    }
}