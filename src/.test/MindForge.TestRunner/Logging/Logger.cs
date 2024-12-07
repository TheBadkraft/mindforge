
namespace MindForge.TestRunner.Logging;

/// <summary>
/// General purpose logger for logging messages to the console 
/// standard output, error output, debug trace listener, and a 
/// log file.
/// </summary>
public class Logger : TraceListener, ILogger
{
    private readonly TextWriter stdOut = Console.Out;
    private readonly TextWriter stdErr = Console.Error;
    private TextWriter writer;

    /// <summary>
    /// Initializes a new instance of the <see cref="Logger"/> class.
    /// </summary>
    public Logger(string logFilePath)
    {
        var stream = new StreamWriter(logFilePath, false);
        // stream.BaseStream.SetLength(0);
        stream.AutoFlush = true;
        writer = stream;

        Console.SetOut(writer);
        Console.SetError(writer);

        Trace.Listeners.Add(this);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="message"></param>
    public override void Write(string message) => writer.Write(message);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="message"></param>
    public override void WriteLine(string message) => writer.WriteLine(message);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="debugLevel"></param>
    /// <param name="message"></param>
    public void Log(DebugLevel debugLevel, string message)
    {
        switch (debugLevel)
        {
            case DebugLevel.Default:
                WriteLine(LogFormat.Info(message));

                break;
            case DebugLevel.Warning:
                WriteLine(LogFormat.Warning(message));

                break;
            case DebugLevel.Error:
                WriteLine(LogFormat.Error(message));

                break;
            case DebugLevel.Fatal:
                WriteLine(LogFormat.Fatal(message));

                break;
        }
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="disposing"></param>
    protected override void Dispose(bool disposing)
    {
        Console.SetOut(stdOut);
        Console.SetError(stdErr);

        Trace.Listeners.Remove(this);

        writer.Dispose();
        writer = null;

        GC.SuppressFinalize(this);

        base.Dispose(disposing);
    }
}
