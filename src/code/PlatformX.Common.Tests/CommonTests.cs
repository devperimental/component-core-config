using PlatformX.Common.Types.DataContract;
using System.Diagnostics.CodeAnalysis;

namespace Useful.Implementation.Tests
{
    [ExcludeFromCodeCoverage]
    public class CommonTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestConfiguration()
        {
            var config = new BootstrapConfiguration()
            {
                Prefix  = "ABC",
                RoleKey  = "ABC",
                Environment  = "ABC",
                Region  = "ABC",
                Location  = "ABC",
                PortalName  = "ABC",
                Layer  = "ABC",
                LogMessages  = true,
                LogWarnings  = true,
                LogErrors  = true,
                DBName  = "ABC",
                PlatformServiceMetaData  = "ABC",
                ServiceKeys  = "ABC",
                RuntimeConfiguration  = "ABC",
                TenantId  = "ABC",
                ServiceSymmetricKeyName  = "ABC",
                ServerName  = "ABC",
                BuildNumber  = "ABC",
                ContainerType  = "ABC"
            };

            Assert.IsNotNull(config);            
        }

        [Test]
        public void TestRuntimeSettings()
        {
            var config = new RuntimeSettings()
            {
                Settings = new Dictionary<string, string> { { "ABC", "DEF"} }
            };

            Assert.IsNotNull(config);
        }
    }
}