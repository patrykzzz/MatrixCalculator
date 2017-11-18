using System;
using System.Globalization;
using System.IO;
using System.Net.Mime;
using System.Runtime.InteropServices;

namespace MatrixCalculator
{
    public class Program
    {
        
        private readonly StreamReader _firstMatrixDouble = new StreamReader("../../../Output/FirstMatrixDataDouble.txt");
        private readonly StreamReader _secondMatrixDouble = new StreamReader("../../../Output/SecondMatrixDataDouble.txt");
        private readonly StreamReader _thirdMatrixDouble = new StreamReader("../../../Output/ThirdMatrixDataDouble.txt");
        private readonly StreamReader _vectorDouble = new StreamReader("../../../Output/VectorDataDouble.txt");
        private readonly StreamWriter _firstOpDouble = new StreamWriter("../../../Output/Res1DataDoubleCs.txt");
        private readonly StreamWriter _secOpDouble = new StreamWriter("../../../Output/Res2DataDoubleCs.txt");
        private readonly StreamWriter _thrdOpDouble = new StreamWriter("../../../Output/Res3DataDoubleCs.txt");
        private readonly StreamWriter _partialDouble = new StreamWriter("../../../Output/PartialDataDoubleCs.txt");
        private readonly StreamWriter _fullDouble = new StreamWriter("../../../Output/FullDataDoubleCs.txt");

        private readonly StreamReader _firstMatrixFloat = new StreamReader("../../../Output/FirstMatrixDataFloat.txt");
        private readonly StreamReader _secondMatrixFloat = new StreamReader("../../../Output/SecondMatrixDataFloat.txt");
        private readonly StreamReader _thirdMatrixFloat = new StreamReader("../../../Output/ThirdMatrixDataFloat.txt");
        private readonly StreamReader _vectorFloat = new StreamReader("../../../Output/VectorDataFloat.txt");
        private readonly StreamWriter _firstOpFloat = new StreamWriter("../../../Output/Res1DataFloatCs.txt");
        private readonly StreamWriter _secOpFloat = new StreamWriter("../../../Output/Res2DataFloatCs.txt");
        private readonly StreamWriter _thrdOpFloat = new StreamWriter("../../../Output/Res3DataFloatCs.txt");
        private readonly StreamWriter _partialFloat = new StreamWriter("../../../Output/PartialDataFloatCs.txt");
        private readonly StreamWriter _fullFloat = new StreamWriter("../../../Output/FullDataFloatCs.txt");

        private readonly StreamWriter _firstMatrixFraction = new StreamWriter("../../../Output/FirstMatrixDataFraction.txt");
        private readonly StreamWriter _secondMatrixFraction = new StreamWriter("../../../Output/SecondMatrixDataFraction.txt");
        private readonly StreamWriter _thirdMatrixFraction = new StreamWriter("../../../Output/ThirdMatrixDataFraction.txt");
        private readonly StreamWriter _vectorFraction = new StreamWriter("../../../Output/VectorDataFraction.txt");
        private readonly StreamWriter _firstOpFraction = new StreamWriter("../../../Output/Res1DataFraction.txt");
        private readonly StreamWriter _secOpFraction = new StreamWriter("../../../Output/Res2DataFraction.txt");
        private readonly StreamWriter _thrdOpFraction = new StreamWriter("../../../Output/Res3DataFraction.txt");
        private readonly StreamWriter _partialFraction = new StreamWriter("../../../Output/PartialDataFraction.txt");
        private readonly StreamWriter _fullFraction = new StreamWriter("../../../Output/FullDataFraction.txt");

//        private readonly StreamReader _firstMatrixFractionDouble = new StreamReader("../../../Output/FirstMatrixDataFraction.txt");
//        private readonly StreamReader _secondMatrixFractionDouble = new StreamReader("../../../Output/SecondMatrixDataFraction.txt");
//        private readonly StreamReader _thirdMatrixFractionDouble = new StreamReader("../../../Output/ThirdMatrixDataFraction.txt");
//        private readonly StreamReader _vectorFractionDouble = new StreamReader("../../../Output/VectorDataFraction.txt");
//        private readonly StreamWriter _firstOpFractionDouble = new StreamWriter("../../../Output/Res1DataFractionDouble.txt");
//        private readonly StreamWriter _secOpFractionDouble = new StreamWriter("../../../Output/Res2DataFractionDouble.txt");
//        private readonly StreamWriter _thrdOpFractionDouble = new StreamWriter("../../../Output/Res3DataFractionDouble.txt");
//        private readonly StreamWriter _partialFractionDouble = new StreamWriter("../../../Output/PartialDataFractionDouble.txt");
//        private readonly StreamWriter _fullFractionDouble = new StreamWriter("../../../Output/FullDataFractionDouble.txt");




