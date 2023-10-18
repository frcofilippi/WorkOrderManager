using System.ComponentModel;
using System.Net;

namespace WorkOrderManager.Domain.Model;

public abstract class ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object> GetEquialityComponents();

    protected static bool EqualOperator(ValueObject left, ValueObject rigth)
    {
        if(ReferenceEquals(left, null) ^ ReferenceEquals(rigth, null))
        {
            return false;
        } else {
            return ReferenceEquals(left,rigth) || left.Equals(rigth);
        }
    } 

    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
        return !EqualOperator(left,right);
    }

    public override bool Equals(object? obj)
    {
        if(obj == null || obj.GetType() != GetType())
        {
            return false;
        }
        var other = (ValueObject)obj;
        return this.GetEquialityComponents().SequenceEqual(other.GetEquialityComponents());
    }

    public override int GetHashCode()
    {
        return GetEquialityComponents().Select(x => x != null ? x.GetHashCode() : 0).Aggregate((x,y) => x ^ y);
    }

    public bool Equals(ValueObject? obj)
    {
        if(obj is null || obj.GetType() != GetType())
        {
            return false;
        }
        var other = (ValueObject)obj;
        return this.GetEquialityComponents().SequenceEqual(other.GetEquialityComponents());
    }

    public static bool operator ==(ValueObject left, ValueObject right) => EqualOperator(left, right);
    public static bool operator !=(ValueObject left, ValueObject right) => NotEqualOperator(left, right);
}




