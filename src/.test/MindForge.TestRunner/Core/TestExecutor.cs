
namespace MindForge.TestRunner.Core;

/// <summary>
/// Represents a test executor that runs tests and logs the results.
/// </summary>
/// <param name="logger">The logger used to log test execution details.</param>
/// <exception cref="NotImplementedException">Thrown to indicate that the method is not yet implemented.</exception>
public class TestExecutor
{
    private ILogger Logger { get; init; }

    public TestExecutor(ILogger logger)
    {
        Logger = logger;
    }

    internal void ExecuteTests()
    {
        Logger.Log(DebugLevel.Default, "Begin Test Execution ...");
    }
}
