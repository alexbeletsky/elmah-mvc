namespace Elmah.Mvc.Tests
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Elmah.Mvc;

    using Moq;

    using Xunit;

    public class ControllerTests
    {
        [Fact]
        public void ElmahController_Index_Returns_ElmahResult()
        {
            // Arrange
            var controller = new ElmahController();
            
            // Act
            var actionResult = controller.Index("test");

            // Assert
            Assert.IsType<ElmahResult>(actionResult);
        }

        [Fact]
        public void ElmahController_Detail_Returns_ElmahResult()
        {
            // Arrange
            var controller = new ElmahController();

            // Act
            var actionResult = controller.Detail("test");

            // Assert
            Assert.IsType<ElmahResult>(actionResult);
        }

        [Fact]
        public void ElmahResult_ExecuteResult_ControllerContextIsNull()
        {
            // Arrange
            ControllerContext controllerContext = null;
            var elmahResult = new ElmahResult();

            // Assert
            Assert.DoesNotThrow(() => elmahResult.ExecuteResult(null));
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
    }
}
