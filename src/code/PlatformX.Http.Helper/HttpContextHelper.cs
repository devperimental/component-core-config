using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using PlatformX.Http.Behaviours;
using System;

namespace PlatformX.Http.Helper
{
    public class HttpContextHelper : IHttpContextHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
 
        public HttpContextHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
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
            var userAgent = string.Empty;

            if (_httpContextAccessor.HttpContext?.Request == null)
                return userAgent;
            
            if (_httpContextAccessor.HttpContext.Request.Headers != null)
            {
                userAgent = _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.UserAgent];
            }

            return userAgent;
        }
    }
}
