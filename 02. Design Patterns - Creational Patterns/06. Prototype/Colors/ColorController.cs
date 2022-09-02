namespace Prototype.Colors;

using System.Collections.Generic;

public class ColorController
{
    private readonly Dictionary<PredefinedColor, ColorPrototype> colors;

    public ColorController()
    {
        this.colors = new Dictionary<PredefinedColor, ColorPrototype>();
    }

    public ColorPrototype this[PredefinedColor key]
    {
        get => this.colors[key];
        set => this.colors[key] = value;
    }
}
