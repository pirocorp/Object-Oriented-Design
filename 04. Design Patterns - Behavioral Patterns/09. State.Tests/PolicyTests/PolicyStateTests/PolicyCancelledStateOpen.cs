namespace State.Tests.PolicyTests.PolicyStateTests;

public class PolicyCancelledStateOpen : BasePolicyTestFixture
{
    [Fact]
    public void ThrowsException()
    {
        var exception = Record.Exception(() => this.TestCancelledState.Open(DateTime.Now));

        Assert.IsType<InvalidOperationException>(exception);
    }
}
