using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class UsersController: UsersController
    {
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}