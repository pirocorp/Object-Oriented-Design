namespace State.Tests.PolicyTests.PolicyStateTests
{
    using Xunit;

    public class PolicyOpenStateUpdate : BasePolicyTestFixture
    {
        [Fact]
        public void DoesNotThrow()
        {
            this.TestOpenState.Update();
        }
    }
}
