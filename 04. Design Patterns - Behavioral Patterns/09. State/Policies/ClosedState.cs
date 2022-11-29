namespace State.Policies;

using System;
using System.Collections.Generic;

public partial class Policy
{
    public class ClosedState : IPolicyStateCommands
    {
        private readonly Policy policy;

        public ClosedState(Policy policy)
        {
            this.policy = policy;
        }

        public void Cancel()
            => this.policy.State = this.policy.cancelledState;

        public void Close(DateTime closedDate)
            => throw new InvalidOperationException("Cannot close a policy that is already closed.");

        public void Open(DateTime? writtenDate = null)
            => this.policy.State = this.policy.openState;

        public void Update()
            => throw new InvalidOperationException("Cannot update a policy that is closed.");

        public void Void()
            => throw new InvalidOperationException("Cannot void a policy that is closed.");

        public List<string> ListValidOperations() 
            => new() { "Cancel", "Open" };
    }
}
