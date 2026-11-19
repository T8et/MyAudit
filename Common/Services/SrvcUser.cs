using Common.Response;
using DataHub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
    public class SrvcUser
    {
        private readonly AppDBContext _db;
        private readonly RspUser _rsp;
        public SrvcUser(AppDBContext db, RspUser rsp)
        {
            _db = db;
            _rsp = rsp;
        }

        public async Task<RspCommon<ResponseModel>> UserList()
        {
            var lstuser = await _db.BtUsers.Where(u => u.UserSts != "0").ToListAsync();
            if(lstuser is not null)
            {
                return RspCommon<ResponseModel>.Success("200", "Data Retrieved Successfully", new ResponseModel(){ usrlst = lstuser });
            }
            return RspCommon<ResponseModel>.DataNotExist("401", "Data not exists");
        }
    }
}
