using Microsoft.AspNetCore.Mvc;
using API.Data;
using System.Collections.Generic;
using API.Entities;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

         [HttpGet]
         public ActionResult<IEnumerable<AppUser>> GetUsersTomer()
         {
              var users = _context.Name.ToList();
              return users;
         }


        [HttpGet("{id}")]
         public ActionResult<AppUser> GetUser(int id)
         {
              var user = _context.Name.Find(id)  ;
              return user;
         }

    }
}