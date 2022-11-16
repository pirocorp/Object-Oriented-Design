// Flyweight pattern is one of the structural design patterns
// as this pattern provides ways to decrease object count thus
// improving application required objects structure.
// Flyweight pattern is used when we need to create a large number
// of similar objects (say 105). One important feature of flyweight
// objects is that they are immutable. This means that they cannot
// be modified once they have been constructed.
namespace Flyweight
{
    using System;
    using System.Runtime.InteropServices;

    using Shapes;

    public static class Program
    {
        public static unsafe void Main()
        {
            var factory = new ShapeFactory();

            var shape = factory.GetShape(ShapeType.Triangle);
            PrintShapeMemoryAddress(shape);
            var shape2 = factory.GetShape(ShapeType.Triangle);
            PrintShapeMemoryAddress(shape2);
            var shape3 = factory.GetShape(ShapeType.Triangle);
            PrintShapeMemoryAddress(shape3);
            var shape4 = factory.GetShape(ShapeType.Triangle);
            PrintShapeMemoryAddress(shape4);

            Console.WriteLine(new string('-', 60));

            var shape5 = factory.GetShape(ShapeType.Square);
            PrintShapeMemoryAddress(shape5);
            var shape6 = factory.GetShape(ShapeType.Square);
            PrintShapeMemoryAddress(shape6);
            var shape7 = factory.GetShape(ShapeType.Square);
            PrintShapeMemoryAddress(shape7);
            var shape8 = factory.GetShape(ShapeType.Triangle);
            PrintShapeMemoryAddress(shape8);

            Console.WriteLine();
            Console.WriteLine($"Total shape instances: {factory.Total}");
        }

        private static void PrintShapeMemoryAddress(IShape shape)
        {
            var gcHandle = GCHandle.Alloc(shape, GCHandleType.WeakTrackResurrection);
            var thePointer = Marshal.ReadIntPtr(GCHandle.ToIntPtr(gcHandle));
            gcHandle.Free();

            Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(thePointer.ToInt64())));
        }
    }
}