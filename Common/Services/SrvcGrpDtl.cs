using Common.Response;
using DataHub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
    public class SrvcGrpDtl
    {
        private readonly AppDBContext _db;
        private readonly RspGrpDtl _rsp;

        public SrvcGrpDtl(AppDBContext db, RspGrpDtl rsp)
        {
            _db = db;
            _rsp = rsp;
        }

        public async Task<RspCommon<ResponseModel>> GetGrpDtl()
        {
            var result = await _db.BtGrpDtls.ToListAsync();
            if (result is not null)
            {
                return RspCommon<ResponseModel>.Success("200", "Group Details retrieved successfully", new ResponseModel() { grpdtdtl = result });
            }
            return RspCommon<ResponseModel>.DataNotExist("401", "No group details found");
        }

        public async Task<RspCommon<BtGrpDtl>> GetGrpDtlId(string id)
        {
            var result = await _db.BtGrpDtls.Where(g => g.GrpId == id).FirstOrDefaultAsync();
            if(result is not null)
            {
                return RspCommon<BtGrpDtl>.Success("200", "Group Detail Record retrieved successfully", result);
            }
            return RspCommon<BtGrpDtl>.DataNotExist("401", "Group Detail Record not exits");
        }

        public async Task<RspCommon<BtGrpDtl>> CreateGrpDtl(BtGrpDtl data)
        {
            if (data is not null)
            {
                await _db.BtGrpDtls.AddAsync(data);
                await _db.SaveChangesAsync();
                return RspCommon<BtGrpDtl>.Success("200", "Group Detail Record Created Successfully", data);
            }
            return RspCommon<BtGrpDtl>.DataNotExist("401", "Data not exists");
        }

        public async Task<RspCommon<BtGrpDtl>> UpdateGrpDtl(BtGrpDtl data)
        {
            if (data is not null)
            {
                var existingData = await _db.BtGrpDtls.Where(g => g.GrpId == data.GrpId && g.GrlSrl == data.GrlSrl).FirstOrDefaultAsync();
                if (existingData is not null)
                {
                    if (data.GrpId != null) existingData.GrpId = data.GrpId;
                    await _db.SaveChangesAsync();
                    return RspCommon<BtGrpDtl>.Success("200", "Group Detail Record Updated Successfully", existingData);
                }
                return RspCommon<BtGrpDtl>.DataNotExist("401", "Selected group detail record not found");
            }
            return RspCommon<BtGrpDtl>.DataNotExist("401", "Data not exists");
        }

        public async Task<RspCommon<BtGrpDtl>> DelGrpDtl(string id, int srl)
        {
            var existingData = await _db.BtGrpDtls.Where(g => g.GrpId == id && g.GrlSrl == srl).FirstOrDefaultAsync();
            if (existingData is not null)
            {
                _db.BtGrpDtls.Remove(existingData);
                await _db.SaveChangesAsync();
                return RspCommon<BtGrpDtl>.Success("200", "Group Detail Record Deleted Successfully", existingData);
            }
            return RspCommon<BtGrpDtl>.DataNotExist("401", "Selected group detail record not found");
        }
    }
}
 