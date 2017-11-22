using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.InteropServices;

namespace MatrixCalculator
{
    public class Fraction
    {
        public BigInteger Numeral { get; }
        public BigInteger Denominator { get; }

        public Fraction()
        {
            Numeral = 0;
            Denominator = 1;
        }
        public Fraction(Fraction fraction)
        {
            Numeral = fraction.Numeral;
            Denominator = fraction.Denominator;
        }

        public Fraction(BigInteger numeral, BigInteger denominator)
        {
            var fraction = ReduceFraction(numeral, denominator);   

            Numeral = fraction.numeral;
            Denominator = fraction.denominator;
        }

        public override string ToString()
        {
            //return Numeral + "/" + Denominator;
            double x = (double)Numeral / (double)Denominator;
            return x.ToString(CultureInfo.CurrentCulture);
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

        public static Fraction operator +(Fraction x, BigInteger num)
        {
            var y = new Fraction(num, 1);
            return new Fraction(Add(x, y));
        }

        public static Fraction operator -(Fraction x, BigInteger num)
        {
            var y = new Fraction(num, 1);
            return new Fraction(Subtract(x, y));
        }

        public static Fraction operator /(Fraction x, BigInteger num)
        {
            var y = new Fraction(num, 1);
            return new Fraction(Divide(x, y));
        }

        public static Fraction operator *(Fraction x, BigInteger num)
        {
            var y = new Fraction(num, 1);
            return new Fraction(Multiply(x, y));
        }

        public static bool operator >(Fraction x, Fraction y)
        {
            var firstFraction = (double) x.Numeral / (double) x.Denominator;
            var secFraction = (double) y.Numeral / (double) y.Denominator;
            if (firstFraction > secFraction)
                return true;
            else
                return false;
        }

        public static bool operator <(Fraction x, Fraction y)
        {
            var firstFraction = (double)x.Numeral / (double)x.Denominator;
            var secFraction = (double)y.Numeral / (double)y.Denominator;
            if (firstFraction < secFraction)
                return true;
            else
                return false;
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

        private static Fraction GetFractionSign(BigInteger first, BigInteger second)
        {
//            if (first < 0 && second < 0 || first > 0 && second < 0)
//                return new Fraction(-first, -second);
            return new Fraction(first, second);
        }

        private static BigInteger GreatestCommonDivisor(BigInteger a, BigInteger b)
        {
                        while (b != 0)
                        {
                            BigInteger tmp = b;
                            b = a % b;
                            a = tmp;
                        }

//            while (num != den)
//            {
//                if (num < den)
//                {
//                    den -= num;

//                }
//                else
//                {
//                    num -= den;
//                }
//            }
//
//            return num;

            return a;
        }

        public static (BigInteger numeral, BigInteger denominator) ReduceFraction(BigInteger numeral, BigInteger denominator)
        {
            if (numeral != 0)
            {
                BigInteger gcd;

                if (numeral < 0)
                {
                    numeral = -numeral;
                }
                if (denominator < 0)
                {
                    denominator = -denominator;
                }



                while ((gcd = GreatestCommonDivisor(numeral, denominator)) != 1)
                {
//                gcd = GreatestCommonDivisor(numeral, denominator);
                    if (gcd == 0)
                        gcd = 1;

                    numeral /= gcd;
                    denominator /= gcd;
                }
            }

            return (numeral, denominator);
        }
    }
}
