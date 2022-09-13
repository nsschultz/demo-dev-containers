using System;
using System.Runtime.Serialization;

namespace FantasyBaseball.PlayerDatabaseService.Exceptions
{
    /// <summary>Exception that is thrown when there is problem getting data from a service.</summary>
    [Serializable] public class CsvFileException : Exception
    {
        // <summary>Initializes a new instance of the exception class with the default error message.</summary>
        public CsvFileException() : base("There was an unknown issue while processing the CSV file.") { }

        /// <summary>Initializes a new instance of the exception class with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        public CsvFileException(string message) : base(message) { }

        /// <summary>Initializes a new instance of the exception class with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) 
        ///     if no inner exception is specified.
        /// </param>
        public CsvFileException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>Initializes a new instance of the System.Exception class with serialized data.</summary>
        /// <param name="info">
        ///     The System.Runtime.Serialization.SerializationInfo that holds the serialized
        ///     object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The System.Runtime.Serialization.StreamingContext that contains contextual information
        ///     about the source or destination..
        /// </param>
        protected CsvFileException(SerializationInfo info, StreamingContext context) :  base(info, context) { }
    }
}