        public static void Main(string[] args)
        {
            var program = new Program();

            var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            culture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            int multiplier = 5;
            for (int i = multiplier; i < 100; i += multiplier)
            {
                program.CreateFillMatrixAndWriteToFileDouble(i);
                program.CreateFillMatrixAndWriteToFileFloat(i);
                program.CreateFillMatrixAndWriteToFileFraction(i);
            }

            program._firstMatrixDouble.Close();
            program._firstMatrixDouble.Close();
            program._secondMatrixDouble.Close();
            program._thirdMatrixDouble.Close();
            program._vectorDouble.Close();
            program._firstOpDouble.Close();
            program._secOpDouble.Close();
            program._thrdOpDouble.Close();
            program._partialDouble.Close();
            program._fullDouble.Close();

            program._firstMatrixFloat.Close();
            program._firstMatrixFloat.Close();
            program._secondMatrixFloat.Close();
            program._thirdMatrixFloat.Close();
            program._vectorFloat.Close();
            program._firstOpFloat.Close();
            program._secOpFloat.Close();
            program._thrdOpFloat.Close();
            program._partialFloat.Close();
            program._fullFloat.Close();

            program._firstMatrixFraction.Close();
            program._firstMatrixFraction.Close();
            program._secondMatrixFraction.Close();
            program._thirdMatrixFraction.Close();
            program._vectorFraction.Close();
            program._firstOpFraction.Close();
            program._secOpFraction.Close();
            program._thrdOpFraction.Close();
            program._partialFraction.Close();
            program._fullFraction.Close();

            Console.WriteLine("Program ended its operation");
            Console.ReadKey();
        }

        private void CreateFillMatrixAndWriteToFileDouble(int size)
        {
            var file = new File<double>();

            var matrixA = new Matrix<double>(file.ReadMatrixFromFile(size, _firstMatrixDouble));
            var matrixB = new Matrix<double>(file.ReadMatrixFromFile(size, _secondMatrixDouble));
            var matrixC = new Matrix<double>(file.ReadMatrixFromFile(size, _thirdMatrixDouble));
            double[] vector = file.ReadVectorFromFile(size, _vectorDouble);
            
            var res1 = matrixA * vector;
            var res2 = (matrixA + matrixB + matrixC) * vector;
            var res3 = matrixA * (matrixB * matrixC);

            //gauss?
            //pivLuDouble
            //FullPivLuDouble

            file.WriteToFile(res1, size, _firstOpDouble);
            file.WriteToFile(res2, size, _secOpDouble);
            file.WriteToFile(res3, size, _thrdOpDouble);
        }

        private void CreateFillMatrixAndWriteToFileFloat(int size)
        {
            var file = new File<float>();

            var matrixA = new Matrix<float>(file.ReadMatrixFromFile(size, _firstMatrixFloat));
            var matrixB = new Matrix<float>(file.ReadMatrixFromFile(size, _secondMatrixFloat));
            var matrixC = new Matrix<float>(file.ReadMatrixFromFile(size, _thirdMatrixFloat));
            float[] vector = file.ReadVectorFromFile(size, _vectorFloat);

            var res1 = matrixA * vector;
            var res2 = (matrixA + matrixB + matrixC) * vector;
            var res3 = matrixA * (matrixB * matrixC);

            //gauss?
            //pivLuFloat
            //FullPivLuFloat

            file.WriteToFile(res1, size, _firstOpFloat);
            file.WriteToFile(res2, size, _secOpFloat);
            file.WriteToFile(res3, size, _thrdOpFloat);
        }

        private void CreateFillMatrixAndWriteToFileFraction(int size)
        {
            var file = new File<Fraction>();

            var matrixA = new Matrix<Fraction>(size, size);
            var matrixB = new Matrix<Fraction>(size, size);
            var matrixC = new Matrix<Fraction>(size, size);
            Fraction[] vector = file.FillVectorWithRandom(size);

            var res1 = matrixA * vector;
            var res2 = (matrixA + matrixB + matrixC) * vector;
            var res3 = matrixA * (matrixB * matrixC);

            //gauss?
            //pivLuFloat
            //FullPivLuFloat

            file.WriteToFile(matrixA, size, _firstMatrixFraction);
            file.WriteToFile(matrixB, size, _secondMatrixFraction);
            file.WriteToFile(matrixC, size, _thirdMatrixFraction);
            file.WriteToFile(vector, size, _vectorFraction);
            file.WriteToFile(res1, size, _firstOpFraction);
            file.WriteToFile(res2, size, _secOpFraction);
            file.WriteToFile(res3, size, _thrdOpFraction);
        }
    }
}
