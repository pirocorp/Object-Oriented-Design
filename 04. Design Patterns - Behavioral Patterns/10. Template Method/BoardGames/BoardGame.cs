namespace TemplateMethod.BoardGames
{
    using System;

    public abstract class BoardGame
    {
        protected BoardGame()
        {
            Random = new Random();
        }

        protected Random Random { get; }

        public void Play()
        {
            SetupBoard();
            var isFinished = false;

            while (!isFinished)
            {
                isFinished = PlayTurn();
            }

            SelectWinner();
        }

        protected abstract bool PlayTurn();

        protected abstract void SelectWinner();

        protected abstract void SetupBoard();
    }
}
