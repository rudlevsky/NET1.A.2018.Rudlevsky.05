﻿using System;
using System.Text;

namespace PolynomOperations
{
    /// <summary>
    /// Class contains polynomial coefficients.
    /// </summary>
    public sealed class Polynomial: ICloneable, IEquatable<Polynomial>
    {
        /// <summary>
        /// Array of coefficients.
        /// </summary>
        private readonly double[] arrayCoef = {};
        private static double delta = 0.1;

        /// <summary>
        /// Method creates a copy of the current object.
        /// </summary>
        /// <returns>Copy of the current object.</returns>
        public Polynomial Clone()
        {
            return new Polynomial(GetArray());
        }

        /// <summary>
        /// Method creates a copy of the current object.
        /// </summary>
        /// <returns>Copy of the current object.</returns>
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Checks if object is equal to the current instance.
        /// </summary>
        /// <param name="other">Other object for comparison.</param>
        /// <returns>Result of comparison.</returns>
        public bool Equals(Polynomial other)
        {
            if (this == other)
            {
                return true;
            }

            if (Equals(other as object))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Constructor for array initialization.
        /// </summary>
        /// <param name="arrayIndex">User's array.</param>
        public Polynomial(params double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array) + " can't be equal to null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array) + " length can't be equal to 0.");
            }

            arrayCoef = new double[array.Length];

            array.CopyTo(arrayCoef, 0);
        }

        /// <summary>
        /// Add object's arrays.
        /// </summary>
        /// <param name="obj1">First object for adding.</param>
        /// <param name="obj2">Second object for adding.</param>
        /// <returns>Object with new data.</returns>
        public static Polynomial operator +(Polynomial obj1, Polynomial obj2)
        {
            CheckException(obj1);
            CheckException(obj2);

            double[] polBig = obj1.GetArray();
            double[] polSmall = obj2.GetArray();
            
            if (polBig.Length < polSmall.Length)
            {
                ArraySwap(ref polBig, ref polSmall);
            }
            
            for (int i = 0; i < polSmall.Length; i++)
            {
                polBig[i] += polSmall[i];
            }

            return new Polynomial(polBig);
        }

        /// <summary>
        /// Substract object's arrays.
        /// </summary>
        /// <param name="obj1">First object for substraction.</param>
        /// <param name="obj2">Second object for substraction.</param>
        /// <returns>Object with new data.</returns>
        public static Polynomial operator -(Polynomial obj1, Polynomial obj2)
        {
            CheckException(obj1);
            CheckException(obj2);

            double[] polBig = obj1.GetArray();
            double[] polSmall = obj2.GetArray();

            if (polBig.Length < polSmall.Length)
            {
                ArraySwap(ref polBig, ref polSmall);
            }

            for (int i = 0; i < polSmall.Length; i++)
            {
                polBig[i] -= polSmall[i];
            }

            return new Polynomial(polBig);
        }

        /// <summary>
        /// Multiplies object's arrays.
        /// </summary>
        /// <param name="obj1">First object for multiplication.</param>
        /// <param name="obj2">Second object for multiplication.</param>
        /// <returns>Object with new data.</returns>
        public static Polynomial operator *(Polynomial obj1, Polynomial obj2)
        {
            CheckException(obj1);
            CheckException(obj2);

            double[] array1 = obj1.GetArray();
            double[] array2 = obj2.GetArray();

            double[] result = new double[array1.Length + array2.Length - 1];

            for (int i = 0; i < array1.Length; i++)
            {
                for (int j = 0; j < array2.Length; j++)
                {
                    result[i + j] += array1[i] + array2[j];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Method compares two objects.
        /// </summary>
        /// <param name="pol1">First object for comparison.</param>
        /// <param name="pol2">Second object for comparison.</param>
        /// <returns>Result of camparison.</returns>
        public static bool operator ==(Polynomial pol1, Polynomial pol2)
        {
            if (ReferenceEquals(pol1, pol2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method compares two objects.
        /// </summary>
        /// <param name="pol1">First object for comparison.</param>
        /// <param name="pol2">Second object for comparison.</param>
        /// <returns>Result of camparison.</returns>
        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            return !(pol1 == pol2);
        }

        /// <summary>
        /// Method produces string representation.
        /// </summary>
        /// <returns>String representation of the array.</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();

            for (int i = 0; i < arrayCoef.Length; i++)
            {
                builder.Append(arrayCoef[i].ToString() + " ");
            }
            builder.Remove(builder.Length - 1, 1);

            return builder.ToString();
        }

        /// <summary>
        /// Method compares two objects.
        /// </summary>
        /// <param name="obj">Object for comparison.</param>
        /// <returns>Result of the comparison.</returns>
        public override bool Equals(object obj)
        {
            var polyn = obj as Polynomial;

            if (polyn == null)
            {
                throw new ArgumentNullException(nameof(obj) + " can't be as Polynomial type.");
            }

            double[] polArray = polyn.GetArray();

            if (polArray.Length != arrayCoef.Length)
            {
                return false;
            }

            for (int i = 0; i < arrayCoef.Length; i++)
            {
                if (Math.Abs(arrayCoef[i] - polArray[i]) > delta)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Method gets hash code.
        /// </summary>
        /// <returns>Array's hash code.</returns>
        public override int GetHashCode()
        {
            return GetArray().Length;
        }

        /// <summary>
        /// Creates new array which contains elements from the current object.
        /// </summary>
        /// <returns>New array with object's elements.</returns>
        public double[] GetArray()
        {
            double[] array = new double[arrayCoef.Length];
            arrayCoef.CopyTo(array, 0);

            return array;
        }

        private static void CheckException(Polynomial polynom)
        {
            if (polynom == null)
            {
                throw new ArgumentNullException($"{nameof(polynom)} can't be equal to null.");
            }
        }

        private static void ArraySwap(ref double[] arrayBig, ref double[] arraySmall)
        {
            double[] arraySwap;

            arraySwap = arraySmall;
            arraySmall = arrayBig;
            arrayBig = arraySwap;
        }
    }
}
