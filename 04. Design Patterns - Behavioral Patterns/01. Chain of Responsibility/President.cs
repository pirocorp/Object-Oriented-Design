namespace ChainOfResponsibility
{
    using System;

    public class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            var response = purchase.Amount > 100_000
                ? $"Request {purchase.Number} requires an executive meeting!"
                : $"{this.GetType().Name} approved request# {purchase.Number}";

            Console.WriteLine(response);
        }
    }
}
