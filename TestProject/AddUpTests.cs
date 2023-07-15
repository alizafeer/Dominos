using FunctionApp;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using ClassLibrary;

namespace TestProject
{
    //This is the test class where all the test cases are written with the Fact keyword
    public class AddUpTests
    {
        //
        [Fact]
        public async Task TestFunction()
        {
            // Arrange
            //Setting basic input as 5
            var a = 5;
            //we expect it to be 6
            var expected = a + 1;

            //had to add a mock logger to plug into the ILogger param for the function
            var loggerMock = new Mock<ILogger>();
            var httpRequest = HttpRequestHelper.CreateHttpRequest(a);

            // Act
            //Injecting the dependency
            AddFunction addFunction = new AddFunction(new Adder());
            var result = await addFunction.Run(httpRequest, loggerMock.Object);
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var actual = Assert.IsType<int>(okObjectResult.Value);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
