namespace State.Tests.PolicyTests.PolicyStateTests
{
    using System;
    using Xunit;

    public class PolicyVoidStateOpen : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => this.TestVoidState.Open(DateTime.Now));

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
