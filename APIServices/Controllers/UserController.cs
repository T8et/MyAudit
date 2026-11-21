using Common.Services;
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

        private readonly SrvcUser _srvc;

        public UserController(AppDBContext db, SrvcUser srvc)
        {
            _db = db;
            _srvc = srvc;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var lstuser = await _srvc.UserList();
            return Ok(lstuser);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _srvc.GetUser(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(BtUser data)
        {
            var creaData = await _srvc.CreateUsr(data);
            return Ok(creaData);
        } 

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateUser(BtUser data)
        {
            var upData = await _srvc.UpdateUser(data);
            return Ok(upData);
        }

        [HttpPatch("delete/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var delData = await _srvc.DeleteUser(id);
            return Ok(delData);
        }
    }
}
