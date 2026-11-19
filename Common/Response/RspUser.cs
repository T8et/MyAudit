using DataHub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Response
{
    public class RspUser
    {
        public RspCommon<BtUser>? ResponseUser { get; set; }
    }

    public class ResponseModel
    {
        public List<BtUser>? usrlst { get; set; }
    }
}
