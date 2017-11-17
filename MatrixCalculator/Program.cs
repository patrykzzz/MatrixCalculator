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

        }
    }
}
