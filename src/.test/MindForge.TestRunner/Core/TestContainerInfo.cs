
namespace MindForge.TestRunner.Core;

public class TestContainerInfo
{
    private object _target = null;
    //  lazy load the target object
    private object Target => _target ??= Activator.CreateInstance(ContainerType);

    public string Name { get; }
    public string CurrentTest { get; set; }
    public Type ContainerType { get; }
    public Dictionary<string, TestCase> TestCases { get; set; } = new();

    public InitializeContainer InitializeContainer { get; set; }
    public CleanUpContainer CleanUpContainer { get; set; }
    public TestSetUp TestSetUp { get; set; }
    public TestTearDown TestTearDown { get; set; }
    public PropertyInfo TestContextProperty { get; set; }
    public AssignTestContext AssignContextDelegate { get; set; }

    public TestContainerInfo(Type containerType)
    {
        ContainerType = containerType ?? throw new ArgumentNullException(nameof(containerType));
        Name = containerType.Name;

        InitializeContainer = GetDelegate<InitializeContainer>(containerType, typeof(ContainerInitializeAttribute), BindingFlags.Static | BindingFlags.Public, typeof(TestContext));
        CleanUpContainer = GetDelegate<CleanUpContainer>(containerType, typeof(ContainerCleanUpAttribute), BindingFlags.Static | BindingFlags.Public);
        TestSetUp = GetDelegate<TestSetUp>(containerType, typeof(SetUpAttribute), BindingFlags.Instance | BindingFlags.Public);
        TestTearDown = GetDelegate<TestTearDown>(containerType, typeof(TearDownAttribute), BindingFlags.Instance | BindingFlags.Public);

        // For the TestContext property, without using an attribute
        AssignContextDelegate = GetDelegate<AssignTestContext>(containerType, "TestContext", BindingFlags.Static | BindingFlags.Public);
    }

    /// <summary>
    /// Add the test cases.
    /// </summary>
    /// <param name="testMethodsInfo">The test methods info.</param>
    internal void AddTests(IEnumerable<MethodInfo> testMethodsInfo)
    {
        foreach (var method in testMethodsInfo)
        {
            // Convert MethodInfo to TestCase delegate
            var testCase = CreateDelegate<TestCase>(ContainerType, m => m == method, BindingFlags.Instance | BindingFlags.Public);
            if (testCase != null)
            {
                TestCases.Add(method.Name, testCase);
            }
        }
    }

    private TDelegate GetDelegate<TDelegate>(Type type, Type attributeType, BindingFlags bindingFlags, params Type[] parameterTypes) where TDelegate : Delegate
    {
        return CreateDelegate<TDelegate>(type, m => m.GetCustomAttribute(attributeType) != null, bindingFlags, parameterTypes);
    }

    private TDelegate GetDelegate<TDelegate>(Type type, string methodName, BindingFlags bindingFlags, params Type[] parameterTypes) where TDelegate : Delegate
    {
        return CreateDelegate<TDelegate>(type, m => m.Name == methodName, bindingFlags, parameterTypes);
    }

    private TDelegate CreateDelegate<TDelegate>(Type type, Func<MethodInfo, bool> methodFilter, BindingFlags bindingFlags, params Type[] parameterTypes) where TDelegate : Delegate
    {
        var method = type.GetMethods(bindingFlags)
            .Where(methodFilter)
            .Where(m => m.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameterTypes))
            .FirstOrDefault();


        if (method != null)
        {
            if (parameterTypes?.Any() == true)
            {
                return CreateWrappedDelegate<TDelegate>(method);
            }
            else
            {
                // Handle TestContext property
                if (method.ReturnType == typeof(TestContext))
                {
                    return CreateWrappedDelegate<TDelegate>(method);
                }
                // For other (TestCase) methods with no parameters
                if (method.GetParameters().Length == 0)
                {
                    return CreateWrappedDelegate<TDelegate>(method);
                }
            }
        }

        return null;
    }

    private TDelegate CreateWrappedDelegate<TDelegate>(MethodInfo method) where TDelegate : Delegate
    {
        if (method.IsStatic)
        {
            return method.CreateDelegate<TDelegate>(null);
        }
        else
        {
            return method.CreateDelegate<TDelegate>(Target);
        }
    }
}