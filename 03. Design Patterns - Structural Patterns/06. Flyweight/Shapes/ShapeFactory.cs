namespace Flyweight.Shapes
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Flyweight Factory
    /// </summary>
    public class ShapeFactory
    {
        private readonly Dictionary<ShapeType, IShape> shapes;

        public ShapeFactory()
        {
            this.shapes = new Dictionary<ShapeType, IShape>();
        }

        public int Total => this.shapes.Count;

        public IShape GetShape(ShapeType shapeType)
        {
            if (!this.shapes.ContainsKey(shapeType))
            {
                this.CreateShape(shapeType);
            }

            return this.shapes[shapeType];
        }

        private void CreateShape(ShapeType shapeType)
        {
            IShape shape = shapeType switch
            {
                ShapeType.Circle => new Circle(),
                ShapeType.Triangle => new Triangle(),
                ShapeType.Square => new Square(),
                _ => throw new ArgumentOutOfRangeException(nameof(shapeType), shapeType, null)
            };

            this.shapes.Add(shapeType, shape);
        }
    }
}
