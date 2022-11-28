namespace ChainOfResponsibility
{
    public static class Program
    {
        public static void Main()
        {
            var ronny = new Director();
            var bobby = new VicePresident();
            var ricky = new President();

            ronny.SetSuccessor(bobby);
            bobby.SetSuccessor(ricky);

            var p = new Purchase(8884, 350.0M, "Assets");
            ronny.ProcessRequest(p);

            p = new Purchase(5675, 33390.10M, "Project Poison");
            ronny.ProcessRequest(p);

            p = new Purchase(3256, 144400.00M, "Project BBD");
            ronny.ProcessRequest(p);
        }
    }
}