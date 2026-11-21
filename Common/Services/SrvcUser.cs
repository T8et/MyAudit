using Common.Response;
using DataHub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<RspCommon<BtUser>> GetUser(string userId)
        {
            var user = await _db.BtUsers.Where(u => u.UserSts != "0" && u.UserId == userId).FirstOrDefaultAsync();
            if(user is not null)
            {
                return RspCommon<BtUser>.Success("200", "Data Retrieved Successfully", user);
            }
            return RspCommon<BtUser>.DataNotExist("401", "Data not exists");
        }

        public async Task<RspCommon<BtUser>> CreateUsr(BtUser data)
        {
            if(data is not null)
            {
                await _db.BtUsers.AddAsync(data);
                await _db.SaveChangesAsync();
                return RspCommon<BtUser>.Success("200", "New User Created Successfully", data);
            }
            return RspCommon<BtUser>.DataNotExist("401", "Data not exists");
        }

        public async Task<RspCommon<BtUser>> UpdateUser(BtUser data)
        {
            if(data is not null)
            {
                var upData = await _db.BtUsers.Where(u => u.UserId == data.UserId).FirstOrDefaultAsync();
                if(upData is not null)
                {
                    if (data.UserName != "") upData!.UserName = data.UserName;
                    if (data.UserEmail != "") upData!.UserEmail = data.UserEmail;
                    if (data.UserPass != "") upData!.UserPass = data.UserPass;
                    upData!.UserLog = upData.UserId;
                    upData!.TimeLog = DateTime.UtcNow;

                    await _db.SaveChangesAsync();
                    upData = await _db.BtUsers.Where(u => u.UserId == data.UserId).FirstOrDefaultAsync();
                    return RspCommon<BtUser>.Success("200", "Successfully Updated the record", upData);
                }      
            }
            return RspCommon<BtUser>.DataNotExist("401", "Data not exists");
        }

        public async Task<RspCommon<BtUser>> DeleteUser(string id)
        {
            if (id is not null)
            {
                var delData = await _db.BtUsers.Where(u => u.UserId == id).FirstOrDefaultAsync();
                if (delData is not null)
                {
                    delData.UserSts = "0";
                    await _db.SaveChangesAsync();
                    delData = await _db.BtUsers.Where(u => u.UserId == id).FirstOrDefaultAsync();
                    return RspCommon<BtUser>.Success("200", "Successfully Deleted the record", delData);
                }
            }
            return RspCommon<BtUser>.DataNotExist("401", "Data not exists");
        }
    }
}
