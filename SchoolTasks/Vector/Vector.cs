using System;

namespace Vector
{
    public class Vector
    {
        private double[] components;

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Vector size must be > 0");
            }

            components = new double[size];
        }

        public Vector(Vector vector)
        {
            if (ReferenceEquals(vector, null))
            {
                throw new NullReferenceException("Vector must be not null");
            }

            components = new double[vector.GetSize()];
            vector.components.CopyTo(components, 0);
        }

        public Vector(double[] components)
        {
            if (components.Length == 0)
            {
                throw new ArgumentException("Vector size must be > 0");
            }

            this.components = new double[components.Length];
            components.CopyTo(this.components, 0);
        }

        public Vector(int size, double[] components)
        {
            if (size <= 0 || components.Length == 0)
            {
                throw new ArgumentException("Vector size must be > 0");
            }

            this.components = new double[size];

            Array.Copy(components, 0, this.components, 0, size);
        }

        public override string ToString()
        {
            return "{ " + String.Join(", ", components) + " }";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector vector = (Vector) obj;

            if (GetSize() != vector.GetSize())
            {
                return false;
            }

            for (int i = 0; i < components.Length; i++)
            {
                if (!components[i].Equals(vector.components[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 95;
            int hash = 1;

            foreach (double component in components)
            {
                hash += prime * hash + component.GetHashCode();
            }

            return hash;
        }

        public int GetSize()
        {
            return components.Length;
        }

        public void Add(Vector vector)
        {
            if (ReferenceEquals(vector, null))
            {
                throw new NullReferenceException("Vector must be not null");
            }

            if (vector.components.Length > components.Length)
            {
                Array.Resize(ref components, vector.GetSize());
            }

            for (int i = 0; i < vector.GetSize(); i++)
            {
                components[i] += vector.components[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (ReferenceEquals(vector, null))
            {
                throw new NullReferenceException("Vector must be not null");
            }

            if (vector.components.Length > components.Length)
            {
                Array.Resize(ref components, vector.GetSize());
            }

            for (int i = 0; i < vector.GetSize(); i++)
            {
                components[i] -= vector.components[i];
            }
        }

        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i] *= scalar;
            }
        }

        public void Reverse()
        {
            MultiplyByScalar(-1);
        }

        public double GetLength()
        {
            double squaredComponentsSum = 0;

            foreach (double component in components)
            {
                squaredComponentsSum += Math.Pow(component, 2);
            }

            return Math.Sqrt(squaredComponentsSum);
        }

        // Реализация "Получения и установка компоненты вектора по индексу" через методы
        public double GetComponent(int index)
        {
            if (index < 0 || index >= components.Length)
            {
                throw new IndexOutOfRangeException("Index must be >= 0 and < Vector.GetSize()");
            }

            return components[index];
        }

        public void SetComponent(int index, double component)
        {
            if (index < 0 || index >= components.Length)
            {
                throw new IndexOutOfRangeException("Index must be >= 0 and < Vector.GetSize()");
            }

            components[index] = component;
        }

        // Реализация "Получения и установка компоненты вектора по индексу" через свойства
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= components.Length)
                {
                    throw new IndexOutOfRangeException("Index must be >= 0 and < Vector.GetSize()");
                }

                return components[index];
            }

            set
            {
                if (index < 0 || index >= components.Length)
                {
                    throw new IndexOutOfRangeException("Index must be >= 0 and < Vector.GetSize()");
                }

                components[index] = value;
            }
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            if (ReferenceEquals(vector1, null))
            {
                throw new NullReferenceException("Vector1 must be not null");
            }

            if (ReferenceEquals(vector2, null))
            {
                throw new NullReferenceException("Vector2 must be not null");
            }

            Vector result = new Vector(vector1);
            result.Add(vector2);

            return result;
        }

        public static Vector Subtract(Vector vector1, Vector vector2)
        {
            if (ReferenceEquals(vector1, null))
            {
                throw new NullReferenceException("Vector1 must be not null");
            }

            if (ReferenceEquals(vector2, null))
            {
                throw new NullReferenceException("Vector2 must be not null");
            }

            Vector result = new Vector(vector1);
            result.Subtract(vector2);

            return result;
        }

        public static double ScalarProduct(Vector vector1, Vector vector2)
        {
            if (ReferenceEquals(vector1, null))
            {
                throw new NullReferenceException("Vector1 must be not null");
            }

            if (ReferenceEquals(vector2, null))
            {
                throw new NullReferenceException("Vector2 must be not null");
            }

            int minSize = Math.Min(vector1.GetSize(), vector2.GetSize());
            double multipliedPairsSum = 0;
            for (int i = 0; i < minSize; i++)
            {
                multipliedPairsSum += vector1.components[i] * vector2.components[i];
            }

            return multipliedPairsSum;
        }
    }
}