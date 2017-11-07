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
            this.a = fraction.a;
            this.b = fraction.b;
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
            return null;
        }

        public static Fraction operator /(Fraction x, Fraction y)
        {
            return null;
        }

        public static Fraction operator *(Fraction x, Fraction y)
        {
            return null;
        }

        private static Fraction AddFraction(Fraction fst, Fraction sec)
        {
            long a = (fst.a * sec.b) + (sec.a * fst.b);
            long b = fst.b * sec.b;

            return new Fraction(a, b);
        }

        private static Fraction DeleteFraction(Fraction fst, Fraction sec)
        {
            long a = (fst.a * sec.b) - (sec.a * fst.b);
            long b = fst.b * sec.b;

            return new Fraction(a, b);
        }
    }
}
