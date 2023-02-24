using Microsoft.AspNetCore.Http;
using Moq;
using PlatformX.Http.Helper;
using System.Diagnostics.CodeAnalysis;

namespace Useful.Implementation.Tests
{
    [ExcludeFromCodeCoverage]
    public class HttpTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestContext()
        {

            var contextAccessor = new Mock<IHttpContextAccessor>();
            var httpContextHelper = new HttpContextHelper(contextAccessor.Object);
            
            Assert.IsNotNull(httpContextHelper);
        }

    }
}