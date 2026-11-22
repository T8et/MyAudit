using DataHub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Response
{
    public class ResponseModel
    {
        public List<BtUser>? usrlst { get; set; }

        public List<BtGrp>?  grplst { get; set; }
    }
}
