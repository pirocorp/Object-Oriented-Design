namespace Prototype.Colors;

using System;

public class Color : ColorPrototype
{
    private readonly int red;

    private readonly int green;

    private readonly int blue;

    public Color(int red, int green, int blue)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
    }

    public override ColorPrototype Clone()
    {
        Console.WriteLine($"RGB color is cloned to: {this.red,3},{this.green,3},{this.blue,3}");

        return (this.MemberwiseClone() as ColorPrototype)!;
    }
}
