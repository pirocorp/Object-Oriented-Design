namespace State.Tests.PolicyTests.PolicyStateTests
{
    using System;
    using Xunit;

    public class PolicyUnwrittenStateClose : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => this.TestUnwrittenState.Close(DateTime.Now));

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
