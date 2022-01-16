using Microsoft.AspNetCore.Mvc;
using API.Data;
using System.Collections.Generic;
using API.Entities;
using System.Linq;

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
         {
              var users = _context.Name.ToList();
              return users;
         }


        [HttpGet]
         public ActionResult<IEnuremable<AppUser>> GetUser()
         {
              var users = _context.Name.ToList();
              return users;
         }

    }
}