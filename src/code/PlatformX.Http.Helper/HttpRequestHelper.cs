using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PlatformX.Http.Behaviours;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlatformX.Http.Helper
{
    public class HttpRequestHelper : IHttpRequestHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HttpRequestHelper> _logger;

        public HttpRequestHelper(IHttpClientFactory httpClientFactory, ILogger<HttpRequestHelper> logger)
        {
            _httpClientFactory = httpClientFactory; 
            _logger = logger;
        }

        public async Task<T> SubmitRequest<T>(string uri, HttpMethod method, string jsonData, Dictionary<string, string> headers)
        {
            var content = string.Empty;

            var request = new HttpRequestMessage(method, uri);
            if (!string.IsNullOrEmpty(jsonData))
            {
                request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            }

            if (headers != null)
            {
                foreach (var h in headers)
                {
                    request.Headers.Add(h.Key, h.Value);
                }
            }

            try
            {
                T returnObject;
                using var httpClient = _httpClientFactory.CreateClient();
                using var response = await httpClient.SendAsync(request);
                
                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                    returnObject = JsonConvert.DeserializeObject<T>(content);
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(content))
                        {
                            throw new ApplicationException(content);
                        }
                        throw new ApplicationException(response.ReasonPhrase);
                    }
                    else if (response.StatusCode == HttpStatusCode.BadGateway)
                    {
                        var message = "BadGateway Error: ";
                        message += $" Status Code: {response.StatusCode}";
                        message += $" Reason Phrase: {response.ReasonPhrase}";

                        throw new ApplicationException(message);
                    }
                    else
                    {
                        throw new ApplicationException(JsonConvert.SerializeObject(response));
                    }
                }
                
                return await Task.FromResult(returnObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to send message to {uri} with {jsonData} and response {content}", uri, jsonData, content);
                throw;
            }
        }
    }
}
