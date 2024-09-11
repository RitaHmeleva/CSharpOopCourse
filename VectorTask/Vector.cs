using System;

namespace VectorTask;

public class Vector
{
    private double[] _components;

    public Vector(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException(nameof(size), $"Size {size} should be > 0");
        }

        _components = new double[size];
    }

    public Vector(Vector vector)
    {
        if (vector._components.Length == 0)
        {
            throw new ArgumentException($"Size {vector.Size} should be > 0");
        }

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
            throw new ArgumentException(nameof(size), $"Size {size} should be > 0");
        }

        _components = new double[size];

        Array.Copy(components, _components, size < components.Length ? size : components.Length);
    }

    public int Size
    {
        get { return _components.Length; }
    }

    public override string ToString()
    {
        return $"{{{string.Join(", ", _components)}}}";
    }

    public void Sum(Vector vector)
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

    public void Difference(Vector vector)
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

    public void Product(double scalar)
    {
        for (int i = 0; i < Size; i++)
        {
            _components[i] *= scalar;
        }
    }

    public void Reversal()
    {
        for (int i = 0; i < Size; i++)
        {
            Product(-1);
        }
    }

    public double GetLength()
    {
        double squaresSum = 0;

        for (int i = 0; i < Size; i++)
        {
            squaresSum += _components[i] * _components[i];
        }

        return Math.Sqrt(squaresSum);
    }

    public double this[int index]
    {
        get
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("");
            }

            if (index > Size - 1)
            {
                throw new ArgumentOutOfRangeException("");
            }

            return _components[index];
        }

        set
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("");
            }

            if (index > Size - 1)
            {
                throw new ArgumentOutOfRangeException("");
            }

            _components[index] = value;
        }
    }

    public override int GetHashCode()
    {
        const int prime = 37;
        int hash = 1;

        foreach (int i in _components)
        {
            hash = (prime * hash + _components[i]).GetHashCode();
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
        Vector vector = new Vector(vector1);

        vector.Sum(vector2);

        return vector;
    }

    public static Vector GetDifference(Vector vector1, Vector vector2)
    {
        Vector vector = new Vector(vector1);

        vector.Difference(vector2);

        return vector;
    }

    public static Vector GetProduct(Vector vector1, Vector vector2)
    {
        double[] vectorProduct = new double[Math.Max(vector1.Size, vector2.Size)];

        if (vector1.Size >= vector2.Size)
        {
            for (int i = 0; i < vector2.Size; i++)
            {
                vectorProduct[i] += vector1._components[i] * vector2._components[i];
            }
        }

        if (vector1.Size < vector2.Size)
        {
            for (int i = 0; i < vector1.Size; i++)
            {
                vectorProduct[i] += vector1._components[i] * vector2._components[i];
            }
        }

        return new Vector(vectorProduct);
    }
}