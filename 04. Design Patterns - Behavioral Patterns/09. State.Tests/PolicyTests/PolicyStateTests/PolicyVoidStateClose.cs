namespace State.Tests.PolicyTests.PolicyStateTests
{
    using System;
    using Xunit;

    public class PolicyVoidStateClose : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => this.TestVoidState.Close(DateTime.Now));

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
