using Common.Services;
using DataHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranController : ControllerBase
    {
        private readonly SrvcTran _srvc;

        public TranController(SrvcTran srvc)
        {
            _srvc = srvc;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransList()
        {
            var transList = await _srvc.GetTran();
            return Ok(transList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransById(string id)
        {
            var trans = await _srvc.GetTranId(id);
            return Ok(trans);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTran(BtTran data)
        {
            var trans = await _srvc.CreateTran(data);
            return Ok(trans);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateTran(BtTran data)
        {
            var trans = await _srvc.UpdateTran(data);
            return Ok(trans);
        }
    }
}
