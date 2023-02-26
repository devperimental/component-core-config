using Microsoft.AspNetCore.Http;
using Moq;
using Moq.AutoMock;
using PlatformX.Http.Helper;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;
using Serilog.Sinks.InMemory;
using System.Diagnostics.CodeAnalysis;
using Serilog;
using Newtonsoft.Json;
using Moq.Protected;

namespace Useful.Implementation.Tests
{
    [ExcludeFromCodeCoverage]
    public class HttpTests
    {
        private AutoMocker _mocker;

        [SetUp]
        public void Setup()
        {
            
            _mocker = new AutoMocker();
            _mocker.Use(CreateInMemoryLogger<HttpRequestHelper>());
        }

        [Test]
        public void TestHttpContextHelper()
        {

            var contextAccessor = new Mock<IHttpContextAccessor>();
            var httpContextHelper = new HttpContextHelper(contextAccessor.Object);
            
            Assert.IsNotNull(httpContextHelper);
        }

        [Test]
        public async Task TestHttpRequestHelper()
        {
            var responseData = "{\"Result\":\"123456\"}";
            var httpClientFactoryMock = CreateHttpClientFactoryMock(responseData);

            _mocker.Use(httpClientFactoryMock);

            var uri = "https://localhost/endppoint";
            var method = HttpMethod.Post;
            var data = "{\"data\":\"abcdef\"}";
            var headers = new Dictionary<string, string>()
            {
                { "Content-Header", "value" }
            };

            var httpRequestHelper = _mocker.CreateInstance<HttpRequestHelper>();

            var response = await httpRequestHelper.SubmitRequest<TestType>(uri, method, data, headers);

            var responseSerialized = JsonConvert.SerializeObject(response);

            Assert.That(responseData, Is.EqualTo(responseSerialized));
        }

        public static ILogger<T> CreateInMemoryLogger<T>()
        {
            var serilogLogger = new LoggerConfiguration()
                .WriteTo
                .InMemory()
                .CreateLogger();

            return new SerilogLoggerFactory(serilogLogger).CreateLogger<T>();
        }

        public static Mock<IHttpClientFactory> CreateHttpClientFactoryMock(string content)
        {
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(content)
            };

            // Create Client Handler
            var clientHandler = new Mock<DelegatingHandler>();
            
            clientHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(responseMessage)
                .Verifiable();
            
            clientHandler.As<IDisposable>().Setup(s=>s.Dispose());

            // Create Http Client
            var httpClient = new HttpClient(clientHandler.Object);

            // Create Http Factory
            var clientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);
            
            clientFactory
                .Setup(x=>x.CreateClient(It.IsAny<string>()))
                .Returns(httpClient)
                .Verifiable();

            return clientFactory;

        }
    }

    public class TestType
    {
        public string Result { get; set; }
    }

    
}
