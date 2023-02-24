using System.Collections.Generic;

namespace PlatformX.Common.Secrets.Interface
{
    public interface ISecretLoader
    {
        Dictionary<string, string> LoadSecrets(List<string> keyList);

        string LoadSecret(string key);

        void SaveSecret(string key, string value);

        void DeleteSecret(string key);

        void PopulateSecrets(Dictionary<string, string> secrets);
    }
}
