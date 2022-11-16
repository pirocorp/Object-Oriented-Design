namespace Flyweight.Shapes
{
    using System;

    /// <summary>
    /// Concrete Flyweight
    /// </summary>
    public class Circle : IShape
    {
        public void Print()
        {
            Console.WriteLine("Printing Circle");
        }
    }
}
