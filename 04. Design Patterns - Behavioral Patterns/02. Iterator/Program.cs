namespace Iterator
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var boxes = new[] { new Box(), new Box(), new Box(), new Box(), new Box() };
            var boxCollection = new BoxCollection(boxes);

            foreach (var box in boxCollection)
            {
                Console.WriteLine(box);
            }
        }
    }
}