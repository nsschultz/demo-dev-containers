using System;
using Xunit;

namespace FantasyBaseball.PlayerDatabaseService.Exceptions.UnitTests
{
    public class CsvFileExceptionTest
    {
        [Fact] public void EqualsDefault() => Assert.Equal("There was an unknown issue while processing the CSV file.", new CsvFileException().Message);

        [Fact] public void EqualsInnerException() 
        {
            var exception = new CsvFileException("message", new Exception("inner message"));
            Assert.Equal("message", exception.Message);
            Assert.Equal("inner message", exception.InnerException.Message);
        }

        [Fact] public void EqualsMessage() => Assert.Equal("message", new CsvFileException("message").Message);
    }
}