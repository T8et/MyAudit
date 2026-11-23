using Common.Services;
using DataHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupDtlController : ControllerBase
    {
        private readonly AppDBContext _db;
        private readonly SrvcGrpDtl _srvc;

        public GroupDtlController(SrvcGrpDtl srvc, AppDBContext db)
        {
            _srvc = srvc;
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetGrpDtl()
        {
            var grpdtdtl = await _srvc.GetGrpDtl();
            return Ok(grpdtdtl);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGrpId(string id)
        {
            var grpdtdtl = await _srvc.GetGrpDtlId(id);
            return Ok(grpdtdtl);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGrpDetail(BtGrpDtl data)
        {
            var grpdtdtl = await _srvc.CreateGrpDtl(data);
            return Ok(grpdtdtl);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateGrpDetail(BtGrpDtl data)
        {
            var grpdtdtl = await _srvc.UpdateGrpDtl(data);
            return Ok(grpdtdtl);
        }

        [HttpDelete("{id}/{srl}")]
        public async Task<IActionResult> DeleteGrpDetail(string id, int srl)
        {
            var grpdtdtl = await _srvc.DelGrpDtl(id, srl);
            return Ok(grpdtdtl);
        }
    }
}
