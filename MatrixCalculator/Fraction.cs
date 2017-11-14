using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculator
{
    public class Fraction
    {
        private long a; //numeral
        private long b; //denominator

        public Fraction(Fraction fraction)
        {
            a = fraction.a;
            b = fraction.b;
        }

        public Fraction(long a, long b)
        {
<<<<<<< Updated upstream
            this.a = a;
            this.b = b;
=======
            var gcd = GreatestCommonDivisor(numeral, denominator);

            numeral /= gcd;
            denominator /= gcd;

            Numeral = numeral;
            Denominator = denominator;
>>>>>>> Stashed changes
        }

        public string Show()
        {
            return a + "/" + b;
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
            return new Fraction(Multiple(x, y));
        }

        public static Fraction operator +(Fraction x, long num)
        {
            Fraction y = new Fraction(num, 1);
            return new Fraction(Add(x, y));
        }

        public static Fraction operator -(Fraction x, long num)
        {
            Fraction y = new Fraction(num, 1);
            return new Fraction(Subtract(x, y));
        }

        public static Fraction operator /(Fraction x, long num)
        {
            Fraction y = new Fraction(num, 1);
            return new Fraction(Divide(x, y));
        }

        public static Fraction operator *(Fraction x, long num)
        {
            Fraction y = new Fraction(num, 1);
            return new Fraction(Multiple(x, y));
        }

        private static Fraction Add(Fraction fst, Fraction sec)
        {
            long a = (fst.a * sec.b) + (sec.a * fst.b);
            long b = fst.b * sec.b;

<<<<<<< Updated upstream
            return CheckSign(a, b);
=======
            var gcd = GreatestCommonDivisor(a, b);

            a /= gcd;
            b /= gcd;

            return GetFractionSign(a, b);
>>>>>>> Stashed changes
        }

        private static Fraction Subtract(Fraction fst, Fraction sec)
        {
            long a = (fst.a * sec.b) - (sec.a * fst.b);
            long b = fst.b * sec.b;

<<<<<<< Updated upstream
            return CheckSign(a, b);
=======
            var gcd = GreatestCommonDivisor(a, b);

            a /= gcd;
            b /= gcd;

            return GetFractionSign(a, b);
>>>>>>> Stashed changes
        }

        private static Fraction Multiple(Fraction fst, Fraction sec)
        {
            long a = fst.a * sec.a;
            long b = fst.b * sec.b;

<<<<<<< Updated upstream
            return CheckSign(a, b);
=======
            var gcd = GreatestCommonDivisor(a, b);

            a /= gcd;
            b /= gcd;

            return GetFractionSign(a, b);
>>>>>>> Stashed changes
        }

        private static Fraction Divide(Fraction fst, Fraction sec)
        {
            long a = fst.a * sec.b;
            long b = fst.b * sec.a;

<<<<<<< Updated upstream
            return CheckSign(a, b);
=======
            var gcd = GreatestCommonDivisor(a, b);

            a /= gcd;
            b /= gcd;

            return GetFractionSign(a, b);
>>>>>>> Stashed changes
        }

        private static Fraction CheckSign(long fst, long sec)
        {
            if (fst < 0 && sec < 0 || fst > 0 && sec < 0)
                return new Fraction(-fst, -sec);
            else
                return new Fraction(fst, sec);
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
    }
}
