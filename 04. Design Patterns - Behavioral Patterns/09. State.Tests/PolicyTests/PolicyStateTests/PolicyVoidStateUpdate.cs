namespace State.Tests.PolicyTests.PolicyStateTests
{
    using System;
    using Xunit;

    public class PolicyVoidStateUpdate : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => this.TestVoidState.Update());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
