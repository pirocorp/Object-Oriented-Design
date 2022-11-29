namespace State.Tests.PolicyTests.PolicyStateTests;

public class PolicyCancelledStateClose : BasePolicyTestFixture
{
    [Fact]
    public void ThrowsException()
    {
        var exception = Record.Exception(() => this.TestCancelledState.Close(DateTime.Now));

        Assert.IsType<InvalidOperationException>(exception);
    }
}
