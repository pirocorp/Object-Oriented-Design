namespace State.Tests.PolicyTests.PolicyStateTests;

using Policies;
using Xunit;

public class PolicyOpenStateVoid : BasePolicyTestFixture
{
    [Fact]
    public void SetsStateToVoid()
    {
        this.TestOpenState.Void();

        Assert.IsType<Policy.VoidState>(this.TestPolicy.State);
    }
}
