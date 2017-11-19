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

        private void CompareDoubleAndFractionCs()
        {
            
        }

        private void CompareFloatCsAndCpp()
        {
            StreamReader _floatCs = new StreamReader("../../../Output/Res1DataFloatCs.txt");
            StreamReader _floatCpp = new StreamReader("../../../Output/Res1DataFloat.txt");

            for (int i = _range; i < _multiplier; i++)
            {
                
            }
        }

        private void CompareDoubleCsAndCpp()
        {
            
        }

        private void CompareGaussFloat()
        {
            
        }

        private void CompareGaussDouble()
        {
            
        }
    }
}
