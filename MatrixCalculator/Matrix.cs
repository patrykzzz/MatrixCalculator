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

        public static Matrix<T> operator -(Matrix<T> i, Matrix<T> j)
        {
            return new Matrix<T>(Subtract(i, j));
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

        private static T[,] Subtract(Matrix<T> a, Matrix<T> b)
        {
            var numberOfRows = a.NumberOfRows;
            var numberOfColumns = a.NumberOfColumns;
            var matrix = new T[numberOfRows, numberOfColumns];
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    matrix[i, j] = (dynamic) a.MatrixValues[i, j] - (dynamic) b.MatrixValues[i, j];
                }
            }
            return matrix;
        }

        public T[] GaussWithoutChoise(Matrix<T> a, T[] vector)
        {
            T multiplier;
            T sum;

            T[] res = new T[a.NumberOfRows];

            for (int i = 0; i < a.NumberOfRows - 1; i++)
            {
                for (int j = i + 1; j < a.NumberOfRows; j++)
                {
                    multiplier = -(dynamic) a.MatrixValues[j, i] / (dynamic) a.MatrixValues[i, i];
                    for (int k = i + 1; k < a.NumberOfRows; k++)
                    {
                        a.MatrixValues[j, k] += multiplier * (dynamic) a.MatrixValues[i, k];
                    }
                    vector[j] += (dynamic) vector[i] * multiplier;
                }
            }
            
            for (int i = a.NumberOfRows - 1; i >= 0; i--)
            {
                sum = (dynamic) vector[i];
                for (int j = a.NumberOfRows - 1; j >= i + 1; j--)
                {
                    sum -= (dynamic) a.MatrixValues[i, j] * res[j];
                }
                res[i] = sum / (dynamic)a.MatrixValues[i, i];
            }

            return res;
        }
    }
}