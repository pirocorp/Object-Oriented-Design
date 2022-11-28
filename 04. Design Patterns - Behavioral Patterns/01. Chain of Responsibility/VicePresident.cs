namespace ChainOfResponsibility
{
    public class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            this.ProcessRequest(purchase, 25_000);
        }
    }
}
