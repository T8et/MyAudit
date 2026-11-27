using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.HttpServices
{
    public class SrvcHttp
    {
        private readonly HttpClient _httpClient;

        public SrvcHttp(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(string url, ReqType reqType, object? data = null)
        {
            var request = new HttpRequestMessage(new HttpMethod(reqType.ToString()), url);

            if (data != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(data),
                    Encoding.UTF8,
                    "application/json"
                );
            }
             
            var response = await _httpClient.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent)!;
        }

        public enum ReqType
        {
            GET,
            POST,
            PUT,
            PATCH,
            DELETE
        }
    }
}
