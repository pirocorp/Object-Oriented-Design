namespace State.Tests.PolicyTests;

using Builders;
using Policies;

public abstract class BasePolicyTestFixture
{
    protected BasePolicyTestFixture()
    {
        this.PolicyBuilder = new PolicyBuilder();
        this.TestPolicy = this.PolicyBuilder.Build();

        this.TestCancelledState = new Policy.CancelledState(this.TestPolicy);
        this.TestClosedState = new Policy.ClosedState(this.TestPolicy);
        this.TestOpenState = new Policy.OpenState(this.TestPolicy);
        this.TestUnwrittenState = new Policy.UnwrittenState(this.TestPolicy);
        this.TestVoidState = new Policy.VoidState(this.TestPolicy);
    }

    protected PolicyBuilder PolicyBuilder { get; }

    protected Policy TestPolicy { get; }

    protected Policy.CancelledState TestCancelledState { get; }

    protected Policy.ClosedState TestClosedState { get; }

    protected Policy.OpenState TestOpenState { get; }

    protected Policy.UnwrittenState TestUnwrittenState { get; }

    protected Policy.VoidState TestVoidState { get; }
}
