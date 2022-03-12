namespace API.Controllers
{
    public class AdminController: BaseApiController
    {
        [HttpGet("users-with-roles")]
        public ActionResult GetUsersWithRoles()
    }
}