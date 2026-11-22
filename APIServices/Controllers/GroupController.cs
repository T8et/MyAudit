using Common.Services;
using DataHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace APIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly AppDBContext _db;
        private readonly SrvcGrp _srvc;
        public GroupController(AppDBContext db, SrvcGrp srvc)
        {
            _db = db;
            _srvc = srvc;
        }

        [HttpGet]
        public async Task<IActionResult> GetGrpList()
        {
            var grplist = await _srvc.GetGrp();
            return Ok(grplist);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(string id)
        {
            var grpdata = await _srvc.GetGrpId(id);
            return Ok(grpdata);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(BtGrp data)
        {
            var grpdata = await _srvc.CreateGrp(data);
            return Ok(grpdata);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateGrp(BtGrp data)
        {
            var grpdata = await _srvc.UpdateGrp(data);
            return Ok(grpdata);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelGrp(string id)
        {
            var deldata = await _srvc.DelGrp(id);
            return Ok(deldata);
        }
    }
}
