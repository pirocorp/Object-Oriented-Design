namespace ValueObjectDemo;

public interface IValueObject<in T> where T : IValueObject<T>
{
    static abstract bool operator ==(T one, T two);

    static abstract bool operator !=(T one, T two);

    bool Equals(object? obj);

    int GetHashCode();
}