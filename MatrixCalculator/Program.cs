using System;
using System.Globalization;
using System.IO;
using System.Net.Mime;
using System.Runtime.InteropServices;

namespace MatrixCalculator
{
    public class Program
    {
        private readonly StreamWriter _firstMatrixFloat = new StreamWriter("../../../Output/FirstMatrixDataFloat.txt");
        private readonly StreamWriter _secondMatrixFloat = new StreamWriter("../../../Output/SecondMatrixDataFloat.txt");
        private readonly StreamWriter _thirdMatrixFloat = new StreamWriter("../../../Output/ThirdMatrixDataFloat.txt");
        private readonly StreamWriter _gaussMatrixFloat = new StreamWriter("../../../Output/GaussMatrixDataFloat.txt");
        private readonly StreamWriter _vectorFloat = new StreamWriter("../../../Output/VectorDataFloat.txt");
        private readonly StreamWriter _firstOpFloat = new StreamWriter("../../../Output/Res1DataFloatCs.txt");
        private readonly StreamWriter _secOpFloat = new StreamWriter("../../../Output/Res2DataFloatCs.txt");
        private readonly StreamWriter _thrdOpFloat = new StreamWriter("../../../Output/Res3DataFloatCs.txt");
        private readonly StreamWriter _gaussFloat = new StreamWriter("../../../Output/GaussDataFloatCs.txt");
        private readonly StreamWriter _partialFloat = new StreamWriter("../../../Output/PartialDataFloatCs.txt");
        private readonly StreamWriter _fullFloat = new StreamWriter("../../../Output/FullDataFloatCs.txt");

        private readonly StreamWriter _firstMatrixFraction = new StreamWriter("../../../Output/FirstMatrixDataFraction.txt");
        private readonly StreamWriter _secondMatrixFraction = new StreamWriter("../../../Output/SecondMatrixDataFraction.txt");
        private readonly StreamWriter _thirdMatrixFraction = new StreamWriter("../../../Output/ThirdMatrixDataFraction.txt");
        private readonly StreamWriter _gaussMatrixFraction = new StreamWriter("../../../Output/GaussMatrixDataFraction.txt");
        private readonly StreamWriter _vectorFraction = new StreamWriter("../../../Output/VectorDataFraction.txt");
        private readonly StreamWriter _firstOpFraction = new StreamWriter("../../../Output/Res1DataFraction.txt");
        private readonly StreamWriter _secOpFraction = new StreamWriter("../../../Output/Res2DataFraction.txt");
        private readonly StreamWriter _thrdOpFraction = new StreamWriter("../../../Output/Res3DataFraction.txt");
        private readonly StreamWriter _gaussFraction = new StreamWriter("../../../Output/GaussDataFraction.txt");
        private readonly StreamWriter _partialFraction = new StreamWriter("../../../Output/PartialDataFraction.txt");
        private readonly StreamWriter _fullFraction = new StreamWriter("../../../Output/FullDataFraction.txt");

        private StreamReader _firstMatrixFractionDouble;
        private StreamReader _secondMatrixFractionDouble;
        private StreamReader _thirdMatrixFractionDouble;
        private StreamReader _gaussMatrixFractionDouble;
        private StreamReader _vectorFractionDouble;
        private readonly StreamWriter _firstOpFractionDouble = new StreamWriter("../../../Output/Res1DataFractionDouble.txt");
        private readonly StreamWriter _secOpFractionDouble = new StreamWriter("../../../Output/Res2DataFractionDouble.txt");
        private readonly StreamWriter _thrdOpFractionDouble = new StreamWriter("../../../Output/Res3DataFractionDouble.txt");
        private readonly StreamWriter _gaussFractionDouble = new StreamWriter("../../../Output/GaussDataFractionDouble.txt");
        private readonly StreamWriter _partialFractionDouble = new StreamWriter("../../../Output/PartialDataFractionDouble.txt");
        private readonly StreamWriter _fullFractionDouble = new StreamWriter("../../../Output/FullDataFractionDouble.txt");

        public static void Main(string[] args)
        {
            var program = new Program();

            var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            culture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            int multiplier = 2;
            int range = 5;
            for (int i = multiplier; i < range ; i += multiplier)
            {
                Console.WriteLine("Iteration - " + i);
                program.CreateFillMatrixAndWriteToFileFloat(i);
                program.CreateFillMatrixAndWriteToFileFraction(i);
                Console.WriteLine("Done");
            }

            program._firstMatrixFloat.Close();
            program._secondMatrixFloat.Close();
            program._thirdMatrixFloat.Close();
            program._gaussMatrixFloat.Close();
            program._vectorFloat.Close();
            program._firstOpFloat.Close();
            program._secOpFloat.Close();
            program._thrdOpFloat.Close();
            program._gaussFloat.Close();
            program._partialFloat.Close();
            program._fullFloat.Close();

            program._firstMatrixFraction.Close();
            program._secondMatrixFraction.Close();
            program._thirdMatrixFraction.Close();
            program._gaussMatrixFraction.Close();
            program._vectorFraction.Close();
            program._firstOpFraction.Close();
            program._secOpFraction.Close();
            program._thrdOpFraction.Close();
            program._gaussFraction.Close();
            program._partialFraction.Close();
            program._fullFraction.Close();

            program._firstMatrixFractionDouble = new StreamReader("../../../Output/FirstMatrixDataFraction.txt");
            program._secondMatrixFractionDouble = new StreamReader("../../../Output/SecondMatrixDataFraction.txt");
            program._thirdMatrixFractionDouble = new StreamReader("../../../Output/ThirdMatrixDataFraction.txt");
            program._gaussMatrixFractionDouble = new StreamReader("../../../Output/GaussMatrixDataFraction.txt");
            program._vectorFractionDouble = new StreamReader("../../../Output/VectorDataFraction.txt");

            for (int i = multiplier; i < range; i += multiplier)
            {
                program.CreateFillMatrixAndWriteToFileFractionDouble(i);
            }

            program._firstMatrixFractionDouble.Close();
            program._secondMatrixFractionDouble.Close();
            program._thirdMatrixFractionDouble.Close();
            program._gaussMatrixFractionDouble.Close();
            program._vectorFractionDouble.Close();
            program._firstOpFractionDouble.Close();
            program._secOpFractionDouble.Close();
            program._thrdOpFractionDouble.Close();
            program._gaussFractionDouble.Close();
            program._partialFractionDouble.Close();
            program._fullFractionDouble.Close();

            Console.WriteLine("Program ended its operation");
            Console.ReadKey();
        }

