namespace ChainOfResponsibility
{
    using System;

    public class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            this.ProcessRequest(purchase, 10_000);
        }
    }
}
