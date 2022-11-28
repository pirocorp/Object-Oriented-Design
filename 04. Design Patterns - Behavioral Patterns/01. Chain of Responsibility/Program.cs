namespace ChainOfResponsibility
{
    using Corporate;
    using Loggers;

    public static class Program
    {
        public static void Main()
        {
            // CorporateDemo();
            LoggerDemo();
        }

        private static void CorporateDemo()
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

        private static void LoggerDemo()
        {
            // Build the chain of responsibility
            var logger = new ConsoleLogger(LogLevel.All)
                .SetNext(new EmailLogger(LogLevel.FunctionalMessage | LogLevel.FunctionalError))
                .SetNext(new FileLogger(LogLevel.Warning | LogLevel.Error));

            // Handled by ConsoleLogger since the console has a logLevel of all
            logger.Message("Entering function ProcessOrder().", LogLevel.Debug);
            logger.Message("Order record retrieved.", LogLevel.Info);

            // Handled by ConsoleLogger and FileLogger since fileLogger implements Warning & Error
            logger.Message("Customer Address details missing in Branch DataBase.", LogLevel.Warning);
            logger.Message("Customer Address details missing in Organization DataBase.", LogLevel.Error);

            // Handled by ConsoleLogger and EmailLogger as it implements functional error
            logger.Message("Unable to Process Order ORD1 Dated D1 For Customer C1.", LogLevel.FunctionalError);

            // Handled by ConsoleLogger and EmailLogger
            logger.Message("Order Dispatched.", LogLevel.FunctionalMessage);
        }
    }
}