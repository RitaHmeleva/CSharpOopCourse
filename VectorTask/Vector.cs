using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    class Vector
    {
        private int size;
        private int[] vector;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Size n should be > 0");
            }

            vector = new int[n];
            size = n;

            for (int i = 0; i < n; i++)
            {
                vector[i] = 0;
            }
        }

        public Vector(Vector array)
        {
            vector = array.vector;

            size = array.size;
        }

        public Vector(int[] array)
        {
            vector = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                vector[i] = array[i];
            }

            size = array.Length;
        }

        public Vector(int n, int[] array)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Size n should be > 0");
            }

            vector = new int[n];

            if (array.Length < n)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    vector[i] = array[i];
                }

                for (int i = array.Length; i < n; i++)
                {
                    vector[i] = 0;
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    vector[i] = array[i];
                }
            }

            size = n;
        }

        public int GetSize()
        {
            return size;
        }

        public override string ToString()
        {
            return string.Join(", ", vector);
        }

        public Vector GetSum(Vector vector2)
        {
            int[] vectorSum = new int[Math.Max(size, vector2.size)];

            if (size >= vector2.size)
            {
                Vector vec = new Vector(size, vector2.vector);

                for (int i = 0; i < size; i++)
                {
                    vectorSum[i] = vector[i] + vec.vector[i];
                }
            }

            if (size < vector2.size)
            {
                Vector vec = new Vector(vector2.size, vector);

                for (int i = 0; i < vector2.size; i++)
                {
                    vectorSum[i] = vec.vector[i] + vector2.vector[i];
                }
            }

            return new Vector(vectorSum);
        }

        public Vector GetDifference(Vector vector2)
        {
            int[] vectorDifference = new int[Math.Max(size, vector2.size)];

            if (size >= vector2.size)
            {
                Vector vec = new Vector(size, vector2.vector);

                for (int i = 0; i < size; i++)
                {
                    vectorDifference[i] = vector[i] + vec.vector[i];
                }
            }

            if (size < vector2.size)
            {
                Vector vec = new Vector(vector2.size, vector);

                for (int i = 0; i < vector2.size; i++)
                {
                    vectorDifference[i] = vec.vector[i] + vector2.vector[i];
                }
            }

            return new Vector(vectorDifference);
        }

        public Vector GetProduct(Vector vector2)
        {
            int[] vectorProduct = new int[Math.Max(size, vector2.size)];

            if (size >= vector2.size)
            {
                Vector vec = new Vector(size, vector2.vector);

                for (int i = 0; i < size; i++)
                {
                    vectorProduct[i] = vector[i] + vec.vector[i];
                }
            }

            if (size < vector2.size)
            {
                Vector vec = new Vector(vector2.size, vector);

                for (int i = 0; i < vector2.size; i++)
                {
                    vectorProduct[i] = vec.vector[i] + vector2.vector[i];
                }
            }

            return new Vector(vectorProduct);
        }

        public Vector GetRiversal()
        {
            int[] vectorRiversal = new int[size];

            for (int i = 0; i < size; i++)
            {
                vectorRiversal[i] = this.vector[i] * -1;
            }

            return new Vector(vectorRiversal);
        }
        public double GetLength()
        {
            double squaresSum = 0;

            for (int i = 0; i < size; i++)
            {
                squaresSum += Math.Pow(vector[i], 2);
            }

            return Math.Sqrt(squaresSum);
        }

        public int? GetComponent(int index)
        {
            if (index < size)
            {
                return vector[index];
            }

            return null;
        }

        public Vector SetComponent(int index, int component)
        {
            if (index < size)
            {
                int[] vectorRiversal = vector;

                vectorRiversal[index] = component;

                return new Vector(vectorRiversal);
            }

            return new Vector(vector);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            for (int i = 0; i < size; i++)
            {
                hash = prime * hash + vector[i];
            }

            return hash;
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }

            if (ReferenceEquals(o, null) || o.GetType() != GetType())
            {
                return false;
            }

            Vector v = (Vector)o;

            if (v.size == size)
            {
                for (int i = 0; i < size; i++)
                {
                    if (v.vector[i] != vector[i])
                    {
                        return false;
                    }
                }
            }

            return vector == v.vector;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            int[] vectorSum = new int[Math.Max(vector1.size, vector2.size)];

            if (vector1.size >= vector2.size)
            {
                Vector vec = new Vector(vector1.size, vector2.vector);

                for (int i = 0; i < vector1.size; i++)
                {
                    vectorSum[i] = vector1.vector[i] + vec.vector[i];
                }
            }

            if (vector1.size < vector2.size)
            {
                Vector vec = new Vector(vector2.size, vector1.vector);

                for (int i = 0; i < vector2.size; i++)
                {
                    vectorSum[i] = vec.vector[i] + vector2.vector[i];
                }
            }

            return new Vector(vectorSum);
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            int[] vectorDifference = new int[Math.Max(vector1.size, vector2.size)];

            if (vector1.size >= vector2.size)
            {
                Vector vec = new Vector(vector1.size, vector2.vector);

                for (int i = 0; i < vector1.size; i++)
                {
                    vectorDifference[i] = vector1.vector[i] + vec.vector[i];
                }
            }

            if (vector1.size < vector2.size)
            {
                Vector vec = new Vector(vector2.size, vector1.vector);

                for (int i = 0; i < vector2.size; i++)
                {
                    vectorDifference[i] = vec.vector[i] + vector2.vector[i];
                }
            }

            return new Vector(vectorDifference);
        }

        public static Vector GetProduct(Vector vector1, Vector vector2)
        {
            int[] vectorProduct = new int[Math.Max(vector1.size, vector2.size)];

            if (vector1.size >= vector2.size)
            {
                Vector vec = new Vector(vector1.size, vector2.vector);

                for (int i = 0; i < vector1.size; i++)
                {
                    vectorProduct[i] = vector1.vector[i] + vec.vector[i];
                }
            }

            if (vector1.size < vector2.size)
            {
                Vector vec = new Vector(vector2.size, vector1.vector);

                for (int i = 0; i < vector2.size; i++)
                {
                    vectorProduct[i] = vec.vector[i] + vector2.vector[i];
                }
            }

            return new Vector(vectorProduct);
        }
    }
}