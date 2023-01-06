namespace AirCombat.Entities.AirCrafts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AirCombat.Entities.AirCrafts.Contracts;
using AirCombat.Entities.Miscellaneous.Contracts;
using AirCombat.Entities.Parts.Contracts;

public abstract class AirCraft : IAirCraft
{
    private readonly double weight;
    private readonly decimal price;
    private readonly int attack;
    private readonly int defense;
    private readonly int hitPoints;
    private readonly string model = string.Empty;

    private readonly IAssembler assembler;
    private readonly IList<string> orderedParts;

    protected AirCraft(
        string model,
        double weight,
        decimal price, 
        int attack,
        int defense,
        int hitPoints, 
        IAssembler assembler)
    {
        this.Model = model;
        this.Weight = weight;
        this.Price = price;
        this.Attack = attack;
        this.Defense = defense;
        this.HitPoints = hitPoints;
        this.assembler = assembler;
        this.orderedParts = new List<string>();
    }

    public string Model
    {
        get => this.model;
        private init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Model cannot be null or white space!");
            }

            this.model = value;
        }
    }

    public double Weight
    {
        get => this.weight;
        private init
        {
            if (value <= 0)
            {
                throw new ArgumentException("Weight cannot be less or equal to zero!");
            }

            this.weight = value;
        }
    }

    public decimal Price
    {
        get => this.price;
        private init
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price cannot be less or equal to zero!");
            }

            this.price = value;
        }
    }

    public int Attack
    {
        get => this.attack;
        private init
        {
            if (value < 0)
            {
                throw new ArgumentException("Attack cannot be less than zero!");
            }

            this.attack = value;
        }
    }

    public int Defense
    {
        get => this.defense;
        private init
        {
            if (value < 0)
            {
                throw new ArgumentException("Defense cannot be less than zero!");
            }

            this.defense = value;
        }
    }

    public int HitPoints
    {
        get => this.hitPoints;
        private init
        {
            if (value < 0)
            {
                throw new ArgumentException("HitPoints cannot be less than zero!");
            }

            this.hitPoints = value;
        }
    }

    public double TotalWeight
        => this.weight + this.assembler.TotalWeight;

    public decimal TotalPrice
        => this.price + this.assembler.TotalPrice;

    public long TotalAttack 
        => this.attack + this.assembler.TotalAttackModification;

    public long TotalDefense 
        => this.defense + this.assembler.TotalDefenseModification;

    public long TotalHitPoints 
        => this.hitPoints + this.assembler.TotalHitPointModification;

    public void AddArsenalPart(IPart arsenalPart)
    {
        this.orderedParts.Add(arsenalPart.Model);
        this.assembler.AddArsenalPart(arsenalPart);
    }

    public void AddShellPart(IPart shellPart)
    {
        this.orderedParts.Add(shellPart.Model);
        this.assembler.AddShellPart(shellPart);
    }

    public void AddEndurancePart(IPart endurancePart)
    {
        this.orderedParts.Add(endurancePart.Model);
        this.assembler.AddEndurancePart(endurancePart);
    }

    public IEnumerable<IPart> Parts
    {
        get
        {
            var parts = new List<IPart>();

            parts.AddRange(this.assembler.ArsenalParts);
            parts.AddRange(this.assembler.ShellParts);
            parts.AddRange(this.assembler.EnduranceParts);

            return parts;
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        result.AppendLine($"{this.GetType().Name} - {this.Model}");
        result.AppendLine($"Total Weight: {this.TotalWeight:F3}");
        result.AppendLine($"Total Price: {this.TotalPrice:F3}");
        result.AppendLine($"Attack: {this.TotalAttack}");
        result.AppendLine($"Defense: {this.TotalDefense}");
        result.AppendLine($"HitPoints: {this.TotalHitPoints}");

        result.Append("Parts: ");

        var partsString = new StringBuilder();

        this.orderedParts
            .ToList()
            .ForEach(x => partsString.Append(x).Append(", "));

        if (partsString.Length > 0)
        {
            var textToAppend = partsString
                .ToString()
                .Substring(0, partsString.Length - 2);

            result.Append(textToAppend);
        }
        else
        {
            result.Append("None");
        }

        return result.ToString();
    }
}
