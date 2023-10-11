using BoxFactoryAPI.Exceptions;
using BoxFactoryAPI.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;

namespace BoxFactoryUnitTests;

public class ExceptionMiddlewareTest
{

    private Mock<ILogger<ExceptionMiddleware>> _loggerMock = new();

    [Fact]
    public async Task MiddlewareShouldReturnBadRequestOnInvalidColorException()
    {
        // Arrange
        string exceptionMessage = "Wrong color my friend";

        string expectedMessage = $"{nameof(InvalidColorException)} {exceptionMessage}";

        HttpContext ctx = new DefaultHttpContext();

        var responseStream = new MemoryStream();
        ctx.Response.Body = responseStream;

        RequestDelegate next = (HttpContext hc) => throw new InvalidColorException(exceptionMessage);

        var middleware = new ExceptionMiddleware(next, _loggerMock.Object);

        // Act
        await middleware.Invoke(ctx);

        responseStream.Seek(0, SeekOrigin.Begin);
        var responseContent = await new StreamReader(responseStream).ReadToEndAsync();

        // Assert

        Assert.Equal(StatusCodes.Status400BadRequest, ctx.Response.StatusCode);
        Assert.Equal(expectedMessage, responseContent);
    }

    [Fact]
    public async Task MiddlewareShouldReturnInternalServerErrorOnExceptionsOnNotImplementedException()
    {
        // Arrange
        string expectedMessage = "Internal Server Error";

        HttpContext ctx = new DefaultHttpContext();

        var responseStream = new MemoryStream();
        ctx.Response.Body = responseStream;

        RequestDelegate next = (HttpContext hc) => throw new NotImplementedException("This should be an internal server error response");

        var middleware = new ExceptionMiddleware(next, _loggerMock.Object);

        // Act
        await middleware.Invoke(ctx);

        responseStream.Seek(0, SeekOrigin.Begin);
        var responseContent = await new StreamReader(responseStream).ReadToEndAsync();

        // Assert

        Assert.Equal(StatusCodes.Status500InternalServerError, ctx.Response.StatusCode);
        Assert.Equal(expectedMessage, responseContent);
    }

    [Fact]
    public async Task MiddlewareShouldReturnInternalServerErrorOnExceptionsOnException()
    {
        // Arrange
        string expectedMessage = "Internal Server Error";

        HttpContext ctx = new DefaultHttpContext();

        var responseStream = new MemoryStream();
        ctx.Response.Body = responseStream;

        RequestDelegate next = (HttpContext hc) => throw new Exception("This should be an internal server error response");

        var middleware = new ExceptionMiddleware(next, _loggerMock.Object);

        // Act
        await middleware.Invoke(ctx);

        responseStream.Seek(0, SeekOrigin.Begin);
        var responseContent = await new StreamReader(responseStream).ReadToEndAsync();

        // Assert

        Assert.Equal(StatusCodes.Status500InternalServerError, ctx.Response.StatusCode);
        Assert.Equal(expectedMessage, responseContent);
    }
}
