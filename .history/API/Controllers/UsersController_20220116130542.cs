using Microsoft.AspNetCore.Mvc;
using API.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: UsersController
    {
        public UsersController(DataContext Context )
        {

        }

    }
}