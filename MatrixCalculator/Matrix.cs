using System;

namespace MatrixCalculator
{
    public class Matrix<T> where T : struct
    {
        public int NumberOfRows => MatrixValues.GetLength(0);
        public int NumberOfColumns => MatrixValues.GetLength(1);

        public T[ , ] MatrixValues { get; set; }

        public Matrix(T[ ,] matrix)
        {
            MatrixValues = matrix;
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

        public static Matrix<T> operator *(Matrix<T>i, Matrix<T> j)
        {
            return new Matrix<T>(Multiply(i, j));
        }

        private static T[,] Multiply(Matrix<T> a, Matrix<T> b)
        {
            var numberOfRows = a.NumberOfRows;
            var numberOfColumns = a.NumberOfColumns;
            var result = new T[a.NumberOfRows, a.NumberOfColumns];
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    result[i,j] = (dynamic)a.MatrixValues[i, j] * (dynamic)b.MatrixValues[i, j];
                }
            }
            return result;
        }

        private static T[,] Add(Matrix<T> a, Matrix<T> b)
        {
            var numberOfRows = a.NumberOfRows;
            var numberOfColumns = a.NumberOfColumns;
            var matrix = new T[numberOfRows, numberOfColumns];
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    matrix[i, j] = (dynamic)a.MatrixValues[i, j] + (dynamic)b.MatrixValues[i, j];
                }
            }
            return matrix;
        }
    }
}