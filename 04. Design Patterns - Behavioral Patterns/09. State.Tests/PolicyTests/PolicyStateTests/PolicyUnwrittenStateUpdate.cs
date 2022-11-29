namespace State.Tests.PolicyTests.PolicyStateTests
{
    using System;
    using Xunit;

    public class PolicyUnwrittenStateUpdate : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => this.TestUnwrittenState.Update());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
