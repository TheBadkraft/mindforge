using Index = MindForge.Codificer.Lexicon.Analysis.Index;

namespace Codificer.Testing;

[TestClass]
public class CodexParserTests
{

    [TestMethod]
    public void InstantiateCodexParser()
    {
        var codexParser = new CodexParser();

        Assert.IsNotNull(codexParser);
    }


}
