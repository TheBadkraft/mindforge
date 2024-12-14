using MindForge.TestRunner.Core;

#region MindForge.Codificer namespaces
using MindForge.Domain.Logging;
using MindForge.Domain.Utilities;
#endregion

namespace Codificer.Testing;

[TestContainer(Ignore = true)]
public class CodexParserTests
{
    private static CodexParser parser;
    // private static ILogPublisher fakeLogPublisher;
    // private static IErrorPublisher fakeErrorPublisher;
    private static string tempFilePath;

    #region Test Container Initialization and Cleanup

    [ContainerInitialize]
    public static void Initialize(TestContext context)
    {
        // fakeLogPublisher = A.Fake<ILogPublisher>(builder => builder.Implements(typeof(ILogPublisher)));
        // fakeErrorPublisher = A.Fake<IErrorPublisher>(builder => builder.Implements(typeof(IErrorPublisher)));

        // parser = new CodexParser(fakeLogPublisher, fakeErrorPublisher); // Adjust according to CodexParser's constructor

        tempFilePath = Path.Combine(Path.GetTempPath(), "testCodex.codex");
    }

    [ContainerCleanUp]
    public static void CleanUp()
    {
        if (File.Exists(tempFilePath))
        {
            File.Delete(tempFilePath);
        }
    }

    private static string ValidCodexContent()
    {
        return @"
## !tc_compatibility
## 
## Codex: TestLanguage
## Release: Alpha
## Version: 0.1
## Include: []
##//
<expression> := <literal> | <identifier> | <expression> <operator> <expression>
<literal> := 'true' | 'false' | 'null'";
    }
    #endregion

    // initialize CodexParser test
    [Test]
    public void CodexParser_Initialize()
    {
        // parser = new CodexParser(fakeLogPublisher, fakeErrorPublisher);
        Assert.IsNotNull(parser);
    }

}
