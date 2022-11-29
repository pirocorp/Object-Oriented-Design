namespace State.Tests.PolicyTests.PolicyStateTests;

public class PolicyCancelledStateVoid : BasePolicyTestFixture
{
    [Fact]
    public void ThrowsException()
    {
        var exception = Record.Exception(() => this.TestCancelledState.Void());

        Assert.IsType<InvalidOperationException>(exception);
    }
}
