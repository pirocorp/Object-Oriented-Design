namespace ValueObjectDemo;

using System.Collections.Generic;
using System.Linq;

public abstract class ValueObject : IValueObject<ValueObject>
{
    protected static bool EqualOperator(ValueObject? left, ValueObject? right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }

        return ReferenceEquals(left, right) || left!.Equals(right);
    }

    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        => !(EqualOperator(left, right));

    protected abstract IEnumerable<object?> GetEqualityComponents();

    public static bool operator ==(ValueObject one, ValueObject two)
        => EqualOperator(one, two);

    public static bool operator !=(ValueObject one, ValueObject two)
        => NotEqualOperator(one, two);

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != this.GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;

        return this
            .GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
        => this
            .GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
}
