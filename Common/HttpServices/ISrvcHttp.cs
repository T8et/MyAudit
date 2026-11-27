using System;
using System.Collections.Generic;
using System.Text;
using static Common.HttpServices.SrvcHttp;

namespace Common.HttpServices
{
    public interface ISrvcHttp
    {
        Task<T> SendAsync<T>(string url, ReqType method, object? data = null);
    }
}
