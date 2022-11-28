namespace Iterator.Boxes
{
    using System;

    public class Box
    {
        private readonly string name;

        public Box()
        {
            name = $"Box-{new Random().Next()}";
        }

        public override string ToString()
            => name;
    }
}
