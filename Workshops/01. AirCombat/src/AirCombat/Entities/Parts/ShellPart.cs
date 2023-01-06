namespace AirCombat.Entities.Parts;

using System;
using Contracts;

public class ShellPart : Part, IDefenseModifyingPart
{
    private readonly int defenseModifier;

    public ShellPart(string model, double weight, decimal price, int modifier) 
        : base(model, weight, price)
    {
        this.DefenseModifier = modifier;
    }

    public int DefenseModifier
    {
        get => this.defenseModifier;
        private init
        {
            if (value < 0)
            {
                throw new ArgumentException("Defense Modifier cannot be less than zero!");
            }

            this.defenseModifier = value;
        }
    }

    public override string ToString()
        => base.ToString() + $"+{this.DefenseModifier} Defense";
}
