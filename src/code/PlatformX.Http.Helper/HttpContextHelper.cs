using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using PlatformX.Http.Behaviours;
using System;
using System.Linq;

namespace PlatformX.Http.Helper
{
    public class HttpContextHelper : IHttpContextHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
 
        public HttpContextHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public string DetermineHost()
        {
            return _httpContextAccessor.HttpContext.Request.Host.ToString();
        }

        public string DetermineIpAddress()
        {
            var ipAddress = string.Empty;

            if (_httpContextAccessor.HttpContext?.Request == null)
                return ipAddress;

            if (_httpContextAccessor.HttpContext.Request.Headers != null)
            {
                var forwarded = _httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"];
       
                if (!string.IsNullOrEmpty(forwarded))
                {
                    var parts = forwarded.ToArray();
                    if (parts.Length > 0)
                    {
                        var ipPort = parts[0].Split(':');
                        if (ipPort.Length > 0)
                        {
                            ipAddress = ipPort[0];
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }

            return ipAddress;
        }

        public string DetermineUserAgent()
        {
            return GetHeaderKeyValue(HeaderNames.UserAgent);
        }

        public string GetHeaderKeyValue(string keyName)
        {
            var keyValue = string.Empty;

            if (_httpContextAccessor.HttpContext?.Request == null)
                return keyValue;

            if (_httpContextAccessor.HttpContext.Request.Headers != null &&
                _httpContextAccessor.HttpContext.Request.Headers.Keys.Contains(keyName))
            {
                keyValue = _httpContextAccessor.HttpContext.Request.Headers[keyName];
            }

            return keyValue;
        }

        public string GetQuerystringKeyValue(string keyName)
        {
            _httpContextAccessor.HttpContext.Request.Query.TryGetValue("dz-app-key", out var appKeyValue);

            return !string.IsNullOrEmpty(appKeyValue) ? appKeyValue.FirstOrDefault() : string.Empty;
        }
    }
}
