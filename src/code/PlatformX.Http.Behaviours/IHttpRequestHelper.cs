using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlatformX.Http.Behaviours
{
    public interface IHttpRequestHelper
    {
        Task<T> SubmitRequest<T>(string uri, HttpMethod method, string jsonData, Dictionary<string, string> headers);

    }
}
