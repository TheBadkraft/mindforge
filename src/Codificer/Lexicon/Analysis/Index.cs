
namespace MindForge.Codificer.Lexicon.Analysis;

/// <summary>
/// Represents an index into a character array (<see cref="string"/>), 
/// encapsultating an <see cref="ArraySegment{char}"/> to facilitate access to a portion 
/// of the text within the Codex file.
/// </summary>
public struct Index
{
    /// <summary>
    /// Gets the segment of characters this index refers to.
    /// </summary>
    public ArraySegment<char> Segment { get; init; }
    /// <summary>
    /// Gets the character at the specified index within the encapsulated segment.
    /// </summary>
    /// <param name="i">The index of the character to retrieve</param>
    /// <returns>The character at the given index.</returns>
    public char this[int i] => Segment[i];
    /// <summary>
    /// Returns the length of the index segment
    /// </summary>
    public int Length => Segment.Count;

    /// <summary>
    /// Initializes a new instance of the <see cref="Index"/> struct with the 
    /// specified segment.
    /// </summary>
    /// <param name="segment">The segment of characters to index</param>
    public Index(ArraySegment<char> segment) => Segment = segment;

    /// <summary>
    /// Converts the indexed segment into a string.
    /// </summary>
    /// <returns>A new string represent the character segment.</returns>
    public override string ToString() => new string(Segment.Array, Segment.Offset, Segment.Count);
}
