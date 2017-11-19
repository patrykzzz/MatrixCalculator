using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculator
{
    public class Comparison
    {
        private int _multiplier = 5;
        private int _range = 15;


        public Comparison(int multiplier, int range)
        {
            //all functions
        }

        private void CompareDoubleCsCppAndFraction()
        {
            
        }

        private void CompareFloatCsAndCpp()
        {
            StreamReader res1Cs = new StreamReader("../../../Output/Res1DataFloatCs.txt");
            StreamReader res1Cpp = new StreamReader("../../../Output/Res1DataFloat.txt");
            StreamReader res2Cs = new StreamReader("../../../Output/Res2DataFloatCs.txt");
            StreamReader res2Cpp = new StreamReader("../../../Output/Res2DataFloat.txt");
            StreamReader res3Cs = new StreamReader("../../../Output/Res3DataFloatCs.txt");
            StreamReader res3Cpp = new StreamReader("../../../Output/Res3DataFloat.txt");

            
            

            var file = new File<float>();

            for (int i = _range; i < _multiplier; i++)
            {
                var matrixRes1Cs = new Matrix<float>(file.ReadMatrixFromFile(i, res1Cs));
                var matrixRes1Cpp = new Matrix<float>(file.ReadMatrixFromFile(i, res1Cpp));
//                var matrixB = new Matrix<float>
            }
        }

        private void CompareDoubleCsAndCpp()
        {
            
        }

        private void CompareGaussFloat()
        {
            StreamReader gaussCs = new StreamReader("../../../Output/Res1DataFloatCs.txt"); //here other path to file

            StreamReader partialCs = new StreamReader("../../../Output/PartialDataFloatCs.txt");
            StreamReader partialCpp = new StreamReader("../../../Output/PartialDataFloat.txt");
            StreamReader fullCs = new StreamReader("../../../Output/FullDataFloatCs.txt");
            StreamReader fullCpp = new StreamReader("../../../Output/FullDataFloat.txt");
        }

        private void CompareGaussDoubleAndFraction()
        {
            
        }
    }
}
