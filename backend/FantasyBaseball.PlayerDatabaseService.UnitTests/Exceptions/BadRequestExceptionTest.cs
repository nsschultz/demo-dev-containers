using System;
using Xunit;

namespace FantasyBaseball.PlayerDatabaseService.Exceptions.UnitTests
{
    public class BadRequestExceptionTest
    {
        [Fact] public void EqualsDefault() => Assert.Equal("The given request was invalid.", new BadRequestException().Message);

        [Fact] public void EqualsInnerException() 
        {
            var exception = new BadRequestException("message", new Exception("inner message"));
            Assert.Equal("message", exception.Message);
            Assert.Equal("inner message", exception.InnerException.Message);
        }

        [Fact] public void EqualsMessage() => Assert.Equal("message", new BadRequestException("message").Message);
    }
}