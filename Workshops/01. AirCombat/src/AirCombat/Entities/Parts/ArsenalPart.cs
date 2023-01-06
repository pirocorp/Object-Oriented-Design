namespace AirCombat.Entities.Parts;

using System;
using Contracts;

public class ArsenalPart : Part, IAttackModifyingPart
{
    private readonly int attackModifier;

    public ArsenalPart(string model, double weight, decimal price, int modifier) 
        : base(model, weight, price)
    {
        this.AttackModifier = modifier;
    }

    public int AttackModifier
    {
        get => this.attackModifier;
        private init
        {
            if (value < 0)
            {
                throw new ArgumentException("Attack Modifier cannot be less than zero!");
            }

            this.attackModifier = value;
        }
    }

    public override string ToString()
        => base.ToString() + $"+{this.AttackModifier} Attack";
}
