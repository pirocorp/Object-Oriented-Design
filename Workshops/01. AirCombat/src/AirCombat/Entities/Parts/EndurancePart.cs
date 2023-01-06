namespace AirCombat.Entities.Parts;

using System;
using Contracts;

public class EndurancePart : Part, IHitPointsModifyingPart
{
    private readonly int hitPointsModifier;

    public EndurancePart(string model, double weight, decimal price, int modifier) 
        : base(model, weight, price)
    {
        this.HitPointsModifier = modifier;
    }

    public int HitPointsModifier
    {
        get => this.hitPointsModifier;
        private init
        {
            if (value < 0)
            {
                throw new ArgumentException("Hit Points Modifier cannot be less than zero!");
            }

            this.hitPointsModifier = value;
        }
    }

    public override string ToString()
        => base.ToString() + $"+{this.HitPointsModifier} HitPoints";
}
