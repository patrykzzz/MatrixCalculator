using System;
using System.Linq;

namespace MatrixCalculator
{
    public class Matrix<T>
    {
        public int NumberOfRows => MatrixValues.GetLength(0);
        public int NumberOfColumns => MatrixValues.GetLength(1);

        public T[,] MatrixValues { get; set; }

        public Matrix(T[,] matrix)
        {
            MatrixValues = matrix;
        }

        public Matrix(int rows, int columns)
        {
            MatrixValues = InitializeWithRandomNumbers(rows, columns);
        }

        private T[,] InitializeWithRandomNumbers(int rows, int columns)
        {
            var random = new Random();
            var matrix = new T[rows, columns];

            if (matrix is double[,] || matrix is float[,])
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i, j] = (dynamic)random.NextDouble() * random.Next(Int32.MinValue, Int32.MaxValue);
                    }
                }
            }
            else if (matrix is Fraction[,])
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i, j] = (dynamic)new Fraction(random.Next(Int32.MinValue, Int32.MaxValue), random.Next(Int32.MinValue, Int32.MaxValue));
                    }
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

        public static Matrix<T> operator *(Matrix<T> i, Matrix<T> j)
        {
            return new Matrix<T>(Multiply(i, j));
        }

        public static T[] operator *(Matrix<T> a, T[] vector)
        {
            return MultiplyByVector(a, vector);
        }

        private static T[,] Multiply(Matrix<T> a, Matrix<T> b)
        {
            var numberOfRows = a.NumberOfRows;
            var numberOfColumns = a.NumberOfColumns;
            var result = new T[a.NumberOfRows, b.NumberOfColumns];
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    var row = new T[numberOfColumns];
                    for (int k = 0; k < numberOfColumns; k++)
                    {
                        row[k] = a.MatrixValues[i, k];
                    }
                    var values = new T[numberOfRows];
                    for (int k = 0; k < numberOfRows; k++)
                    {
                        values[k] += (dynamic)b.MatrixValues[k, j] * (dynamic)row[k];
                    }

                    foreach (var value in values)
                    {
                        result[i, j] += (dynamic)value;
                    }

                }
            }
            return result;
        }

        private static T[] MultiplyByVector(Matrix<T> a, T[] vector)
        {
            var numberOfRows = a.NumberOfRows;
            var numberOfColumns = a.NumberOfColumns;
            var result = new T[a.NumberOfRows];
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    result[i] += (dynamic)a.MatrixValues[i, j] * vector[j];
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
                    matrix[i, j] = (dynamic)a.MatrixValues[i, j] - (dynamic)b.MatrixValues[i, j];
                }
            }
            return matrix;
        }

        public T[] GaussWithoutChoice(Matrix<T> a, T[] vector)
        {
            var res = new T[a.NumberOfRows];

            for (int i = 0; i < a.NumberOfRows - 1; i++)
            {
                for (int j = i + 1; j < a.NumberOfRows; j++)
                {
                    T multiplier = -(dynamic)a.MatrixValues[j, i] / (dynamic)a.MatrixValues[i, i];
                    for (int k = i + 1; k < a.NumberOfRows; k++)
                    {
                        a.MatrixValues[j, k] += multiplier * (dynamic)a.MatrixValues[i, k];
                    }
                    vector[j] += (dynamic)vector[i] * multiplier;
                }
            }

            for (int i = a.NumberOfRows - 1; i >= 0; i--)
            {
                T sum = (dynamic)vector[i];
                for (int j = a.NumberOfRows - 1; j >= i + 1; j--)
                {
                    sum -= (dynamic)a.MatrixValues[i, j] * res[j];
                }
                res[i] = sum / (dynamic)a.MatrixValues[i, i];
            }

            return res;
        }

        public T[] GaussWithPartialPivot(Matrix<T> matrix, T[] vector)
        {
            var currentRow = 0;
            int currentColumn;
            for (currentColumn = 0; currentColumn < matrix.NumberOfColumns - 1; currentColumn++, currentRow++)
            {
                var smallestRowIndex = FindIndexOfRowWithGreatestNumberInGivenColumn(currentRow, currentColumn);
                SwapRows(vector, currentRow, smallestRowIndex);
                ResetAllColumnsBelow(vector, currentRow, currentColumn);
            }
            return GetResultsAfterGauss(vector);
        }

        public T[] GaussWithCompletePivot(T[] vector)
        {
            var vectorHistory = Enumerable.Range(1, vector.Length).ToArray();
            for (int i = 0; i < NumberOfRows; i++)
            {
                var greatestElementPosition = GetGreatestElementPosition(i);
                if (greatestElementPosition.row != i)
                {
                    SwapRows(vector, i, greatestElementPosition.row);
                }
                if (greatestElementPosition.column != i)
                {
                    vectorHistory = SwapColumns(i, greatestElementPosition.column, vectorHistory);
                }
                ResetAllColumnsBelow(vector, i, i);
            }
            return GetProperVector(vector, vectorHistory);

        }

        public int[] SwapColumns(int numberOfFirstColumn, int numberOfSecondColumn, int[] vectorChange)
        {
            for (int i = 0; i < NumberOfRows; i++)
            {
                var temp = MatrixValues[i, numberOfFirstColumn];
                MatrixValues[i, numberOfFirstColumn] = MatrixValues[i, numberOfSecondColumn];
                MatrixValues[i, numberOfSecondColumn] = temp;
            }
            var tempVector = vectorChange[numberOfFirstColumn];
            vectorChange[numberOfFirstColumn] = vectorChange[numberOfSecondColumn];
            vectorChange[numberOfSecondColumn] = tempVector;
            return vectorChange;
        }

        public void SwapRows(T[] vector, int numberOfFirstRow, int numberOfSecondRow)
        {
            for (int i = 0; i < NumberOfColumns; i++)
            {
                var temp = MatrixValues[numberOfFirstRow, i];
                MatrixValues[numberOfFirstRow, i] = MatrixValues[numberOfSecondRow, i];
                MatrixValues[numberOfSecondRow, i] = temp;
            }
            var oldValue = vector[numberOfFirstRow];
            vector[numberOfFirstRow] = vector[numberOfSecondRow];
            vector[numberOfSecondRow] = oldValue;
        }

        private T[] GetResultsAfterGauss(T[] vector)
        {
            var resultsVector = new T[vector.Length];
            for (int i = vector.Length - 1; i >= 0; i--)
            {
                int j = i;
                var numerator = vector[i];
                while (j < NumberOfColumns - 1)
                {
                    numerator -= (dynamic)MatrixValues[i, j + 1] * resultsVector[j + 1];
                    j++;
                }
                resultsVector[i] = (dynamic) numerator / MatrixValues[i, i];
            }
            return resultsVector;
        }

        private T[] GetProperVector(T[] vector, int[] vectorHistory)
        {
            var resultsVector = GetResultsAfterGauss(vector);
            for (int i = 0; i < vector.Length; i++)
            {
                if (vectorHistory[i] == i)
                    continue;
                var indexToReplace = vectorHistory[i] - 1;

                var tempIndex = vectorHistory[i];
                vectorHistory[i] = vectorHistory[indexToReplace];
                vectorHistory[indexToReplace] = tempIndex;

                var tempValue = resultsVector[i];
                resultsVector[i] = resultsVector[indexToReplace];
                resultsVector[indexToReplace] = tempValue;
            }
            return resultsVector;
        }

        private (int row, int column) GetGreatestElementPosition(int startingPoint)
        {
            var result = (row: startingPoint, column: startingPoint);
            for (int i = startingPoint; i < NumberOfRows; i++)
            {
                for (int j = startingPoint; j < NumberOfColumns; j++)
                {
                    if ((dynamic)MatrixValues[i, j] > MatrixValues[result.row, result.column])
                    {
                        result = (i, j);
                    }
                }
            }
            return result;
        }

        private int FindIndexOfRowWithGreatestNumberInGivenColumn(int rowNumber, int columnNumber)
        {
            var greatestColumn = (dynamic)MatrixValues[rowNumber, columnNumber];
            int index = rowNumber;
            for (int i = rowNumber; i < NumberOfRows; i++)
            {
                if ((dynamic)MatrixValues[i, columnNumber] > (dynamic)greatestColumn)
                {
                    greatestColumn = MatrixValues[i, columnNumber];
                    index = i;
                }
            }
            return index;
        }

        public void ResetAllColumnsBelow(T[] vector, int rowNumber, int columnNumber)
        {
            for (int i = rowNumber + 1; i < NumberOfRows; i++)
            {
                var multiplier = -(dynamic)MatrixValues[i, columnNumber] / MatrixValues[rowNumber, columnNumber];
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    MatrixValues[i, j] += multiplier * MatrixValues[rowNumber, j];
                }
                vector[i] += vector[rowNumber] * multiplier;
            }
        }

    }
}