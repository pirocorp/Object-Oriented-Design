namespace State.Policies;

using System;
using System.Collections.Generic;

public partial class Policy
{
    public class UnwrittenState : IPolicyStateCommands
    {
        private readonly Policy policy;

        public UnwrittenState(Policy policy)
        {
            this.policy = policy;
        }

        public void Cancel()
            => throw new InvalidOperationException("Cannot cancel a policy before it's been Opened.");

        public void Close(DateTime closedDate)
            => throw new InvalidOperationException("Cannot close a policy before it's been Opened.");

        public void Open(DateTime? writtenDate = null)
        {
            this.policy.State = this.policy.openState;
            this.policy.DateOpened = writtenDate;
        }

        public void Update()
            => throw new InvalidOperationException("Cannot update a policy before it's been Opened.");

        public void Void()
            => this.policy.State = this.policy.voidState;

        public List<string> ListValidOperations() => new() { "Open", "Void" };
    }
}
