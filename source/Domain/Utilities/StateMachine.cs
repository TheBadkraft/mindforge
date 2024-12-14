using System;

namespace MindForge.Domain.Utilities;

/// <summary>
/// Represents an abstract state machine that manages transitions between states.
/// </summary>
/// <typeparam name="TState">The type of the state enumeration.</typeparam>
public abstract class StateMachine<TState> where TState : struct, IConvertible, IComparable, IFormattable
{
    /// <summary>
    /// Gets the current state of the state machine.
    /// </summary>
    protected TState CurrentState { get; private set; }

    /// <summary>
    /// Gets or sets the state handler responsible for managing state transitions.
    /// </summary>
    protected StateHandler<TState> StateHandler;

    /// <summary>
    /// Initializes a new instance of the <see cref="StateMachine{TState}"/> class with the specified initial state and state handler.
    /// </summary>
    /// <param name="initialState">The initial state of the state machine.</param>
    /// <param name="stateHandler">The state handler responsible for managing state transitions.</param>
    /// <exception cref="ArgumentNullException">Thrown when the state handler is null.</exception>
    protected StateMachine(TState initialState, StateHandler<TState> stateHandler)
    {
        CurrentState = initialState;
        StateHandler = stateHandler ?? throw new ArgumentNullException(nameof(stateHandler));
    }

    /// <summary>
    /// Transitions the state machine to a new state.
    /// </summary>
    /// <param name="newState">The new state to transition to.</param>
    /// <exception cref="ArgumentException">Thrown when the new state is not a valid state.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the transition from the current state to the new state is not allowed.</exception>
    public void TransitionTo(TState newState)
    {
        if (!Enum.IsDefined(typeof(TState), newState))
        {
            throw new ArgumentException("Invalid state", nameof(newState));
        }

        if (StateHandler.CanTransitionTo(CurrentState, newState))
        {
            StateHandler.OnBeforeTransition(CurrentState, newState);
            CurrentState = newState;
            StateHandler.OnAfterTransition(newState);
        }
        else
        {
            throw new InvalidOperationException($"Cannot transition from {CurrentState} to {newState}");
        }
    }
}
