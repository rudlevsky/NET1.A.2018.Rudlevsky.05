using System;
using NUnit.Framework;

namespace PolynomOperations.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(new double[] { 1.2, 0.12, 3 }, ExpectedResult = "1.2 0.12 3")]
        public string MethodToString_DoubleArray_StringRepresentation(double[] array) =>
            new Polynomial(array).ToString();
        

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, ExpectedResult = true)]
        public bool MethodEquals_DoubleArrays_CorrectResultTrue(double[] array1, double[] array2)
        {
            var obj1 = new Polynomial(array1);
            var obj2 = new Polynomial(array2);

            return obj1.Equals(obj2);
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 45, 3 }, ExpectedResult = false)]
        public bool MethodEquals_DoubleArrays_CorrectResultFalse(double[] array1, double[] array2)
        {
            var obj1 = new Polynomial(array1);
            var obj2 = new Polynomial(array2);

            return obj1.Equals(obj2);
        }

        [TestCase(new double[] { 1, 2, 3 }, ExpectedResult = true)]
        public bool MethodTheSame_DoubleArray_CorrectResultTrue(double[] array1)
        {
            var obj1 = new Polynomial(array1);
            var obj2 = obj1;

            return obj1 == obj2;
        }

        [TestCase(new double[] { 1, 2, 3 }, ExpectedResult = false)]
        public bool MethodTheSame_DoubleArray_CorrectResultFalse(double[] array1)
        {
            var obj1 = new Polynomial(array1);
            var obj2 = new Polynomial(array1);

            return obj1 == obj2;
        }

        [TestCase(new double[] { 1, 2, 3 }, ExpectedResult = true)]
        public bool MethodNotTheSame_DoubleArray_CorrectResultTrue(double[] array1)
        {
            var obj1 = new Polynomial(array1);
            var obj2 = new Polynomial(array1);

            return obj1 != obj2;
        }

        [TestCase(new double[] { 1, 2, 3 }, ExpectedResult = false)]
        public bool MethodNotTheSame_DoubleArray_CorrectResultFalse(double[] array1)
        {
            var obj1 = new Polynomial(array1);
            var obj2 = obj1;

            return obj1 != obj2;
        }

        [Test]
        public void MethodAdd_TwoObjects_ReturnNewCorrectObject()
        {
            double[] array1 = new double[] { 1, 2, 3 };
            double[] arrayResult = new double[] { 2, 4, 6};

            var obj1 = new Polynomial(array1);
            var obj2 = new Polynomial(array1);

            var objResult = obj1 + obj2;

            CollectionAssert.AreEqual(arrayResult,objResult.GetArray());
        }

        [Test]
        public void MethodSubstract_TwoObjects_ReturnNewCorrectObject()
        {
            double[] array1 = new double[] { 1, 2, 3 };
            double[] array2 = new double[] { 1, 2 };
            double[] arrayResult = new double[] { 0, 0, 3 };

            var obj1 = new Polynomial(array1);
            var obj2 = new Polynomial(array2);

            var objResult = obj1 - obj2;

            CollectionAssert.AreEqual(arrayResult, objResult.GetArray());
        }

        [Test]
        public void MethodMultiply_TwoObjects_ReturnNewCorrectObject()
        {
            double[] array1 = new double[] { 1, 2, 3 };
            double[] array2 = new double[] { 1, 2 ,4};
            double[] arrayResult = new double[] { 1, 4, 12 };

            var obj1 = new Polynomial(array1);
            var obj2 = new Polynomial(array2);

            var objResult = obj1 * obj2;

            CollectionAssert.AreEqual(arrayResult, objResult.GetArray());
        }

        [Test]
        public void PolynomialConstructor_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Polynomial(null));
        }

        [Test]
        public void PolynomialConstructor_ZeroArrayLength_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Polynomial(new double[] { }));
        }

        [Test]
        public void MethodEquals_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Polynomial(new double[] { 1,2 }).Equals(null));
        }
    }
}
