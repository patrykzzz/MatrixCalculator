using System;
using System.Globalization;
using System.IO;
using System.Net.Mime;
using System.Runtime.InteropServices;

namespace MatrixCalculator
{
    public class Program
    {
       private readonly StreamWriter _firstMatrixFile = new StreamWriter("FirstMatrixData.txt");
       private readonly StreamWriter _secondMatrixFile = new StreamWriter("SecondMatrixData.txt");
       private readonly StreamWriter _thirdMatrixFile = new StreamWriter("ThirdMatrixData.txt");
       private readonly StreamWriter _vectorFile = new StreamWriter("VectorData.txt");
       private readonly StreamWriter _firstOp = new StreamWriter("Res1DataDoubleCs.txt");
       private readonly StreamWriter _secOp = new StreamWriter("Res2DataDoubleCs.txt");
       private readonly StreamWriter _thrdOp = new StreamWriter("Res3DataDoubleCs.txt");


        public static void Main(string[] args)
        {
            var program = new Program();

            var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            culture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            program.CreateFillMatrixAndWriteToFileDouble(5, 5);
            program.CreateFillMatrixAndWriteToFileDouble(10, 5);
            //program.CreateFillMatrixAndWriteToFileDouble(15);


            program._firstMatrixFile.Close();
//            program._secondMatrixFile.Close();
//
//            program._vectorFile.Close();
            program._firstOp.Close();
            program._secOp.Close();
            program._thrdOp.Close();
            double x = 0.3124323d;
            Console.WriteLine(x);
            Console.ReadKey();

           
        }

        private void CreateFillMatrixAndWriteToFileDouble(int size, int multiple)
        {
            var file = new File<double>();

            var matrixA = new Matrix<double>(file.ReadDoubleMatrixFromFile("FirstMatrixDataDouble", size, multiple));
            var matrixB = new Matrix<double>(file.ReadDoubleMatrixFromFile("SecondMatrixDataDouble", size, multiple));
            var matrixC = new Matrix<double>(file.ReadDoubleMatrixFromFile("ThirdMatrixDataDouble", size, multiple));
            double[] vector = file.FillVectorDouble("VectorDataDouble", size, multiple);
            //
            file.WriteToFile(matrixA, size, _firstMatrixFile);
//            file.WriteToFile(matrixB, size, _secondMatrixFile);
//            file.WriteToFile(matrixC, size, _thirdMatrixFile);
//            file.WriteToFile(vector, size,  _vectorFile);
//
//            var res1 = matrixA * vector;
//            var res2 = (matrixA + matrixB + matrixC) * vector;
//            var res3 = matrixA * (matrixB * matrixC);


//            file.WriteToFile(res1, size, _firstOp);
//            file.WriteToFile(res2, size, _secOp);
//            file.WriteToFile(res3, size, _thrdOp);

        }

        private void CreateFillMatrixAndWriteToFileFloat(int size)
        {

        }

        private void CreateFillMatrixAndWriteToFileFraction(int size)
        {

        }
    }
}
