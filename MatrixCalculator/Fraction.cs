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
            this.a = a;
            this.b = b;
        }

        public string Show()
        {
            return a + "/" + b;
        }

        public static Fraction operator +(Fraction x, Fraction y)
        {
            return new Fraction(AddFraction(x, y));
        }

        public static Fraction operator -(Fraction x, Fraction y)
        {
            return new Fraction(SubtractFraction(x, y));
        }

        public static Fraction operator /(Fraction x, Fraction y)
        {
            return new Fraction(DivideFraction(x, y));
        }

        public static Fraction operator *(Fraction x, Fraction y)
        {
            return new Fraction(MultipleFraction(x, y));
        }

        private static Fraction AddFraction(Fraction fst, Fraction sec)
        {
            long a = (fst.a * sec.b) + (sec.a * fst.b);
            long b = fst.b * sec.b;

            return CheckSign(a, b);
        }

        private static Fraction SubtractFraction(Fraction fst, Fraction sec)
        {
            long a = (fst.a * sec.b) - (sec.a * fst.b);
            long b = fst.b * sec.b;

            return CheckSign(a, b);
        }

        private static Fraction MultipleFraction(Fraction fst, Fraction sec)
        {
            long a = fst.a * sec.a;
            long b = fst.b * sec.b;

            return CheckSign(a, b);
        }

        private static Fraction DivideFraction(Fraction fst, Fraction sec)
        {
            long a = fst.a * sec.b;
            long b = fst.b * sec.a;

            return CheckSign(a, b);
        }

        private static Fraction CheckSign(long fst, long sec)
        {
            if (fst < 0 && sec < 0 || fst > 0 && sec < 0)
                return new Fraction(-fst, -sec);
            else
                return new Fraction(fst, sec);
        }
    }
}
