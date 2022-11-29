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
    public class CancelledState : IPolicyStateCommands
    {
        private readonly Policy policy;

        public CancelledState(Policy policy)
        {
            this.policy = policy;
        }

        public void Cancel()
            => throw new InvalidOperationException("Cannot cancel a policy that has already been cancelled.");

        public void Close(DateTime closedDate)
            => throw new InvalidOperationException("Cannot close a policy that has been cancelled.");

        public void Open(DateTime? writtenDate = null)
            => throw new InvalidOperationException("Cannot open a policy that has been cancelled.");

        public void Update()
            => throw new InvalidOperationException("Cannot update a policy that has been cancelled.");

        public void Void()
            => throw new InvalidOperationException("Cannot void a policy that has been cancelled.");

        public List<string> ListValidOperations()
            => new();
    }
}
