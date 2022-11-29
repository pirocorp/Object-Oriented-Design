namespace State.Policies;

using System;
using System.Collections.Generic;

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
