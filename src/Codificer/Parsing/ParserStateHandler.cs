using MindForge.Domain.Logging;
using MindForge.Domain.Utilities;

namespace MindForge.Codificer;

/// <summary>
/// Handles state transitions for the parsing process.
/// </summary>
/// <remarks>
/// This class manages the validation and transitions between different parser states
/// to ensure proper parsing flow and state management.
/// </remarks>
internal class ParserStateHandler : StateHandler<ParserState>
{
    public ParserStateHandler(ILogger logger) : base(logger)
    {
    }

    public override bool CanTransitionTo(ParserState currentState, ParserState newState)
    {
        throw new NotImplementedException();
    }
}