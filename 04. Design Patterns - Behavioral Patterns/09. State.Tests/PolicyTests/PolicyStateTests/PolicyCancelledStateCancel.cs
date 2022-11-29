namespace State.Tests.PolicyTests.PolicyStateTests;

public class PolicyCancelledStateCancel : BasePolicyTestFixture
{
    [Fact]
    public void ThrowsException()
    {
        var exception = Record.Exception(() => this.TestCancelledState.Cancel());

        Assert.IsType<InvalidOperationException>(exception);
    }
}
