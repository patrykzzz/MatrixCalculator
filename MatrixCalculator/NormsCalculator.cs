using Xunit;

namespace MatrixCalculator
{
    public class NormsCalculator
    {
        private Comparison comparison = new Comparison();
        [Fact]
        public void GetNormsForFloatCsAndCpp()
        {
            comparison.CompareFloatCsAndCpp();
        }
    }
}