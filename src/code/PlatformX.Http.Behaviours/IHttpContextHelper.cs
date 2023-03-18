using System;

namespace PlatformX.Http.Behaviours
{
    public interface IHttpContextHelper
    {
        string DetermineIpAddress();
        string DetermineUserAgent();
        string DetermineHost();
        string GetHeaderKeyValue(string keyName);
        string GetQuerystringKeyValue(string keyName);
    }
}
