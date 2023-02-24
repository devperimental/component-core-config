using System;

namespace PlatformX.Http.Behaviours
{
    public interface IHttpContextHelper
    {
        string DetermineIpAddress();
        string DetermineUserAgent();
    }
}
