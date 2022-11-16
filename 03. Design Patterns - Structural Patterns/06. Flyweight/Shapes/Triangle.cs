namespace Flyweight.Shapes
{
    using System;

    /// <summary>
    /// Concrete Flyweight
    /// </summary>
    public class Triangle : IShape
    {
        public void Print()
        {
            Console.WriteLine("Printing Triangle");
        }
    }
}
