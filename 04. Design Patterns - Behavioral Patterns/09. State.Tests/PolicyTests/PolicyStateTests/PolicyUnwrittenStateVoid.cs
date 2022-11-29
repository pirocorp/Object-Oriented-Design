namespace State.Tests.PolicyTests.PolicyStateTests;

using Policies;
using Xunit;

public class PolicyUnwrittenStateVoid : BasePolicyTestFixture
{
    [Fact]
    public void SetsStateToVoid()
    {
        this.TestUnwrittenState.Void();

        Assert.IsType<Policy.VoidState>(this.TestPolicy.State);
    }
}
