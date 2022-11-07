namespace TemplateMethod.BoardGames
{
    using System;

    public class TerraformingMars : BoardGame
    {
        protected override void SetupBoard()
        {
            Console.WriteLine("Choosing from two available maps.");
        }

        protected override bool PlayTurn()
        {
            Console.WriteLine("Raising oxygen level, placing oceans, etc.");

            return Random.Next(5) >= 4;
        }

        protected override void SelectWinner()
        {
            Console.WriteLine("Winner is the one with most points at game's end.");
        }
    }
}
