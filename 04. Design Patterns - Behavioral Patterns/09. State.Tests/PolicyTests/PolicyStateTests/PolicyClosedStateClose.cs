namespace State.Tests.PolicyTests.PolicyStateTests
{
    using System;
    using Xunit;

    public class PolicyClosedStateClose : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => this.TestClosedState.Close(DateTime.Now));

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
