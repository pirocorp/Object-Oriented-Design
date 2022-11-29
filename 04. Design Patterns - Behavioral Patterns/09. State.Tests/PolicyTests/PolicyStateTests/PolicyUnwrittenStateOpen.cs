namespace State.Tests.PolicyTests.PolicyStateTests
{
    using Policies;
    using Xunit;

    public class PolicyUnwrittenStateOpen : BasePolicyTestFixture
    {
        [Fact]
        public void SetsStateToOpen()
        {
            this.TestUnwrittenState.Open(this.PolicyBuilder.TEST_OPEN_DATE);

            Assert.IsType<Policy.OpenState>(this.TestPolicy.State);
        }

        [Fact]
        public void SetsDateOpened()
        {
            this.TestUnwrittenState.Open(this.PolicyBuilder.TEST_OPEN_DATE);

            Assert.Equal(this.PolicyBuilder.TEST_OPEN_DATE, this.TestPolicy.DateOpened);
        }
    }
}
