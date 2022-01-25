using Microsoft.AspNetCore.Mvc;
using API.Data;
using System.Collections.Generic;
using API.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
   
    public class  UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

         [HttpGet]
         [AllowAnonymous]
         public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
         {
              var users = await _context.Name.ToListAsync();
              return users;
         }


        [Authorize]
        [HttpGet("{id}")]
         public async  Task<ActionResult<AppUser>> GetUser(int id)
         {
              var user = await _context.Name.FindAsync(id)  ;
              return user;
         }

    }
}