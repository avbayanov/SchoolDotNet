using NUnit.Framework;

namespace Vector.Tests
{
    [TestFixtureSource(typeof(VectorTestsData), "TwoVectorsData")]
    public class TwoVectorsTests
    {
        private readonly Vector vector1;
        private readonly Vector vector2;
        private readonly Vector sum;
        private readonly Vector oneSubtractTwo;
        private readonly Vector twoSubtractOne;
        private readonly double scalarProduct;

        public TwoVectorsTests(double[] vector1, double[] vector2, double[] sum, double[] oneSubtractTwo, double[] twoSubtractOne, double scalarProduct)
        {
            this.vector1 = new Vector(vector1);
            this.vector2 = new Vector(vector2);
            this.sum = new Vector(sum);
            this.oneSubtractTwo = new Vector(oneSubtractTwo);
            this.twoSubtractOne = new Vector(twoSubtractOne);
            this.scalarProduct = scalarProduct;
        }

        [Test]
        public void TestAdd()
        {
            // vector1.Add(vector2)
            var sum1 = new Vector(vector1);
            sum1.Add(vector2);

            Assert.AreEqual(sum1, sum);

            // vector2.Add(vector1)
            var sum2 = new Vector(vector2);
            sum2.Add(vector1);

            Assert.AreEqual(sum2, sum);
        }

        [Test]
        public void TestStaticAdd()
        {
            Assert.AreEqual(Vector.Add(vector1, vector2), sum);
            
            Assert.AreEqual(Vector.Add(vector2, vector1), sum);
        }

        [Test]
        public void TestSubtract()
        {
            // vector1.Subtract(vector2)
            var difference1 = new Vector(vector1);
            difference1.Subtract(vector2);

            Assert.AreEqual(difference1, oneSubtractTwo);

            // vector2.Subtract(vector1)
            var difference2 = new Vector(vector2);
            difference2.Subtract(vector1);

            Assert.AreEqual(difference2, twoSubtractOne);
        }

        [Test]
        public void TestStaticSubtract()
        {
            Assert.AreEqual(Vector.Subtract(vector1, vector2), oneSubtractTwo);

            Assert.AreEqual(Vector.Subtract(vector2, vector1), twoSubtractOne);
        }

        [Test]
        public void TestScalarProduct()
        {
            Assert.AreEqual(Vector.ScalarProduct(vector1, vector2), scalarProduct);
            
            Assert.AreEqual(Vector.ScalarProduct(vector2, vector1), scalarProduct);
        }
    }
}