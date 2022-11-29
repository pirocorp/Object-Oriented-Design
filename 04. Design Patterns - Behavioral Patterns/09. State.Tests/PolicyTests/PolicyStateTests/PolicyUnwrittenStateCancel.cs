namespace State.Tests.PolicyTests.PolicyStateTests
{
    using System;
    using Xunit;

    public class PolicyUnwrittenStateCancel : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => this.TestUnwrittenState.Cancel());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }

}
