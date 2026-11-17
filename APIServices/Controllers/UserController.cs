using DataHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace APIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDBContext _db;
        public UserController(AppDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var lstuser = await _db.BtUsers.ToListAsync();
            return Ok(lstuser);
        }
    }
}
