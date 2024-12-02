
using MindForge.Lexicon;

namespace MindForge.Library;

/// <summary>
/// Base class for all grammar rules used in parsing a Codex file
/// </summary>
public abstract class Rule
{
    /// <summary>
    /// Get the rule name.
    /// </summary>
    public string Name { get; protected init; }

    public abstract bool Matches(Stack<Index> indexStack);

    public abstract ParseResult Parse(Stack<Index> indexStack);
}