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
