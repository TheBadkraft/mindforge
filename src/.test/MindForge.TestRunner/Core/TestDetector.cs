using System;

namespace MindForge.TestRunner.Core;

/// <summary>
/// Represents a detector for identifying and managing tests.
/// </summary>
/// <param name="logger">The logger used for logging information and errors.</param>
/// <exception cref="NotImplementedException">Thrown to indicate that the method or operation is not implemented.</exception>
public class TestDetector
{
    private ILogger Logger { get; init; }

    public TestDetector(ILogger logger)
    {
        Logger = logger;
    }
}
