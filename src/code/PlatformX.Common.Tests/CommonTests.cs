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
            var config = new BootstrapConfiguration();
            Assert.IsNotNull(config);            
        }

        [Test]
        public void TestRuntimeSettings()
        {
            var config = new RuntimeSettings();
            Assert.IsNotNull(config);
        }
    }
}