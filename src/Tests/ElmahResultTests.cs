namespace Elmah.Mvc.Tests
{
    using System.Collections.Specialized;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Moq;

    using Xunit;

    public class ElmahResultTests
    {
        [Fact]
        public void ElmahResult_ExecuteResult_ControllerContextIsNull()
        {
            // Arrange
            ControllerContext controllerContext = null;
            var elmahResult = new ElmahResult();

            // Assert
            Assert.DoesNotThrow(() => elmahResult.ExecuteResult(controllerContext));
        }

        [Fact]
        public void ElmahResult_ExecuteResult_HttpContextIsNull()
        {
            // Arrange
            var mock = new Mock<ControllerContext>();
            mock.Setup(x => x.HttpContext).Returns(() => null);
            var elmahResult = new ElmahResult();

            // Assert
            Assert.DoesNotThrow(() => elmahResult.ExecuteResult(mock.Object));
        }

        [Fact]
        public void ElmahResult_ExecuteResult_RouteDataIsNull()
        {
            // Arrange
            var request = new Mock<HttpRequestBase>();
            request.Setup(x => x.HttpMethod).Returns("GET");
            var httpContextBase = new Mock<HttpContextBase>();
            httpContextBase.Setup(x => x.Request).Returns(request.Object);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(x => x.RouteData).Returns(() => null);
            controllerContext.Setup(x => x.HttpContext).Returns(httpContextBase.Object);
            var elmahResult = new ElmahResult();

            // Assert
            Assert.DoesNotThrow(() => elmahResult.ExecuteResult(controllerContext.Object));
        }

        [Fact]
        public void ElmahResult_ExecuteResult_ResourceNullActionEqualsDetail()
        {
            // Arrange
            var request = new Mock<HttpRequestBase>();
            request.Setup(x => x.HttpMethod).Returns("GET");
            request.Setup(x => x.Path).Returns(@"elmah/detail/detail/stylesheet");
            request.Setup(x => x.QueryString).Returns(new NameValueCollection());
            var httpContextBase = new Mock<HttpContextBase>();
            httpContextBase.Setup(x => x.Request).Returns(request.Object);
            var routeData = new RouteData();
            routeData.Values.Add("action", "Detail");
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(x => x.RouteData).Returns(routeData);
            controllerContext.Setup(x => x.HttpContext).Returns(httpContextBase.Object);
            var elmahResult = new ElmahResult();

            // Assert
            Assert.DoesNotThrow(() => elmahResult.ExecuteResult(controllerContext.Object));
        }

        [Fact]
        public void ElmahResult_ExecuteResult_ResourceNull()
        {
            // Arrange
            var request = new Mock<HttpRequestBase>();
            request.Setup(x => x.HttpMethod).Returns("GET");
            request.Setup(x => x.Path).Returns(@"elmah/detail/detail/stylesheet/");
            request.Setup(x => x.QueryString).Returns(new NameValueCollection());
            var httpContextBase = new Mock<HttpContextBase>();
            httpContextBase.Setup(x => x.Request).Returns(request.Object);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(x => x.RouteData).Returns(() => null);
            controllerContext.Setup(x => x.HttpContext).Returns(httpContextBase.Object);
            var elmahResult = new ElmahResult();

            // Assert
            Assert.DoesNotThrow(() => elmahResult.ExecuteResult(controllerContext.Object));
        }
    }
}