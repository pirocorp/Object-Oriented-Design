namespace State.Tests.PolicyTests.PolicyStateTests;

public class PolicyCancelledStateUpdate : BasePolicyTestFixture
{
    [Fact]
    public void ThrowsException()
    {
        var exception = Record.Exception(() => this.TestCancelledState.Update());

        Assert.IsType<InvalidOperationException>(exception);
    }
}
