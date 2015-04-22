namespace Elmah.Mvc.Tests
{
    using Elmah.Mvc;

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
    }
}
