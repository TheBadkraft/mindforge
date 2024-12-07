
using MindForge.TestRunner.Core;

/// <summary>
/// Handles the state transitions for the test director in the test runner.
/// </summary>
/// <remarks>
/// This class is responsible for determining if a transition between states is allowed.
/// </remarks>
/// <param name="logger">The logger instance used for logging information.</param>
internal class TestDirectorStateHandler : RunnerStateHandler<RunnerState>
{
    public TestDirectorStateHandler(ILogger logger) : base(logger)
    {
    }

    public override bool CanTransitionTo(RunnerState currentState, RunnerState newState)
    {
        throw new NotImplementedException();
    }
}