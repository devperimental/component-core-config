using System;
using System.Collections.Generic;
using System.Text;

namespace PlatformX.Common.Secrets.Interface
{
    public interface IPlatformSecretFactory
    {
        ISecretLoader Create();
    }
}
