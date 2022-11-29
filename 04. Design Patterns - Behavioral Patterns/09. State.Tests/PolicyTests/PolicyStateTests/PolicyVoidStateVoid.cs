namespace State.Tests.PolicyTests.PolicyStateTests
{
    using System;
    using Xunit;

    public class PolicyVoidStateVoid : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => this.TestVoidState.Void());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
