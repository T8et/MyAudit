using Common.Response;
using DataHub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
    public class SrvcTran
    {
        private readonly AppDBContext _db;

        private readonly RspTran _rsp;

        public SrvcTran(AppDBContext db, RspTran rsp)
        {
            _db = db;
            _rsp = rsp;
        }

        public async Task<RspCommon<ResponseModel>> GetTran()
        {
            var result = await _db.BtTrans.ToListAsync();
            if (result is not null)
            {
                return RspCommon<ResponseModel>.Success("200", "Transactions retrieved successfully", new ResponseModel() { tranlst = result });
            }
            return RspCommon<ResponseModel>.DataNotExist("401", "No transactions found");
        }

        public async Task<RspCommon<BtTran>> GetTranId(string id)
        {
            var result = await _db.BtTrans.Where(t => t.TranId == id).FirstOrDefaultAsync();
            if (result is not null)
            {
                return RspCommon<BtTran>.Success("200", "Transaction Data retrieved successfully", result);
            }
            return RspCommon<BtTran>.DataNotExist("401", "Selected transaction not found");
        }

        public async Task<RspCommon<BtTran>> CreateTran(BtTran data)
        {
            if (data is not null)
            {
                await _db.BtTrans.AddAsync(data);
                await _db.SaveChangesAsync();
                return RspCommon<BtTran>.Success("200", "Transaction Created Successfully", data);
            }
            return RspCommon<BtTran>.DataNotExist("401", "Data not exists");
        }

        public async Task<RspCommon<BtTran>> UpdateTran(BtTran data)
        {
            if (data is not null)
            {
                var existingData = await _db.BtTrans.Where(t => t.TranId == data.TranId).FirstOrDefaultAsync();
                if (existingData is not null)
                {
                    if (data.ItemDesc != null) existingData.ItemDesc = data.ItemDesc;
                    if (data.ItemCost != null) existingData.ItemCost = data.ItemCost;
                    existingData.TimeLog = DateTime.Now;
                    existingData.SysLog = data.UserLog;
                    existingData.UserLog = data.UserLog;
                    await _db.SaveChangesAsync();
                    return RspCommon<BtTran>.Success("200", "Transaction Updated Successfully", existingData);
                }
                return RspCommon<BtTran>.DataNotExist("401", "Selected transaction not found");
            }
            return RspCommon<BtTran>.DataNotExist("401", "Data not exists");
        }
    }
}
