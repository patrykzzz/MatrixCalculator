using Xunit;

namespace MatrixCalculator
{
    public class FractionTests
    {
        [Fact]
        public void Add_HasProperValues_ShouldReturnProperResult()
        {
            //Arrange
            var first = new Fraction(1, 2);
            var second = new Fraction(1, 3);

            //Act
            var result = first + second;

            //Assert
            Assert.Equal(5, result.Numeral);
            Assert.Equal(6, result.Denominator);
        }

        [Fact]
        public void Subtract_HasProperValues_ShouldReturnProperResult()
        {
            //Arrange
            var first = new Fraction(7, 8);
            var second = new Fraction(2, 5);

            //Act
            var result = first - second;

            //Assert
            Assert.Equal(19, result.Numeral);
            Assert.Equal(40, result.Denominator);
        }

        [Fact]
        public void Subtract_HasNumber_ShouldReturnProperResult()
        {
            //Arrange
            var first = new Fraction(7, 8);
            long second = 3;

            //Act
            var result = first - second;

            //Assert
            Assert.Equal(-17, result.Numeral);
            Assert.Equal(8, result.Denominator);
        }

        [Fact]
        public void Subtract_HasNegativeValues_ShouldReturnProperResult()
        {
            //Arrange
            var first = new Fraction(2, 5);
            var second = new Fraction(7, 8);

            //Act
            var result = first - second;

            //Assert
            Assert.Equal(-19, result.Numeral);
            Assert.Equal(40, result.Denominator);
        }

        [Fact]
        public void Multiply_HasProperValues_ShouldReturnProperResult()
        {
            //Arrange
            var first = new Fraction(3, 5);
            var second = new Fraction(2, 3);

            //Act
            var result = first * second;

            //Assert
            Assert.Equal(6, result.Numeral);
            Assert.Equal(15, result.Denominator);
        }

        [Fact]
        public void Multiply_HasNegativeValue_ShouldReturnProperResult()
        {
            //Arrange
            var first = new Fraction(-3, 5);
            var second = new Fraction(2, 3);

            //Act
            var result = first * second;

            //Assert
            Assert.Equal(-6, result.Numeral);
            Assert.Equal(15, result.Denominator);
        }

        [Fact]
        public void Divide_HasProperValues_ShouldReturnProperResult()
        {
            //Arrange
            var first = new Fraction(1, 2);
            var second = new Fraction(1, 3);

            //Act
            var result = first / second;

            //Assert
            Assert.Equal(3, result.Numeral);
            Assert.Equal(2, result.Denominator);
        }

        [Fact]
        public void Divide_HasNumber_ShouldReturnProperResult()
        {
            //Arrange
            var first = new Fraction(1, 2);
            long second = 5;

            //Act
            var result = first / second;

            //Assert
            Assert.Equal(1, result.Numeral);
            Assert.Equal(10, result.Denominator);
        }

        [Fact]
        public void Multiply_HasNegativeValues_ShouldReturnProperResult()
        {
            //Arrange
            var first = new Fraction(-3, 5);
            var second = new Fraction(2, -3);

            //Act
            var result = first * second;

            //Assert
            Assert.Equal(6, result.Numeral);
            Assert.Equal(15, result.Denominator);
        }

        [Fact]
        public void Multiply_HasNegativeDenominator_ShouldReturnProperResult()
        {
            //Arrange
            var first = new Fraction(3, 5);
            var second = new Fraction(2, -3);

            //Act
            var result = first * second;

            //Assert
            Assert.Equal(-6, result.Numeral);
            Assert.Equal(15, result.Denominator);
        }

        [Fact]
        public void Multiply_HasNumber_ShouldReturnProperResult()
        {
            //Arrange
            var first = new Fraction(3, 5);
            long second = 6;

            //Act
            var result = first * second;

            //Assert
            Assert.Equal(18, result.Numeral);
            Assert.Equal(5, result.Denominator);
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