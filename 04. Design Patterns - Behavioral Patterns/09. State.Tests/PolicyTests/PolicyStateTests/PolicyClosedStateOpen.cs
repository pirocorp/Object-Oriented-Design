namespace State.Tests.PolicyTests.PolicyStateTests;

using System;
using Policies;
using Xunit;

public class PolicyClosedStateOpen : BasePolicyTestFixture
{
    [Fact]
    public void SetsStateToOpen()
    {
        this.TestClosedState.Open(DateTime.Now);

        Assert.IsType<Policy.OpenState>(this.TestPolicy.State);
    }

    [Fact]
    public void DoesNotChangeOpenDate()
    {
        this.TestClosedState.Open(DateTime.Now);

        Assert.Null(this.TestPolicy.DateOpened);
    }
}
