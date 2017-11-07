using System;
using System.Diagnostics;
using Xunit;

namespace MatrixCalculator
{
    public class MatrixTests
    {
        [Fact]
        public void Add_IntValues_ShouldReturnProperMatrix()
        {
            //Arrange
            var x = new [,]
            {
                {1, 1, 1},
                {2, 2, 2},
                {3, 3, 3}
            };
            var a = new Matrix<int>(x);
            var y = new [,]
            {
                {1, 1, 1},
                {2, 2, 2},
                {3, 3, 3}
            };
            var b = new Matrix<int>(y);
            //Act
            var result = a + b;

            //Assert
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Debug.WriteLine(result.MatrixValues[i, j]);
                }
            }
            Assert.Equal(result.MatrixValues, new [,]
            {
                { 2, 2, 2},
                { 4, 4, 4},
                { 6, 6, 6}
            });
        }

    }
}