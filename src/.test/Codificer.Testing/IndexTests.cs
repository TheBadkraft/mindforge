using System.Diagnostics;
using Index = MindForge.Codificer.Lexicon.Analysis.Index;

namespace Codificer.Testing;

[TestClass]
public class IndexTests
{
    const string text = "Now is the time for all good men";
    private readonly ArraySegment<char> segment1 = new(text.ToCharArray());

    [TestMethod]
    public void InstantiateIndex()
    {
        var index = new Index(segment1);

        Assert.AreEqual(text, index.ToString());
        Assert.AreEqual(text.Length, index.Length);

        // Debug.WriteLine($"text: '{index}'");
    }
}