namespace MindForge.Codificer;

/// <summary>
/// Represents the various states that a parser can be in during its lifecycle.
/// </summary>
public enum ParserState
{
    /// <summary>
    /// The parser is idle and not currently processing any input.
    /// </summary>
    Idle,

    /// <summary>
    /// The parser is currently reading input data.
    /// </summary>
    Reading,

    /// <summary>
    /// The parser is currently parsing the input data.
    /// </summary>
    Parsing,

    /// <summary>
    /// The parser is validating the parsed data.
    /// </summary>
    Validation,

    /// <summary>
    /// The parser is including additional data or resources.
    /// </summary>
    Inclusion,

    /// <summary>
    /// The parser is building rules based on the parsed data.
    /// </summary>
    BuildingRules,

    /// <summary>
    /// The parser is cataloging or organizing the rules.
    /// </summary>
    CatalogRules,

    /// <summary>
    /// The parser has encountered an error.
    /// </summary>
    Error,

    /// <summary>
    /// The parser has completed its processing successfully.
    /// </summary>
    Complete,

    /// <summary>
    /// The parser has aborted its processing.
    /// </summary>
    Aborted,
}