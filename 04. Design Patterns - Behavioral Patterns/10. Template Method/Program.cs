namespace TemplateMethod
{
    using System;
    using BoardGames;
    using TemplateMethod.Tests;

    public static class Program
    {
        public static void Main()
        {
            // var game = new TerraformingMars();
            // game.Play();

            var tests = new CalculatorTests();
            var success = tests.Run();

            Console.WriteLine($"Result: {(success ? "Success" : "Failure")}");
        }
    }
}
