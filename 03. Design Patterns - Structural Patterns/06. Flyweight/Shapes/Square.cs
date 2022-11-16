namespace Flyweight.Shapes
{
    using System;

    /// <summary>
    /// Concrete Flyweight
    /// </summary>
    public class Square : IShape
    {
        public void Print()
        {
            Console.WriteLine("Printing Square");
        }
    }
}
