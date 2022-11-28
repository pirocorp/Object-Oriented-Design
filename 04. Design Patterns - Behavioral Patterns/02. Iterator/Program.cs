namespace Iterator
{
    using System;
    using Boxes;

    public static class Program
    {
        public static void Main()
        {
            SimpleIterator();
            // BoxDemo();
        }

        private static void SimpleIterator()
        {
            var simpleIterator = new SimpleIterator<Box>();

            for (var i = 0; i < 10; i++)
            {
                simpleIterator.Add(new Box());
            }

            foreach (var box in simpleIterator)
            {
                Console.WriteLine(box);
            }
        }

        private static void BoxDemo()
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