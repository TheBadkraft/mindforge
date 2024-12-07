using MindForge.TestRunner.Logging;

namespace MindForge.TestRunner.Core;

/// <summary>
/// Abstract base class for handling state transitions in a state machine.
/// </summary>
/// <typeparam name="TState">The type of the state, which must be a struct and implement IConvertible, IComparable, and IFormattable.</typeparam>
public abstract class RunnerStateHandler<TState> where TState : struct, IConvertible, IComparable, IFormattable
{
    /// <summary>
    /// Logger instance for logging state transitions.
    /// </summary>
    protected ILogger Logger;

    /// <summary>
    /// Gets the parent state machine associated with this handler.
    /// </summary>
    public RunnerStateMachine<TState> Parent { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StateHandler{TState}"/> class.
    /// </summary>
    /// <param name="logger">The logger instance to use for logging.</param>
    /// <exception cref="ArgumentNullException">Thrown when the logger is null.</exception>
    protected RunnerStateHandler(ILogger logger)
    {
        Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Determines whether a transition from the current state to a new state is allowed.
    /// </summary>
    /// <param name="currentState">The current state.</param>
    /// <param name="newState">The new state to transition to.</param>
    /// <returns>True if the transition is allowed; otherwise, false.</returns>
    public abstract bool CanTransitionTo(TState currentState, TState newState);

    /// <summary>
    /// Called before a state transition occurs.
    /// </summary>
    /// <param name="oldState">The state being transitioned from.</param>
    /// <param name="newState">The state being transitioned to.</param>
    public virtual void OnBeforeTransition(TState oldState, TState newState) { }

    /// <summary>
    /// Called after a state transition occurs.
    /// </summary>
    /// <param name="newState">The state that has been transitioned to.</param>
    public virtual void OnAfterTransition(TState newState)
    {
        Logger?.Log(DebugLevel.Default, $"State transitioned to {newState}");
    }

    /// <summary>
    /// Sets the parent state machine for this handler.
    /// </summary>
    /// <param name="stateMachine">The state machine to set as the parent.</param>
    /// <exception cref="ArgumentNullException">Thrown when the state machine is null.</exception>
    public void SetParentStateMachine(RunnerStateMachine<TState> stateMachine)
    {
        if (stateMachine == null) throw new ArgumentNullException(nameof(stateMachine));
        Parent = stateMachine;
    }
}
