using System;
using System.IO;
using System.Runtime.InteropServices;

namespace MatrixCalculator
{
    public class Program
    {
        private readonly StreamWriter _firstMatrixFile = new StreamWriter("FirstMatrixData.txt");
        private readonly StreamWriter _secondMatrixFile = new StreamWriter("SecondMatrixData.txt");
        private readonly StreamWriter _thirdMatrixFile = new StreamWriter("ThirdMatrixData.txt");
        private readonly StreamWriter _vectorFile = new StreamWriter("VectorData.txt");
        private readonly StreamWriter _firstOp = new StreamWriter("FirstOperationData.txt");
        private readonly StreamWriter _secOp = new StreamWriter("SecondOperationData.txt");
        private readonly StreamWriter _thrdOp = new StreamWriter("ThirdOperationData.txt");


        public static void Main(string[] args)
        {
            var program = new Program();

            program.CreateFillMatrixAndWriteToFileDouble(5);
            program.CreateFillMatrixAndWriteToFileDouble(10);
            program.CreateFillMatrixAndWriteToFileDouble(15);


            program._firstMatrixFile.Close();
            program._secondMatrixFile.Close();
            program._vectorFile.Close();
            program._firstOp.Close();
            program._secOp.Close();
            program._thrdOp.Close();

            Console.ReadKey();

        }

        private void CreateFillMatrixAndWriteToFileDouble(int size)
        {
            var file = new File<double>();

            var matrixA = new Matrix<double>(size, size);
            var matrixB = new Matrix<double>(size, size);
            var matrixC = new Matrix<double>(size, size);
            double[] vector = file.FillVectorWithRandom(size);

            file.WriteToFile(matrixA, size, _firstMatrixFile);
            file.WriteToFile(matrixB, size, _secondMatrixFile);
            file.WriteToFile(matrixC, size, _thirdMatrixFile);
            file.WriteToFile(vector, size,  _vectorFile);

            var res1 = matrixA * vector;
            var res2 = (matrixA + matrixB + matrixC) * vector;
            var res3 = matrixA * (matrixB * matrixC);

            Console.Write(res1);

            file.WriteToFile(res1, size, _firstOp);
            file.WriteToFile(res2, size, _secOp);
            file.WriteToFile(res3, size, _thrdOp);

        }

        private void CreateFillMatrixAndWriteToFileFloat(int size)
        {

        }

        private void CreateFillMatrixAndWriteToFileFraction(int size)
        {

        }
    }
}
