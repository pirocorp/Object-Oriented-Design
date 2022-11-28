namespace ChainOfResponsibility.Corporate
{
    using System;

    public abstract class Approver
    {
        public void SetSuccessor(Approver next)
        {
            Successor = next;
        }

        protected Approver? Successor { get; private set; }

        public abstract void ProcessRequest(Purchase purchase);

        protected virtual void ProcessRequest(Purchase purchase, decimal limit)
        {
            if (purchase.Amount > limit)
            {
                Successor?.ProcessRequest(purchase);
                return;
            }

            Console.WriteLine($"{GetType().Name} approved request# {purchase.Number}");
        }
    }
}
