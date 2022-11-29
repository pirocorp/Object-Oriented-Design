namespace State.Tests.PolicyTests.PolicyStateTests
{
    using System;
    using Xunit;

    public class PolicyClosedStateVoid : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => this.TestClosedState.Void());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
