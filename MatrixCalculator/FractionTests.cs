using Xunit;

namespace MatrixCalculator
{
    public class FractionTests
    {
        [Fact]
        public void AddFraction()
        {
            //Arrange
            Fraction fst = new Fraction(1, 2);
            Fraction sec = new Fraction(1, 3);

            //Act
            var result = fst + sec;

            //Assert
            Assert.Equal("5/6", result.Show());
        }
    }
}
