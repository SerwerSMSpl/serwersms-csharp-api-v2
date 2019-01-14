using System;
using System.Diagnostics.Tracing;

namespace SerwerSMS
{
    /// <summary>
    /// Interface for logging class. Implementation should filter by severity. Verbose severity level should be logged for debugging only (not in production).
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="exception">The exception.</param>
        void Log(string message, EventLevel severity, Exception exception = null);

    }
}
