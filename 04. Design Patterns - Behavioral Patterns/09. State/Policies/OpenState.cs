namespace State.Policies;

using System;
using System.Collections.Generic;

public partial class Policy
{
    public class OpenState : IPolicyStateCommands
    {
        private readonly Policy policy;

        public OpenState(Policy policy)
        {
            this.policy = policy;
        }

        public void Cancel()
            => this.policy.State = this.policy.cancelledState;

        public void Close(DateTime closedDate)
        {
            this.policy.State = this.policy.closedState;
            this.policy.DateClosed = closedDate;
        }

        public void Open(DateTime? writtenDate = null)
            => throw new InvalidOperationException("Cannot open a policy that is already open.");

        public void Update()
        {
            // TODO: Add update logic
        }

        public void Void()
            => this.policy.State = this.policy.voidState;

        public List<string> ListValidOperations()
            => new () { "Cancel", "Close", "Update", "Void" };
    }
}
