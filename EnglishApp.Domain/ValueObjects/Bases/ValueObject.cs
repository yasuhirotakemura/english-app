namespace EnglishApp.Domain.ValueObjects.Bases;

public abstract class ValueObject<T> where T : ValueObject<T>
{
    public override bool Equals(object? obj)
    {
        if (obj is not T v)
        {
            return false;
        }

        return this.EqualsCore(v);
    }

    public static bool operator ==(ValueObject<T> vo1, ValueObject<T> vo2)
    {
        return Equals(vo1, vo2);
    }

    public static bool operator !=(ValueObject<T> vo1, ValueObject<T> vo2)
    {
        return !Equals(vo1, vo2);
    }

    protected abstract bool EqualsCore(T other);

    public override string ToString()
    {
        return base.ToString();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
