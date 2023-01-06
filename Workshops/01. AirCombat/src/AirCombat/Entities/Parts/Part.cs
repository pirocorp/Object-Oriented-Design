namespace AirCombat.Entities.Parts;

using System;

using Contracts;

public abstract class Part : IPart
{
    private readonly string model = string.Empty;
    private readonly double weight;
    private readonly decimal price;

    protected Part(string model, double weight, decimal price)
    {
        this.Model = model;
        this.Weight = weight;
        this.Price = price;
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

    public override string ToString()
    {
        var partName = this.GetType().Name.Replace("Part", "");
        var result = $"{partName} Part - {this.Model}";

        return result;
    }
}