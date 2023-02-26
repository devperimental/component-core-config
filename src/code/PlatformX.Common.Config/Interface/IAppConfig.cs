using System;

namespace PlatformX.Common.Config.Interface
{
    public interface IAppConfig
    {
        bool GetBool(string key);
        string GetString(string key);
        int GetInt(string key);
    }
}
