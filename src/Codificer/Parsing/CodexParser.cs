using MindForge.Codificer.Lexicon.Grammar;
using MindForge.Domain.Core;
using MindForge.Domain.Utilities;
using Index = MindForge.Codificer.Lexicon.Analysis.Index;

namespace MindForge.Codificer;

/// <summary>
/// Parses language definitions from a Codex file creating a structured set of rules.
/// This class uses the `unsafe` keyword to allow pointer manipulation for performance reasons.
/// </summary>
public unsafe class CodexParser : StateMachine<ParserState>
{
    private static Configuration Configuration => Configuration.Initialize();

    public CodexParser() : base(ParserState.Idle, new ParserStateHandler(Configuration.DefaultLogger))
    {
    }

    private Stack<Index> indexStack = new();

    /// <summary>
    /// Reads and parses a Codex file from the given file path.
    /// </summary>
    /// <param name="filePath">The path of the Codex file to parse.</param>
    /// <returns>A <see cref="RuleSet"/> containing the parsed rules; NULL if an error occurred.</returns>
    public RuleSet ParseCodexFromFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
        {
            //  TODO: error handling
        }

        try
        {
            var codex = File.ReadAllText(filePath);
            return ParseCodexRules(codex);
        }
        catch (IOException)
        {
            //  TODO: error handling
            return null;
        }
    }
    /// <summary>
    /// Parses the provided Codex content into a set of rules.
    /// </summary>
    /// <param name="content">The Codex rules contents</param>
    /// <returns>A <see cref="RuleSet"/> containing the parsed rules; NULL if an error occurred.</returns>
    public RuleSet ParseCodexRules(string content)
    {
        if (string.IsNullOrEmpty(content))
        {
            //  TODO: error handling
        }

        RuleSet ruleSet = new();
        IndexContent(content);
        ReadCompatibilityIdentifier(ruleSet);
        ReadHeader(ruleSet);

        //  Parse rules
        while (indexStack.TryPop(out Index index))
        {
            if (IsCommentOrEmpty(index)) continue;
            if (!ParseRule(index, ruleSet))
            {
                //  TODO: error handling
            }
        }

        return ruleSet;
    }

    /// <summary>
    /// Indexes content of the Codex, pushing segments as <see cref="Index"/> 
    /// structs onto <see cref="indexStack"/>.
    /// </summary>
    /// <param name="content">The string content to index.</param>
    private unsafe void IndexContent(string content)
    {
        var chars = content.ToCharArray();

        fixed (char* p = chars)
        {
            char* pos = p;
            char* start = pos;
            char* eos = p + chars.Length - 1;
            List<Index> list = new();

            while (pos <= eos)
            {
                start = pos;
                switch (*pos)
                {
                    case ' ':
                        ++pos;

                        continue;
                    case '\n':
                    case '\r':
                        ++pos;
                        list.Add(new(new(chars, (int)(start - p), 1)));

                        break;
                    default:
                        while (pos <= eos && *pos != ' ' && *pos != '\n' && *pos != '\r')
                        {
                            ++pos;
                        }
                        int length = (int)(pos - start);
                        list.Add(new(new(chars, (int)(start - p), length)));

                        break;
                }
            }

            list.Reverse();
            indexStack = new(list);
        }
    }

    private void ReadCompatibilityIdentifier(RuleSet ruleSet)
    {
        if (indexStack.TryPeek(out Index headerLine) && IsHeader(headerLine))
        {
            indexStack.Pop();
            if (indexStack.TryPeek(out headerLine) && IsCompatibilityIdentifier(headerLine, out string identifier))
            {
                ruleSet.Validate(identifier);
                indexStack.Pop();
            }
        }
    }

    private bool IsHeader(Index index)
    {
        return index.Length > 0 && index[0] == '#' && index[1] == '#';
    }

    private bool IsCompatibilityIdentifier(Index index, out string identifier)
    {
        identifier = string.Empty;
        if (index.Length > 0 && index[0] == '!')
        {
            identifier = new(index.Segment.Array, 1, index.Length - 1);
        }

        return !string.IsNullOrEmpty(identifier);
    }

    private void ReadHeader(RuleSet ruleSet)
    {
        while (indexStack.TryPeek(out Index headerLine) && IsHeader(headerLine))
        {
            if (indexStack.TryPop(out Index line) && line.ToString().Trim().EndsWith("##//"))
            {
                // found end of header
                break;
            }

            //  Process header content
            //  TODO: Implement logic to parse header information
            //  i.e. - Language Name, Relase and Version
        }
    }

    private bool IsCommentOrEmpty(Index index)
    {
        return (index[0] == '#' && index[1] == '#') || index[0] == '\n';
    }

    private bool ParseRule(Index index, RuleSet ruleSet)
    {
        //  TODO: Implement actual rule parsing logic here.
        //  All Index objects are singhle words, not a full line.
        //  Remember to pop off all indexes on stack until we reach '\n'
        while (indexStack.TryPop(out index))
        {
            if (index.ToString().Trim().EndsWith("\n"))
            {
                break;
            }
            //  Rule rule = RuleFactory.CreateRule(...)
            //  ruleSet.Add(rule)
        }

        //  return TRUE for now; if parse fails return FALSE
        return true;
    }
}
