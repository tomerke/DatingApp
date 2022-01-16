using Microsoft.AspNetCore.Mvc;
using API.Data;
using System.Collections.Generic

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : UsersController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

         [HttpGet]
         public ActionResult<IEnuremable<AppUser>> GetUsers()

    }
}