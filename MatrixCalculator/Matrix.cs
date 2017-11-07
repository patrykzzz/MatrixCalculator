using System;

namespace MatrixCalculator
{
    public class Matrix<T> where T : struct
    {
        public static int NumberOfRows { get; set; }
        public static int NumberOfColumns { get; set; }

        public T[ , ] MatrixValues { get; set; }

        public Matrix(T[ ,] matrix)
        {
            MatrixValues = matrix;
            NumberOfRows = matrix.GetLength(0);
            NumberOfColumns = matrix.GetLength(1);
        }

        public Matrix(int numberOfRows, int numberOfColumns)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
        }

        private T[,] InitializeWithRandomNumbers()
        {
            var random = new Random();
            var matrix = new T[NumberOfRows, NumberOfColumns];
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    matrix[i, j] = (dynamic)random.Next(Int32.MinValue, Int32.MaxValue);
                }
            }
            return matrix;
        }

        public static Matrix<T> operator +(Matrix<T> i, Matrix<T> j)
        {
            return new Matrix<T>(Add(i, j));
        }

        public static T[ ,] Add(Matrix<T> a, Matrix<T> b)
        {
            var matrix = new T[NumberOfRows, NumberOfColumns];
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    matrix[i, j] = (dynamic)a.MatrixValues[i, j] + (dynamic)b.MatrixValues[i, j];
                }
            }
            return matrix;
        }
    }
}