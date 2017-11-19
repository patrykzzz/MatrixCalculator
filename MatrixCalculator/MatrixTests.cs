using Xunit;

namespace MatrixCalculator
{
    public class MatrixTests
    {
        [Fact]
        public void Add_IntValues_ShouldReturnProperMatrix()
        {
            //Arrange
            var x = new[,]
            {
                {1, 1, 1},
                {2, 2, 2},
                {3, 3, 3}
            };
            var a = new Matrix<int>(x);
            var y = new[,]
            {
                {1, 1, 1},
                {2, 2, 2},
                {3, 3, 3}
            };
            var b = new Matrix<int>(y);

            //Act
            var result = a + b;

            //Assert
            Assert.Equal(result.MatrixValues, new[,]
            {
                {2, 2, 2},
                {4, 4, 4},
                {6, 6, 6}
            });
        }

        [Fact]
        public void Subtract_IntValues_ShouldReturnProperMatrix()
        {
            //Arrange
            var x = new[,]
            {
                {1, 1, 1},
                {2, 5, 2},
                {3, 3, 4}
            };
            var a = new Matrix<int>(x);
            var y = new[,]
            {
                {1, 1, 1},
                {3, 1, 0},
                {5, 4, 3}
            };
            var b = new Matrix<int>(y);

            //Act
            var result = a - b;

            //Assert
            Assert.Equal(result.MatrixValues, new[,]
            {
                {0, 0, 0},
                {-1, 4, 2},
                {-2, -1, 1}
            });
        }

        [Fact]
        public void Multiply_IntValues_ShouldReturnProperMatrix()
        {
            //Arrange
            var x = new[,]
            {
                {1, 1, 1},
                {2, 2, 2},
                {3, 3, 3}
            };
            var a = new Matrix<int>(x);
            var y = new[,]
            {
                {1, 1, 1},
                {2, 2, 2},
                {3, 3, 3}
            };
            var b = new Matrix<int>(y);

            //Act
            var result = a * b;

            //Assert
            Assert.Equal(new[,]
            {
                {6, 6, 6},
                {12, 12, 12},
                {18, 18, 18}
            }, result.MatrixValues);
        }

        [Fact]
        public void GaussWithoutChoice_ProperValues_ShouldReturnProperVector()
        {
            //Arrange
            var x = new[,]
            {
                {4d, -2d, 4d, -2d},
                {3d, 1d, 4d, 2d},
                {2d, 4d, 2d, 1d},
                {2d, -2d, 4d, 2d}
            };
            var a = new Matrix<double>(x);
            double[] b = { 8, 7, 10, 2 };
            double[] expectedResult = { -1, 2, 3, -2 };

            //Act
            var result = a.GaussWithoutChoice(a, b);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void MultiplyByVector_ShouldReturnProperVector()
        {
            //Arrange
            var x = new[,]
            {
                {3, 1, 0, 3},
                {2, 4, 7, 0},
                {-1, 2, 3, 4}
            };
            var a = new Matrix<int>(x);
            int[] res = { 7, 13, 8 };
            int[] b = { 1, 1, 1, 1 };

            //Act
            var result = a * b;

            //Assert
            Assert.Equal(res, result);
        }

        [Fact]
        public void SwapRows_ProperMatrixAndVector_ShouldReturnProperResult()
        {
            //Arrange
            var matrixValues = new[,]
            {
                {0.1, 0.2, 0.3, 0.4},
                {0.2, 0.4, 0.5, 0.3},
                {0.3, 0.5, 0.6, 0.7}
            };
            var vector = new[]
            {
                0.1, 0.2, 0.3
            };
            var numberOfFirstRow = 0;
            var numberOfSecondRow = 2;
            var matrix = new Matrix<double>(matrixValues);

            //Act
            matrix.SwapRows(vector, numberOfFirstRow, numberOfSecondRow);

            //Assert
            Assert.Equal(new[,]
            {
                {0.3, 0.5, 0.6, 0.7},
                {0.2, 0.4, 0.5, 0.3},
                {0.1, 0.2, 0.3, 0.4}
            }, matrixValues);
            Assert.Equal(new[]
            {
                0.3, 0.2, 0.1
            }, vector);
        }

        [Fact]
        public void ResetAllColumsBelow_HasGivenValues_ResetsColumnsProperly()
        {
            //Arrange
            var matrix = new Matrix<double>(new[,] {
                { 1.0, 1.0, 1.0, 0.5 },
                { 1.0, 1.0, 1.0, 1.0 },
                { 2.0, 2.0, 2.0, 2.0 }
            });
            var vector = new[] { 1.0, 1.0, 1.0 };

            //Act
            matrix.ResetAllColumnsBelow(vector, 0, 1);

            //Assert
            Assert.Equal(new[,]
            {
                {1.0, 1.0, 1.0, 0.5 },
                {0, 0, 0, 0.5 },
                {0, 0, 0, 1 }
            }, matrix.MatrixValues);
            Assert.Equal(new[]
            {
                1.0, 0, -1.0
            }, vector);
        }

        [Fact]
        public void GaussWithPartialPivot_ProperValues_ShouldReturnProperVector()
        {
            //Arrange
            var x = new[,]
            {
                {4d, -2d, 4d, -2d},
                {3d, 1d, 4d, 2d},
                {2d, 4d, 2d, 1d},
                {2d, -2d, 4d, 2d}
            };
            var matrix = new Matrix<double>(x);
            double[] vector = { 8, 7, 10, 2 };
            double[] expectedResult = { -1, 2, 3, -2 };

            //Act
            var result = matrix.GaussWithPartialPivot(matrix, vector);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GaussWithCompletePivot_ProperValues_ShouldReturnProperVector()
        {
            //Arrange
            var x = new[,]
            {
                {4d, -2d, 4d, -2d},
                {3d, 1d, 4d, 2d},
                {2d, 4d, 2d, 1d},
                {2d, -2d, 4d, 2d}
            };
            var matrix = new Matrix<double>(x);
            double[] vector = { 8, 7, 10, 2 };
            double[] expectedResult = { -1, 2, 3, -2 };

            //Act
            var result = matrix.GaussWithCompletePivot(vector);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Operations_ChecFractionkMultiplyByVector_ShouldReturnProperResult()
        {
            //Arrange
            var matrix = new Matrix<Fraction>(new[,] {
                { new Fraction(1,2), new Fraction(1,3), new Fraction(1,4), new Fraction(1,2) },
                { new Fraction(1,3), new Fraction(1,3), new Fraction(1,3), new Fraction(1,3) },
                { new Fraction(1,4), new Fraction(1,2), new Fraction(1,2), new Fraction(1,2) }
            });
            var vector = new[] { new Fraction(1, 2), new Fraction(1, 3), new Fraction(1, 4), new Fraction(1, 2) };

            //Act
            var res = matrix * vector;

            //Assert
            Assert.Equal(new []
            {
                new Fraction(25, 36), new Fraction(19, 36), new Fraction(16,24)  
            }, res);
        }
    }
}