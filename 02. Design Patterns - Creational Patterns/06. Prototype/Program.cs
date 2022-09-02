namespace Prototype;

using System;
using Colors;

public static class Program
{
    public static void Main()
    {
        ColorsDemo();
    }

    private static void ColorsDemo()
    {
        var colorController = new ColorController
        {
            [PredefinedColor.Yellow] = new Color(255, 255, 0),
            [PredefinedColor.Orange] = new Color(255, 128, 0),
            [PredefinedColor.Purple] = new Color(128, 0, 255),
            [PredefinedColor.Sunny] = new Color(255, 54, 0),
            [PredefinedColor.Tasty] = new Color(255, 153, 51),
            [PredefinedColor.Rainy] = new Color(255, 0, 255)
        };

        var c1 = colorController[PredefinedColor.Yellow].Clone() as Color;
        var c2 = colorController[PredefinedColor.Tasty].Clone() as Color;
        var c3 = colorController[PredefinedColor.Rainy].Clone() as Color;

        Console.WriteLine(c1 == colorController[PredefinedColor.Yellow]);
        Console.WriteLine(c2 == colorController[PredefinedColor.Tasty]);
        Console.WriteLine(c3 == colorController[PredefinedColor.Rainy]);
    }
}
