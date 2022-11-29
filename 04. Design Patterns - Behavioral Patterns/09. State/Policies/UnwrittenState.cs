namespace State.Policies;

using System;
using System.Collections.Generic;

/// <summary>
/// Note that in this example each State subtype is defined as an
/// inner class within the Policy class. The classes are defined
/// in separate partial Policy classes so they can reside in separate
/// files without bloating the Policy class definition. Since these
/// State classes are defined as inner classes, they have direct
/// access to private member variables defined in Policy, so there
/// is no need to expose Policy's list of possible states publicly.
/// </summary>
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
