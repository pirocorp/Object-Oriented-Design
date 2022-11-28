namespace ChainOfResponsibility.Corporate
{
    using System;

    public class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            ProcessRequest(purchase, 10_000);
        }
    }
}
