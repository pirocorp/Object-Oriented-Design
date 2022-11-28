namespace Iterator
{
    using System;

    public class Box
    {
        private readonly string name;

        public Box()
        {
            this.name = $"Box-{new Random().Next()}";
        }

        public override string ToString()
            => this.name;
    }
}
