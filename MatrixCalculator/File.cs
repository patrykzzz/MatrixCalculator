using System;
using System.IO;

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

        public double[] ReadVectorFromFile(string filename, int size, int multiple)
        {
            var vector = new double[size];
            StreamReader sr = new StreamReader("../../../" + filename + ".txt");

            string line = "";

            for (int i = 0; i < IgnorePreviousLines(size, multiple); i++)
            {
                line = sr.ReadLine();
            }
            line = sr.ReadLine();
            string[] splitLine = line.Split(' ');

            for (int j = 0; j < size; j++)
            {
                vector[j] = double.Parse(splitLine[j], System.Globalization.CultureInfo.InvariantCulture);
            }

            return vector;
        }

        public double[,] ReadDoubleMatrixFromFile(string filename, int size, int multiple)
        {
            double[,] matrix = new double[size, size];
            StreamReader sr = new StreamReader("../../../" + filename + ".txt");

            string line = "";

            for (int i = 0; i < IgnorePreviousLines(size, multiple); i++)
            {
                line = sr.ReadLine();
            }
            for (int i = 0; i < size; i++)
            {
                line = sr.ReadLine();
                string[] splitLine = line.Split(' ');

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = double.Parse(splitLine[j], System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            sr.Close();
            return matrix;
        }

        private int IgnorePreviousLines(int size, int multiple)
        {
            int ignore = 0;
            for (int i = 0; i < (size / multiple) - 1; i++)
            {
                ignore += multiple * (i + 1);
            }
            return ignore;
        }
    }
}
