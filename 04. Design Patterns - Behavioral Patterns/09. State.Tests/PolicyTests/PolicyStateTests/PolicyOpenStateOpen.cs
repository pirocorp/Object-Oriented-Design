namespace State.Tests.PolicyTests.PolicyStateTests
{
    using System;
    using Xunit;

    public class PolicyOpenStateOpen : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => this.TestOpenState.Open(DateTime.Now));

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
