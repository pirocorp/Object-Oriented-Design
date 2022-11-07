namespace TemplateMethod.BoardGames
{
    using System;

    public class SettlersOfCatan : BoardGame
    {
        protected override bool PlayTurn()
        {
            Console.WriteLine("Building, trading, etc.");
            return Random.Next(5) >= 4;
        }

        protected override void SelectWinner()
        {
            Console.WriteLine("Winner is the one who first got 12 points");
        }

        protected override void SetupBoard()
        {
            Console.WriteLine("Randomly placing hexagonal tiles.");
        }
    }
}
