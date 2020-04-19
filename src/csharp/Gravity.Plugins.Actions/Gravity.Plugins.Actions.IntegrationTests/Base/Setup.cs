using NUnit.Framework;

#pragma warning disable RCS1110, S3903
[SetUpFixture]
public class Setup
{
    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        // Executes once before the test run. (Optional)
    }
    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
        // Executes once after the test run. (Optional)
    }
}
#pragma warning restore