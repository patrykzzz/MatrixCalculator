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
<<<<<<< Updated upstream
            Assert.Equal("5/6", result.Show());
=======
            Assert.Equal(5, result.Numeral);
            Assert.Equal(6, result.Denominator);
            
>>>>>>> Stashed changes
        }

        [Fact]
        public void SubtractFraction()
        {
            //Arrange
            Fraction fst = new Fraction(7, 8);
            Fraction sec = new Fraction(2, 5);

            //Act
            var result = fst - sec;

            //Assert
            Assert.Equal("19/40", result.Show());
        }

        [Fact]
        public void SubtractFraction_checkSubtractByNumer()
        {
            //Arrange
            Fraction fst = new Fraction(7, 8);
            long sec = 3;

            //Act
            var result = fst - sec;

            //Assert
            Assert.Equal("-17/8", result.Show());
        }

        [Fact]
        public void SubtractFraction_checkMinus()
        {
            //Arrange
            Fraction fst = new Fraction(2, 5);
            Fraction sec = new Fraction(7, 8);

            //Act
            var result = fst - sec;

            //Assert
            Assert.Equal("-19/40", result.Show());
        }

        [Fact]
        public void MultiplyFraction()
        {
            //Arrange
            Fraction fst = new Fraction(3, 5);
            Fraction sec = new Fraction(2, 3);

            //Act
            var result = fst * sec;

            //Assert
            Assert.Equal("6/15", result.Show());
        }

        [Fact]
        public void MultiplyFraction_checkMinus()
        {
            //Arrange
            Fraction fst = new Fraction(-3, 5);
            Fraction sec = new Fraction(2, 3);

            //Act
            var result = fst * sec;

            //Assert
            Assert.Equal("-6/15", result.Show());
        }

        [Fact]
        public void DivideFraction()
        {
            //Arrange
            Fraction fst = new Fraction(1, 2);
            Fraction sec = new Fraction(1, 3);

            //Act
            var result = fst / sec;

            //Assert
            Assert.Equal("3/2", result.Show());
        }

        [Fact]
        public void DivideFraction_checkDivideByNumer()
        {
            //Arrange
            Fraction fst = new Fraction(1, 2);
            long sec = 5;

            //Act
            var result = fst / sec;

            //Assert
            Assert.Equal("1/10", result.Show());
        }

        [Fact]
        public void MultiplyFraction_checkMinuses()
        {
            //Arrange
            Fraction fst = new Fraction(-3, 5);
            Fraction sec = new Fraction(2, -3);

            //Act
            var result = fst * sec;

            //Assert
            Assert.Equal("6/15", result.Show());
        }

        [Fact]
        public void MultiplyFraction_checkDenominatorMinus()
        {
            //Arrange
            Fraction fst = new Fraction(3, 5);
            Fraction sec = new Fraction(2, -3);

            //Act
            var result = fst * sec;

            //Assert
            Assert.Equal("-6/15", result.Show());
        }

        [Fact]
        public void MultiplyFraction_checkNultiplyByNumber()
        {
            //Arrange
            Fraction fst = new Fraction(3, 5);
            long sec = 6;

            //Act
            var result = fst * sec;

            //Assert
            Assert.Equal("18/5", result.Show());
        }

        [Fact]
        public void Operations_CheckReduce_ShouldReturnProperResult()
        {
            //Arrange
            var first = new Fraction(1024*1024, 2048*2048);
            var second = new Fraction(1, 1);

            //Act
            var result = first * second;

            //Assert
            Assert.Equal(1, result.Numeral);
            Assert.Equal(4, result.Denominator);
        }
    }
}
