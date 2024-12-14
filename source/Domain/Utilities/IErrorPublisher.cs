
namespace MindForge.Domain.Utilities;

// Class for representing errors
public class Error
{
    public string Message { get; set; }
    public ErrorCode Code { get; set; }
    public Logging.LogLevel LogLevel { get; set; }
}

// Enum for categorizing error codes
public enum ErrorCode
{
    ParseError,
    InvalidRuleDefinition,
    FileNotFound,
    // Other error codes
}

// Delegate for error event handling
public delegate void ErrorEventHandler(Error error);

// Interface for error publishers
public interface IErrorPublisher
{
    event ErrorEventHandler ErrorEvent;
    void PublishError(Error error);
}

// Implementation of error publisher
public class ErrorPublisher : IErrorPublisher
{
    public event ErrorEventHandler ErrorEvent;

    public void PublishError(Error error)
    {
        ErrorEvent?.Invoke(error);
    }
}
