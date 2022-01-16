using Microsoft.AspNetCore.Mvc;
using API.Data;
using System.Collections.Generic;
using API.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class  UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

         [HttpGet]
         public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
         {
              var users = await _context.Name.ToListAsync();
              return users;
         }


        [HttpGet("{id}")]
         public async  ActionResult<AppUser> GetUser(int id)
         {
              var user = _context.Name.Find(id)  ;
              return user;
         }

    }
}