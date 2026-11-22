using Common.Response;
using DataHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
    public class SrvcGrp
    {
        private readonly AppDBContext _db;
        private readonly RspGrp _rsp;

        public SrvcGrp(AppDBContext db, RspGrp rsp)
        {
            _db = db;
            _rsp = rsp;
        }

        public async Task<RspCommon<ResponseModel>> GetGrp()
        {
            var result = await _db.BtGrps.ToListAsync();
            if (result is not null)
            {
                return RspCommon<ResponseModel>.Success("200", "Groups retrieved successfully", new ResponseModel() { grplst = result });
            }
            return RspCommon<ResponseModel>.DataNotExist("401", "No groups found");
        }

        public async Task<RspCommon<BtGrp>> GetGrpId(string id)
        {
            var result = await _db.BtGrps.Where(g => g.GrpId == id).FirstOrDefaultAsync();
            if(result is not null)
            {
                return RspCommon<BtGrp>.Success("200", "Group Data retrieved successfully", result);
            }
            return RspCommon<BtGrp>.DataNotExist("401", "Selected group not found");
        }

        public async Task<RspCommon<BtGrp>> CreateGrp(BtGrp data)
        {
            if(data is not null)
            {
                await _db.BtGrps.AddAsync(data);
                await _db.SaveChangesAsync();
                return RspCommon<BtGrp>.Success("200", "Group Created Successfully", data);
            }
            return RspCommon<BtGrp>.DataNotExist("401", "Data not exists");
        }

        public async Task<RspCommon<BtGrp>> UpdateGrp(BtGrp data)
        {
            if(data is not null)
            {
                var existingData = await _db.BtGrps.Where(g => g.GrpId == data.GrpId).FirstOrDefaultAsync();
                if (existingData is not null)
                {
                    if(data.GrpName != null) existingData.GrpName = data.GrpName;
                    if(data.GrpSts != null) existingData.GrpSts = data.GrpSts;
                    if(data.UserLog != null) existingData.UserLog = data.UserLog;
                    if(data.TimeLog != null) existingData.TimeLog = data.TimeLog;
                    _db.BtGrps.Update(existingData);
                    await _db.SaveChangesAsync();
                    return RspCommon<BtGrp>.Success("200", "Group Updated Successfully", existingData);
                }
            }
            return RspCommon<BtGrp>.DataNotExist("401", "Selected group not found");
        }

        public async Task<RspCommon<BtGrp>> DelGrp(string id)
        {
            if(id is not null)
            {
                var chkData = await _db.BtGrps.Where(g => g.GrpId == id).FirstOrDefaultAsync();
                if(chkData is not null)
                {
                    //Business logic here
                    return RspCommon<BtGrp>.Success("200", "Group Deleted Successfully", chkData);
                }
                return RspCommon<BtGrp>.DataNotExist("401", "Group not exists");
            }
            return RspCommon<BtGrp>.DataNotExist("401", "Group not exists");
        }
    }
}
