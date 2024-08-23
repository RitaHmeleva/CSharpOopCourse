using System;

namespace VectorTask
{
    class Vector
    {
        private double[] _components;

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size " + size + " should be > 0");
            }

            _components = new double[size];
        }

        public Vector(Vector components)
        {
            if (components._components.Length <= 0)
            {
                throw new ArgumentException("Size " + components._components.Length + " should be > 0");
            }

            double[] arrayComponents = components._components;

            _components = arrayComponents;
        }

        public Vector(double[] components)
        {
            if (components.Length <= 0)
            {
                throw new ArgumentException("Size " + components.Length + " should be > 0");
            }

            _components = new double[components.Length];

            Array.Copy(components, 0, _components, 0, components.Length);
        }

        public Vector(int size, double[] components)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size n should be > 0");
            }

            _components = new double[size];

            if (components.Length < size)
            {
                Array.Copy(components, 0, _components, 0, components.Length);
            }
            else
            {
                Array.Copy(components, 0, _components, 0, size);
            }
        }

        public int GetSize
        {
            get { return _components.Length; }
        }

        public override string ToString()
        {
            return "{" + string.Join(", ", _components) + "}";
        }

        public void GetSum(Vector vector)
        {
            if (_components.Length < vector._components.Length)
            {
                Array.Resize(ref _components, vector._components.Length);
            }

            for (int i = 0; i < vector._components.Length; i++)
            {
                _components[i] += vector._components[i];
            }
        }

        public void GetDifference(Vector vector)
        {
            if (_components.Length < vector._components.Length)
            {
                Array.Resize(ref _components, vector._components.Length);
            }

            for (int i = 0; i < vector._components.Length; i++)
            {
                _components[i] -= vector._components[i];
            }
        }

        public void GetProduct(double scalar)
        {
            for (int i = 0; i < _components.Length; i++)
            {
                _components[i] *= scalar;
            }
        }

        public void GetReversal()
        {
            for (int i = 0; i < _components.Length; i++)
            {
                GetProduct(-1);
            }
        }

        public double GetLength()
        {
            double squaresSum = 0;

            for (int i = 0; i < _components.Length; i++)
            {
                squaresSum += _components[i] * _components[i];
            }

            return Math.Sqrt(squaresSum);
        }

        public double this[int index]
        {
            get
            {
                if (index <= 0)
                {
                    throw new ArgumentOutOfRangeException("");
                }
                return _components[index];
            }

            set
            {
                if (index <= 0)
                {
                    throw new ArgumentOutOfRangeException("");
                }
                _components[index] = value;
            }
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            for (int i = 0; i < _components.Length; i++)
            {
                hash = (int)(prime * hash + _components[i]);
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

            if (v._components.Length != _components.Length)
            {
                return false;
            }

            for (int i = 0; i < _components.Length; i++)
            {
                if (v._components[i] != _components[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static void GetSum(Vector vector1, Vector vector2)
        {
            vector1.GetSum(vector2);
        }

        public static void GetDifference(Vector vector1, Vector vector2)
        {
            vector1.GetDifference(vector2);
        }

        public static void GetProduct(Vector vector, double scalar)
        {
            vector.GetProduct(scalar);
        }
    }
}