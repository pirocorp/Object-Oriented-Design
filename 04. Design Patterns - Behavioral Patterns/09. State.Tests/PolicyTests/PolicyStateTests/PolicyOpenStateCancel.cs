namespace State.Tests.PolicyTests.PolicyStateTests;

using Policies;
using Xunit;

public class PolicyOpenStateCancel : BasePolicyTestFixture
{
    [Fact]
    public void SetsStateToCancelled()
    {
        this.TestOpenState.Cancel();

        Assert.IsType<Policy.CancelledState>(this.TestPolicy.State);
    }
}
