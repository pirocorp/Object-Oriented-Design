namespace State.Tests.PolicyTests.PolicyStateTests;

using Policies;
using Xunit;

public class PolicyOpenStateClose : BasePolicyTestFixture
{
    [Fact]
    public void SetsStateToClosed()
    {
        this.TestOpenState.Close(this.PolicyBuilder.TEST_CLOSED_DATE);

        Assert.IsType<Policy.ClosedState>(this.TestPolicy.State);
    }

    [Fact]
    public void SetsDateClosed()
    {
        this.TestOpenState.Close(this.PolicyBuilder.TEST_CLOSED_DATE);

        Assert.Equal(this.PolicyBuilder.TEST_CLOSED_DATE, this.TestPolicy.DateClosed);
    }
}
