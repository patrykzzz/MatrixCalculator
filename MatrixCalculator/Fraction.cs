using System;
using System.Runtime.InteropServices;

namespace MatrixCalculator
{
    public class Fraction
    {
        public long Numeral { get; }
        public long Denominator { get; }

        public Fraction(Fraction fraction)
        {
            Numeral = fraction.Numeral;
            Denominator = fraction.Denominator;
        }

        public Fraction(long numeral, long denominator)
        {
            var fraction = ReduceFraction(numeral, denominator);   

            Numeral = fraction.numeral;
            Denominator = fraction.denominator;
        }

        public override string ToString()
        {
            //return Numeral + "/" + Denominator;
            return (Convert.ToDouble(Numeral) / Convert.ToDouble(Denominator)).ToString();
        }

        public static Fraction operator +(Fraction x, Fraction y)
        {
            return new Fraction(Add(x, y));
        }

        public static Fraction operator -(Fraction x, Fraction y)
        {
            return new Fraction(Subtract(x, y));
        }

        public static Fraction operator /(Fraction x, Fraction y)
        {
            return new Fraction(Divide(x, y));
        }

        public static Fraction operator *(Fraction x, Fraction y)
        {
            return new Fraction(Multiply(x, y));
        }

        public static Fraction operator +(Fraction x, long num)
        {
            var y = new Fraction(num, 1);
            return new Fraction(Add(x, y));
        }

        public static Fraction operator -(Fraction x, long num)
        {
            var y = new Fraction(num, 1);
            return new Fraction(Subtract(x, y));
        }

        public static Fraction operator /(Fraction x, long num)
        {
            var y = new Fraction(num, 1);
            return new Fraction(Divide(x, y));
        }

        public static Fraction operator *(Fraction x, long num)
        {
            var y = new Fraction(num, 1);
            return new Fraction(Multiply(x, y));
        }

        private static Fraction Add(Fraction first, Fraction second)
        {
            var a = first.Numeral * second.Denominator + second.Numeral * first.Denominator;
            var b = first.Denominator * second.Denominator;

            var fraction = ReduceFraction(a, b);

            return GetFractionSign(fraction.numeral, fraction.denominator);
        }

        private static Fraction Subtract(Fraction first, Fraction second)
        {
            var a = first.Numeral * second.Denominator - second.Numeral * first.Denominator;
            var b = first.Denominator * second.Denominator;

            var fraction = ReduceFraction(a, b);

            return GetFractionSign(fraction.numeral, fraction.denominator);
        }

        private static Fraction Multiply(Fraction first, Fraction second)
        {
            var a = first.Numeral * second.Numeral;
            var b = first.Denominator * second.Denominator;

            var fraction = ReduceFraction(a, b);

            return GetFractionSign(fraction.numeral, fraction.denominator);
        }

        private static Fraction Divide(Fraction first, Fraction second)
        {
            var a = first.Numeral * second.Denominator;
            var b = first.Denominator * second.Numeral;

            var fraction = ReduceFraction(a, b);

            return GetFractionSign(fraction.numeral, fraction.denominator);
        }

        private static Fraction GetFractionSign(long first, long second)
        {
            if (first < 0 && second < 0 || first > 0 && second < 0)
                return new Fraction(-first, -second);
            return new Fraction(first, second);
        }

        private static long GreatestCommonDivisor(long a, long b)
        {
            while (b != 0)
            {
                long tmp = b;
                b = a % b;
                a = tmp;
            }
            return a;
        }

        public static (long numeral, long denominator) ReduceFraction(long numeral, long denominator)
        {
            long gcd;
            while ((gcd = GreatestCommonDivisor(numeral, denominator)) != 1)
            {
                numeral /= gcd;
                denominator /= gcd;
            }

            return (numeral, denominator);
        }
    }
}
