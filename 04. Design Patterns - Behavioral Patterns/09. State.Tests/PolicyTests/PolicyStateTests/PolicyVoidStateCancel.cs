namespace State.Tests.PolicyTests.PolicyStateTests
{
    using System;
    using Xunit;

    public class PolicyVoidStateCancel : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => this.TestVoidState.Cancel());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }

}
