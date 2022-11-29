namespace State.Tests.PolicyTests.PolicyStateTests
{
    using System;
    using Xunit;

    public class PolicyClosedStateUpdate : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => this.TestClosedState.Update());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
