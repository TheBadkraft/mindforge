
namespace MindForge.TestRunner.Core;

/// <summary>
/// Represents an auditor for running tests.
/// </summary>
/// <param name="logger">The logger used for logging test audit information.</param>
/// <exception cref="NotImplementedException">Thrown to indicate that the constructor is not yet implemented.</exception>
public class TestAuditor
{
    private ILogger Logger { get; init; }

    public TestAuditor(ILogger logger)
    {
        Logger = logger;
    }

    internal void AuditResults()
    {
        Logger.Log(DebugLevel.Default, "Begin Auditing Results ...");
    }
}