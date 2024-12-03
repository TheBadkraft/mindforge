
namespace MindForge.Codificer.Lexicon.Grammar;

public class RuleSet
{
    private string TC_COMPATIBILITY = "tc_compatibility";

    public List<Rule> Rules { get; init; } = new();
    public bool IsCompatible { get; set; } = false;

    internal void Validate(string identifier)
    {
        IsCompatible = TC_COMPATIBILITY.Equals(identifier, StringComparison.Ordinal);
    }
}
