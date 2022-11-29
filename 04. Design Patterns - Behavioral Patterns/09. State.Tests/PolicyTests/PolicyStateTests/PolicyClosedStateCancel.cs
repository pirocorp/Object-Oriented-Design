namespace State.Tests.PolicyTests.PolicyStateTests;

using State.Policies;
using State.Tests.PolicyTests;
using Xunit;

public class PolicyClosedStateCancel : BasePolicyTestFixture
{
    [Fact]
    public void SetsStateToCancelled()
    {
        this.TestClosedState.Cancel();

        Assert.IsType<Policy.CancelledState>(this.TestPolicy.State);
    }
}
