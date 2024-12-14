
using MindForge.Domain.Logging;

namespace Codificer.Testing;

[TestContainer]
public class LogSubjectTests
{
    private ILogger Logger { get; set; }
    private LogSubject LogSubject { get; set; }

    [Test]
    public void Attach_AddsObserverToList()
    {
        // Arrange

        // Act
        LogSubject.Attach(Logger);

        // Assert
        Assert.Contains(LogSubject.Observers, (x) => x == Logger);
    }

    #region Container Initialize & CleanUp
    [ContainerInitialize]
    public void Initialize()
    {
        Logger = A.Fake<ILogger>();
        LogSubject = new LogSubject();
    }

    [ContainerCleanUp]
    public void CleanUp()
    {
        LogSubject.Clear();
    }
    #endregion
}
