using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculator
{
    public class File<T>
    {
        public void WriteToFile(Matrix<T> matrix, int size, StreamWriter sw)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    sw.Write(matrix.MatrixValues[i, j] + " ");
                }
                sw.WriteLine();
            }
            sw.WriteLine();
        }

        public void WriteToFile(T[] vector, int size, StreamWriter sw)
        {
            for (int i = 0; i < size; i++)
            {
                sw.Write(vector[i] + " ");
            }
            sw.WriteLine();
        }

        public T[] FillVectorWithRandom(int size)
        {
            var vector = new T[size];
            var random = new Random();

            if (vector is double[] || vector is float[])
            {
                for (int i = 0; i < size; i++)
                {
                    vector[i] = (dynamic)random.NextDouble() * random.Next(Int32.MinValue, Int32.MaxValue);
                }
            }
            else if (vector is Fraction[])
            {
                for (int i = 0; i < size; i++)
                {
                    vector[i] = (dynamic)new Fraction(random.Next(Int32.MinValue, Int32.MaxValue), random.Next(Int32.MinValue, Int32.MaxValue));
                }
            }

            return vector;
        }
    }
}