        private void CreateFillMatrixAndWriteToFileFloat(int size)
        {
            var file = new File<float>();

            var matrixA = new Matrix<float>(size, size);
            var matrixB = new Matrix<float>(size, size);
            var matrixC = new Matrix<float>(size, size);
            var gaussMatrix = new Matrix<float>(size, size);
            float[] vector = file.FillVectorWithRandom(size);

            var res1 = matrixA * vector;
            var res2 = (matrixA + matrixB + matrixC) * vector;
            var res3 = matrixA * (matrixB * matrixC);

            file.WriteToFile(matrixA, size, _firstMatrixFloat);
            file.WriteToFile(matrixB, size, _secondMatrixFloat);
            file.WriteToFile(matrixC, size, _thirdMatrixFloat);
            file.WriteToFile(gaussMatrix, size, _gaussMatrixFloat);
            file.WriteToFile(vector, size, _vectorFloat);

            var gauss = gaussMatrix.GaussWithoutChoice(gaussMatrix, vector);
            var pivot = gaussMatrix.GaussWithPartialPivot(gaussMatrix, vector);
            var full = gaussMatrix.GaussWithCompletePivot(vector);

            file.WriteToFile(res1, size, _firstOpFloat);
            file.WriteToFile(res2, size, _secOpFloat);
            file.WriteToFile(res3, size, _thrdOpFloat);

            file.WriteToFile(gauss, size, _gaussFloat);
            file.WriteToFile(pivot, size, _partialFloat);
            file.WriteToFile(full, size, _fullFloat);
        }

        private void CreateFillMatrixAndWriteToFileFraction(int size)
        {
            var file = new File<Fraction>();

            var matrixA = new Matrix<Fraction>(size, size);
            var matrixB = new Matrix<Fraction>(size, size);
            var matrixC = new Matrix<Fraction>(size, size);
            var gaussMatrix = new Matrix<Fraction>(size, size);
            Fraction[] vector = file.FillVectorWithRandom(size);

            var res1 = matrixA * vector;
            var res2 = (matrixA + matrixB + matrixC) * vector;
            var res3 = matrixA * (matrixB * matrixC);

            file.WriteToFile(matrixA, size, _firstMatrixFraction);
            file.WriteToFile(matrixB, size, _secondMatrixFraction);
            file.WriteToFile(matrixC, size, _thirdMatrixFraction);
            file.WriteToFile(gaussMatrix, size, _gaussMatrixFraction);
            file.WriteToFile(vector, size, _vectorFraction);

            var gauss = gaussMatrix.GaussWithoutChoice(gaussMatrix, vector);
            Console.WriteLine("Gauss ok");
            var pivot = gaussMatrix.GaussWithPartialPivot(gaussMatrix, vector);
            Console.WriteLine("Partial ok");
            var full = gaussMatrix.GaussWithCompletePivot(vector);
            Console.WriteLine("Full ok");

            file.WriteToFile(res1, size, _firstOpFraction);
            file.WriteToFile(res2, size, _secOpFraction);
            file.WriteToFile(res3, size, _thrdOpFraction);

            file.WriteToFile(gauss, size, _gaussFraction);
            file.WriteToFile(pivot, size, _partialFraction);
            file.WriteToFile(full, size, _fullFraction);
        }

        private void CreateFillMatrixAndWriteToFileFractionDouble(int size)
        {
            var file = new File<double>();

            var matrixA = new Matrix<double>(file.ReadMatrixFromFile(size, _firstMatrixFractionDouble));
            var matrixB = new Matrix<double>(file.ReadMatrixFromFile(size, _secondMatrixFractionDouble));
            var matrixC = new Matrix<double>(file.ReadMatrixFromFile(size, _thirdMatrixFractionDouble));
            var gaussMatrix = new Matrix<double>(file.ReadMatrixFromFile(size, _gaussMatrixFractionDouble));
            double[] vector = file.ReadVectorFromFile(size, _vectorFractionDouble);

            var res1 = matrixA * vector;
            var res2 = (matrixA + matrixB + matrixC) * vector;
            var res3 = matrixA * (matrixB * matrixC);

            var gauss = gaussMatrix.GaussWithoutChoice(gaussMatrix, vector);
            var pivot = gaussMatrix.GaussWithPartialPivot(gaussMatrix, vector);
            var full = gaussMatrix.GaussWithCompletePivot(vector);

            file.WriteToFile(res1, size, _firstOpFractionDouble);
            file.WriteToFile(res2, size, _secOpFractionDouble);
            file.WriteToFile(res3, size, _thrdOpFractionDouble);

            file.WriteToFile(gauss, size, _gaussFractionDouble);
            file.WriteToFile(pivot, size, _partialFractionDouble);
            file.WriteToFile(full, size, _fullFractionDouble);
        }
    }
}
