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
            var lstuser = await _db.BtUsers.Where(u=>u.UserSts!="0").ToListAsync();
            return Ok(lstuser);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _db.BtUsers.Where(u => u.UserId == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(BtUser data)
        {
            if(data is not null)
            {
                var creaData = _db.BtUsers.AddAsync(data);
                await _db.SaveChangesAsync();
                return Ok(creaData);
            }
            return NotFound();
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateUser(BtUser data)
        {
            if(data is not null)
            {
                var upData = await _db.BtUsers.Where(u => u.UserId == data.UserId).FirstOrDefaultAsync();
                if (data.UserName != "") upData!.UserName = data.UserName;
                if (data.UserEmail != "") upData!.UserEmail = data.UserEmail;
                if (data.UserPass != "") upData!.UserPass = data.UserPass;
                upData!.UserLog = upData.UserId;
                upData!.TimeLog = DateTime.UtcNow;

                await _db.SaveChangesAsync();
                return Ok(upData);
            }
            return NotFound();
        }

        [HttpPatch("delete/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if(id is not null)
            {
                var delData = await _db.BtUsers.Where(u => u.UserId == id).FirstOrDefaultAsync();
                if(delData is not null)
                {
                    delData.UserSts = "0";
                    await _db.SaveChangesAsync();
                    return Ok(delData);
                }
            }
            return NotFound();
        }
    }
}
