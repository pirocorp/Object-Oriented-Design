namespace ChainOfResponsibility.Corporate
{
    public class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            ProcessRequest(purchase, 25_000);
        }
    }
}
