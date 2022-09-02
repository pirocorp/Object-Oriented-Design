namespace Prototype.Developers;

using System;
using System.Collections.Generic;

public class Developer : ICloneable
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public List<string> Skills { get; set; } = new List<string>();

    public object Clone()
    {
        // return this.DeepCopy();


        return this.ShallowCopy();
    }

    private Developer DeepCopy()
    {
        var clone = this.MemberwiseClone() as Developer 
                    ?? throw new InvalidOperationException(
                        $"Can't clone {this.GetType().Name}");

        clone.Skills = new List<string>();

        foreach (var skill in this.Skills)   
        {
            clone.Skills.Add(skill);
        }
        
        return clone;
    }

    // The MemberwiseClone method creates a shallow copy by creating a new object,
    // and then copying the nonstatic fields of the current object to the new object.
    private object ShallowCopy()
        => this.MemberwiseClone();
}