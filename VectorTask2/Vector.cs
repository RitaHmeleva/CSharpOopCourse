namespace VectorTask;

public class Vector
{
    private double[] _components;

    public Vector(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException($"Size {size} should be > 0", nameof(size));
        }

        _components = new double[size];
    }

    public Vector(Vector vector)
    {
        _components = new double[vector.Size];
        Array.Copy(vector._components, _components, Size);
    }

    public Vector(double[] components)
    {
        if (components.Length == 0)
        {
            throw new ArgumentException($"Size {components.Length} should be > 0");
        }

        _components = new double[components.Length];

        Array.Copy(components, 0, _components, 0, components.Length);
    }

    public Vector(int size, double[] components)
    {
        if (size <= 0)
        {
            throw new ArgumentException($"Size {size} should be > 0", nameof(size));
        }

        _components = new double[size];

        Array.Copy(components, _components, Math.Min(size, components.Length));
    }

    public int Size
    {
        get => _components.Length;
    }

    public override string ToString()
    {
        return $"{{{string.Join(", ", _components)}}}";
    }

    public void CalculateSum(Vector vector)
    {
        if (Size < vector.Size)
        {
            Array.Resize(ref _components, vector.Size);
        }

        for (int i = 0; i < vector.Size; i++)
        {
            _components[i] += vector._components[i];
        }
    }

    public void CalculateDifference(Vector vector)
    {
        if (Size < vector.Size)
        {
            Array.Resize(ref _components, vector.Size);
        }

        for (int i = 0; i < vector.Size; i++)
        {
            _components[i] -= vector._components[i];
        }
    }

    public void CalculateProduct(double scalar)
    {
        for (int i = 0; i < Size; i++)
        {
            _components[i] *= scalar;
        }
    }

    public void CalculateReversal()
    {
        CalculateProduct(-1);
    }

    public double GetLength()
    {
        double squaresSum = 0;

        foreach (double component in _components)
        {
            squaresSum += component * component;
        }

        return Math.Sqrt(squaresSum);
    }

    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"index should be between 0 and {Size - 1}");
            }

            return _components[index];
        }

        set
        {
            if (index < 0 || index >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"index should be between 0 and {Size - 1}");
            }

            _components[index] = value;
        }
    }

    public override int GetHashCode()
    {
        const int prime = 37;
        int hash = 1;

        foreach (double component in _components)
        {
            hash = prime * hash + component.GetHashCode();
        }

        return hash;
    }

    public override bool Equals(object o)
    {
        if (ReferenceEquals(o, this))
        {
            return true;
        }

        if (o is null || o.GetType() != GetType())
        {
            return false;
        }

        Vector v = (Vector)o;

        if (v.Size != Size)
        {
            return false;
        }

        for (int i = 0; i < Size; i++)
        {
            if (v._components[i] != _components[i])
            {
                return false;
            }
        }

        return true;
    }

    public static Vector GetSum(Vector vector1, Vector vector2)
    {
        Vector sumVector = new Vector(vector1);

        sumVector.CalculateSum(vector2);

        return sumVector;
    }

    public static Vector GetDifference(Vector vector1, Vector vector2)
    {
        Vector differenceVector = new Vector(vector1);

        differenceVector.CalculateDifference(vector2);

        return differenceVector;
    }

    public static double GetScalarProduct(Vector vector1, Vector vector2)
    {
        double scalarProduct = 0;

        for (int i = 0; i < Math.Min(vector1.Size, vector2.Size); i++)
        {
            scalarProduct += vector1._components[i] * vector2._components[i];
        }

        return scalarProduct;
    }
}