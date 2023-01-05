namespace ArdalisRating.Core.Policies;

using System;
using ArdalisRating.Core.Model;

public class LifePolicy : Policy
{
    public LifePolicy(
        string fullName,
        DateTime dateOfBirth,
        bool isSmoker,
        decimal amount)
        : base(PolicyType.Life)
    {
        this.FullName = fullName;
        this.DateOfBirth = dateOfBirth;
        this.IsSmoker = isSmoker;
        this.Amount = amount;
    }

    public string FullName { get; }

    public DateTime DateOfBirth { get; }

    public bool IsSmoker { get; }

    public decimal Amount { get; }
}
