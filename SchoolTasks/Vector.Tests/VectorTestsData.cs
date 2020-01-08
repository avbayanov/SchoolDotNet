using System.Collections;
using NUnit.Framework;

namespace Vector.Tests
{
    public class VectorTestsData
    {
        public static IEnumerable TwoVectorsData
        {
            get
            {
                yield return new TestFixtureData(
                    new double[] { 1, 2, 3, 4, 5 }, // vector1
                    new double[] { 5, 4, 3, 2, 1 }, // vector2
                    new double[] { 6, 6, 6, 6, 6 }, // sum
                    new double[] { -4, -2, 0, 2, 4 }, // vector1 - vector2
                    new double[] { 4, 2, 0, -2, -4 }, // vector2 - vector1
                    35 // scalar product
                );

                yield return new TestFixtureData(
                    new double[] { 1, 2, 3, 4, 5 },
                    new double[] { 5 },
                    new double[] { 6, 2, 3, 4, 5 },
                    new double[] { -4, 2, 3, 4, 5 },
                    new double[] { 4, -2, -3, -4, -5 },
                    5
                );

                yield return new TestFixtureData(
                    new double[] { 1 },
                    new double[] { 5, 4, 3, 2, 1 },
                    new double[] { 6, 4, 3, 2, 1 },
                    new double[] { -4, -4, -3, -2, -1 },
                    new double[] { 4, 4, 3, 2, 1 },
                    5
                );
            }
        }
    }
}