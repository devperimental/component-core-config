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
                EnvironmentName  = "ABC",
                AzureRegion  = "ABC",
                AzureLocation  = "ABC",
                AzureTenantId = "ABC",
                PortalName = "ABC",
                Layer  = "ABC",
                ServiceKeys  = "ABC",
                RuntimeConfiguration  = "ABC",
                ServiceSymmetricKeyName  = "ABC"
            };

            Assert.IsNotNull(config);            
        }
    }
}