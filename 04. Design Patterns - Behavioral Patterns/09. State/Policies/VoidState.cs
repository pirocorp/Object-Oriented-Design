namespace State.Policies;

using System;
using System.Collections.Generic;

public partial class Policy
{
    public class VoidState : IPolicyStateCommands
    {
        private readonly Policy policy;

        public VoidState(Policy policy)
        {
            this.policy = policy;
        }

        public void Cancel()
            => throw new InvalidOperationException("Cannot cancel a policy that is void.");

        public void Close(DateTime closedDate)
            => throw new InvalidOperationException("Cannot close a policy that is void.");
        
        public void Open(DateTime? writtenDate = null)
            => throw new InvalidOperationException("Cannot open a policy that is void.");

        public void Update()
            => throw new InvalidOperationException("Cannot open a policy that is void.");

        public void Void()
            => throw new InvalidOperationException("Cannot open a policy that is void.");

        public List<string> ListValidOperations() => new ();
    }
}
